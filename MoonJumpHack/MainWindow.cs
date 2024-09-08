using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MoonJumpHack
{
    public partial class MainWindow : Form
    {
        ProcessMemoryReader Reader { get; set; }

        bool HackState { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Write initial states of statuses.

            ResetAllStates();
        }

        void SetProcessStatus(int PID, bool status)
        {
            if (status)
            {
                string fmt = String.Format("Game running. (PID {0}).", PID);

                labelProcessStatus.Text = fmt;
                labelProcessStatus.ForeColor = SystemColors.ControlText;
            }
            else
            {
                labelProcessStatus.Text = "Game not running.";
                labelProcessStatus.ForeColor = Color.Red;
            }
        }

        void SetHackStatus(bool status)
        {
            HackState = status;

            if (HackState)
            {
                labelSwitchStatus.Text = "Hack Enabled.";
                labelSwitchStatus.ForeColor = Color.Red;
            }
            else
            {
                labelSwitchStatus.Text = "Hack Disabled.";
                labelSwitchStatus.ForeColor = SystemColors.ControlText;
            }
        }

        void ResetAllStates()
        {
            SetProcessStatus(0, false);
            SetHackStatus(false);

            timerOperation.Stop();
            timerProcessScan.Start();
        }

        void KeyInputCheck()
        {
            if (ExternAPI.GetAsyncKeyState(114) >> 15 > 0)
            {
                // 114: F3 - Enable Hack
                SetHackStatus(true);
            }
            else if (ExternAPI.GetAsyncKeyState(115) >> 15 > 0)
            {
                // 115: F4 - Disable Hack
                SetHackStatus(false);
            }
        }

        private void timerOperation_Tick(object sender, EventArgs e)
        {
            // This activates when the game is running.

            if (Reader != null)
            {
                if (Reader.CheckProcessStatus())
                {
                    // The game is running.

                    if (HackState)
                    {
                        // Only touch memory when the Hack is enabled.
                        Reader.ModifyMemory();
                    }

                    // Check keyboard input.
                    KeyInputCheck();
                }
                else
                {
                    // The game has exited. Cleanup.
                    Reader.Dispose();
                    Reader = null;
                    ResetAllStates();
                }
            }
            else
            {
                // Just in case.
                ResetAllStates();
            }
        }

        string GetProcessName()
        {
            if (checkBoxRetailCD.Checked)
            {
                // In unpatched retail CD version, the Rayman2.exe executable
                // is not the actual game process.
                return "RAYMAN2.ICD";
            }
            else
            {
                return "Rayman2";
            }
        }

        private void timerProcessScan_Tick(object sender, EventArgs e)
        {
            // This activates when the game is not running.
            
            // NOTE: It appears this call can cause memory leaks as I noticed
            //       the program's memory footprint grows every time this timer ticks.
            //       Consider reducing the scanning frequency to slow down the growth.
            Process[] processesByName = Process.GetProcessesByName(GetProcessName());

            if (processesByName.Length == 0)
            {
                // The game isn't running at the moment.
                return;
            }

            // Found a running game process.

            Process process = processesByName[0];

            Reader = new ProcessMemoryReader(process);

            SetProcessStatus(process.Id, true);
            timerOperation.Start();
            timerProcessScan.Stop();
        }
    }
}
