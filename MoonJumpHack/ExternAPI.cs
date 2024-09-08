using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MoonJumpHack
{
    public static class ExternAPI
    {
        [DllImport("kernel32")]
        public static extern IntPtr OpenProcess(
          uint dwDesiredAccess,
          int bInheritHandle,
          uint dwProcessId);

        [DllImport("kernel32")]
        public static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32")]
        public static extern int ReadProcessMemory(
          IntPtr hProcess,
          IntPtr lpBaseAddress,
          [In, Out] byte[] buffer,
          uint size,
          out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32")]
        public static extern int WriteProcessMemory(
          IntPtr hProcess,
          IntPtr lpBaseAddress,
          [In, Out] byte[] buffer,
          uint size,
          out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool VirtualProtectEx(
          IntPtr hProcess,
          IntPtr lpAddress,
          uint dwSize,
          uint flNewProtect,
          out uint lpflOldProtect);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern ushort GetAsyncKeyState(int vkey);
    }
}
