using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
        public static extern bool ShowWindow(IntPtr hwnd, int cmd);

        public static void ShowCloseWindow()
        {
            foreach (var proc in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    if (IsIconic(proc.MainWindowHandle))
                    {
                        ShowWindow(proc.MainWindowHandle, 4);
                    }
                    else if (IsIconic(proc.MainWindowHandle) != true)
                    {
                        ShowWindow(proc.MainWindowHandle, 6);
                    }
                }
            }
        }

        public static void ShowCloseWindow1(Process proc)
        {
            if (!string.IsNullOrEmpty(proc.MainWindowTitle))
            {
                if (IsIconic(proc.MainWindowHandle))
                {
                    ShowWindow(proc.MainWindowHandle, 1);
                }
                else if (IsIconic(proc.MainWindowHandle) != true)
                {
                    ShowWindow(proc.MainWindowHandle, 6);
                }
            }
        }

        public static string GetProperties(Process proc)
        {
            string properties = "";
            Type type = proc.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo property in propertyInfos)
            {
                if (property.Name == "ExitCode" || property.Name == "ExitTime" || property.Name == "StartInfo" ||
                    property.Name == "StandardInput" || property.Name == "StandardOutput" || property.Name == "StandardError")
                    continue;
                properties += property.Name + " : " + property.GetValue(proc) + "\r\n";
            }
            return properties;
        }
    }
}