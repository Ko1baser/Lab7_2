using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace windows_manager
{
    public class Manager
    {
        [DllImport("user32.dll")]
        public static extern bool SetWindowText(IntPtr hWnd, string text);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        //private static extern int ShowWindow(int hwnd, int nCmdShow);
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        public static void Minimize_Maximize(Process proc)
        {
            if (proc.MainWindowHandle != IntPtr.Zero)
            {

                WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
                GetWindowPlacement(proc.MainWindowHandle, ref placement);
                switch (placement.showCmd)
                {
                    case 1:
                        ShowWindow(proc.MainWindowHandle, ShowWindowEnum.ShowMinimized);
                        break;
                    case 2:
                        ShowWindow(proc.MainWindowHandle, ShowWindowEnum.ShowMaximized);
                        break;
                    case 3:
                        ShowWindow(proc.MainWindowHandle, ShowWindowEnum.ShowMinimized);
                        break;
                }
            }


            if (IsIconic(proc.Handle) == true)
            {
                ShowWindow(proc.MainWindowHandle, ShowWindowEnum.ShowMaximized);
            }
            else if (IsIconic(proc.Handle) == false)
            {
                ShowWindow(proc.MainWindowHandle, ShowWindowEnum.ShowMinimized);
            }
        }

        public enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };
    }
}