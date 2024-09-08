using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace MoonJumpHack
{
    public class ProcessMemoryReader: IDisposable
    {
        private bool disposedValue;

        Process ReadProcess { get; set; }

        public ProcessMemoryReader(Process process)
        {
            ReadProcess = process;
        }

        // Public methods.

        public bool CheckProcessStatus()
        {
            // Check whether the process is still running.

            if (disposedValue) return false;

            return !ReadProcess.HasExited;
        }

        public void ModifyMemory()
        {
            if (disposedValue) return;

            int startingAddr = (int)ReadProcess.MainModule.BaseAddress + 750340;

            // NOTE: If any step returned 0 it means the corresponding ReadMem
            //       operation has failed, thus nothing should be touched.

            int nextAddr1 = ReadInt(startingAddr);
            if (nextAddr1 == 0) return;
            nextAddr1 += 1464;

            int nextAddr2 = ReadInt(nextAddr1);
            if (nextAddr2 == 0) return;
            nextAddr2 += 248;

            int nextAddr3 = ReadInt(nextAddr2);
            if (nextAddr3 == 0) return;
            nextAddr3 += 52;

            int nextAddr4 = ReadInt(nextAddr3);
            if (nextAddr4 == 0) return;
            // nextAddr4 is used as-is.

            int finalAddr = ReadInt(nextAddr4);
            if (finalAddr == 0) return;
            finalAddr += 476;

            // Now finalAddr has the place we want to read.
            PlayerData? data = ReadStruct<PlayerData>(finalAddr);
            if (data == null) return;

            // Only try to modify the value if successfully read.
            PlayerData dataStr = data.Value;
            dataStr.posZ += 0.1f;
            WriteStruct(finalAddr, dataStr);
            return;
        }

        public int ReadInt(int MemoryAddress)
        {
            if (disposedValue) return 0;

            return ReadMem(MemoryAddress, 4U, out byte[] buffer) == 0 ? 0 : BitConverter.ToInt32(buffer, 0);
        }

        // Non-public methods.

        object ReadStruct(int addr, Type type)
        {
            int size = ReadMem(addr, (uint)Marshal.SizeOf(type), out byte[] buffer);

            if (size == 0)
            {
                // Use null to indicate a failed read.
                return null;
            }

            IntPtr num = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, num, buffer.Length);
            object structure = Marshal.PtrToStructure(num, type);
            Marshal.FreeHGlobal(num);
            return structure;
        }

        T? ReadStruct<T>(int addr) where T: struct
        {
            object read = ReadStruct(addr, typeof(T));

            if (read == null)
            {
                return null;
            }
            else
            {
                return (T)read;
            }
        }

        int WriteStruct<T>(int addr, T data) where T: struct
        {
            int length = Marshal.SizeOf(data);
            byte[] numArray = new byte[length];
            IntPtr num = Marshal.AllocHGlobal(length);
            Marshal.StructureToPtr(data, num, true);
            Marshal.Copy(num, numArray, 0, length);
            Marshal.FreeHGlobal(num);
            return WriteMem(addr, numArray);
        }

        int ReadMem(int MemoryAddress, uint bytesToRead, out byte[] buffer)
        {
            IntPtr ptr = ExternAPI.OpenProcess(56U, 1, (uint)ReadProcess.Id);
            if (ptr == IntPtr.Zero)
            {
                buffer = new byte[0];
                return 0;
            }
            else
            {
                buffer = new byte[(int)bytesToRead];
                ExternAPI.ReadProcessMemory(ptr, (IntPtr)MemoryAddress, buffer, bytesToRead, out IntPtr lpNumberOfBytesRead);
                int result = lpNumberOfBytesRead.ToInt32();
                ExternAPI.CloseHandle(ptr);
                return result;
            }
        }

        int WriteMem(int MemoryAddress, byte[] buf)
        {
            IntPtr ptr = ExternAPI.OpenProcess(56U, 1, (uint)ReadProcess.Id);
            if (ptr == IntPtr.Zero)
            {
                return 0;
            }

            ExternAPI.VirtualProtectEx(ptr, (IntPtr)MemoryAddress, (uint)buf.Length, 4U, out uint _);
            ExternAPI.WriteProcessMemory(ptr, (IntPtr)MemoryAddress, buf, (uint)buf.Length, out IntPtr lpNumberOfBytesWritten);
            int result = lpNumberOfBytesWritten.ToInt32();
            ExternAPI.CloseHandle(ptr);
            return result;
        }

        // IDisposable.

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects)
                    ReadProcess?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
