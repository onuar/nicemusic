using System;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Processes = System.Diagnostics;

namespace Nicemusic.Winamp
{
    public static class Process
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPTStr)] string lpClassName,
                                                [MarshalAs(UnmanagedType.LPTStr)] string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessageA(
            IntPtr hwnd,
            int wMsg,
            int wParam,
            uint lParam);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, Int32 wParam, Int32 lParam);
        
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(
          IntPtr hProcess,
          IntPtr lpBaseAddress,
          [Out] byte[] lpBuffer,
          int dwSize,
          out IntPtr lpNumberOfBytesRead
         );

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        public static string GetCurrentSongFilePath()
        {
            Processes.Process winampProcess = Processes.Process.GetProcessesByName("winamp").Single();

            IntPtr hwndWinamp = FindWindow("Winamp v1.x", null);
            var trackPos = SendMessageA(hwndWinamp, 0x0400, 0, 125);
            var baseAddress = SendMessage(hwndWinamp, 0x0400, trackPos, 211);
            var hwndWinampP = OpenProcess(ProcessAccessFlags.VmRead, false, winampProcess.Id);
            var value = new byte[256];
            var numberOfBytesRead = new IntPtr();
            ReadProcessMemory(hwndWinampP, baseAddress, value, 256, out numberOfBytesRead);
            CloseHandle(hwndWinampP);

            var filePath = Encoding.UTF8.GetString(value);

            filePath = filePath.Substring(0, filePath.IndexOf("\0"));

            return filePath.Replace("\0", string.Empty);
        }

        [Flags]
        private enum ProcessAccessFlags : uint
        {
            VmRead = 0x00000010,
        }
    }
}
