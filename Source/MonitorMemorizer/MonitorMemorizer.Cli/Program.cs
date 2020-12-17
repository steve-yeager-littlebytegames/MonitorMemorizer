using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using PInvoke;

namespace MonitorMemorizer.Cli
{
    public static class Program
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        const short SWP_NOMOVE = 0X2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0X4;
        const int SWP_SHOWWINDOW = 0x0040;

        public static void Main(string[] args)
        {
            Process[] processlist = Process.GetProcesses();
            
            foreach (Process process in processlist)
            {
                if(!string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    User32.EnumWindows(IterateWindow, new IntPtr(0));
                    //Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                    //User32.SetWindowPlacement(process.MainWindowHandle, User32.WINDOWPLACEMENT.Create().)
                    //User32.SetWindowPos(process.MainWindowHandle, new IntPtr(0), 0, 0, 600, 600, User32.SetWindowPosFlags.SWP_SHOWWINDOW | User32.SetWindowPosFlags.SWP_FRAMECHANGED);
                }
            }
        }

        private static bool IterateWindow(IntPtr hwnd, IntPtr lparam)
        {
            Console.WriteLine($"Window handle is {hwnd}, lparam is {lparam}");
            return true;
        }
    }
}