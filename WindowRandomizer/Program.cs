using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowRandomizer
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        static void Main(string[] args)
        {
            Process[] proclist = Process.GetProcesses();
            foreach (Process p in proclist)
            {
                string windowTitle = p.MainWindowTitle;
                char[] chars = windowTitle.ToArray();
                Random r = new Random(259);
                for (int i = 0; i < chars.Length; i++)
                {
                    int randomIndex = r.Next(0, chars.Length);
                    char temp = chars[randomIndex];
                    chars[randomIndex] = chars[i];
                    chars[i] = temp;
                }
                var s = new string(chars);
                Console.WriteLine("Changed title of " + p.ProcessName);
                SetWindowText(p.MainWindowHandle, s);
            }
        }
    }
}