using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ObjectCreator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                AllocConsole();

                if (args[0] == "-h")
                {
                    Console.WriteLine("Usage: ObjectCreator [ObjectName] [ScriptDelta] [Interactive (0, 1)]");
                    Console.ReadLine();
                }
                else
                {
                    string objName = args[0];
                    StarboundObject obj = new StarboundObject(objName);

                    if (args.Length > 1)
                        obj.scriptDelta = int.Parse(args[1]); // Yes. No checking if it's a valid int.
                    if (args.Length > 2)
                        obj.interactive = args[2] == "1";

                    File.WriteAllText(objName + ".object", JsonConvert.SerializeObject(obj, Formatting.Indented));
                }

                FreeConsole();
            }
        }

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call Marshal.GetLastWin32Error.</returns>
        [DllImport("kernel32", SetLastError = true)]
        static extern bool AllocConsole();

        /// <summary>
        /// Detaches the calling process from its console
        /// </summary>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call Marshal.GetLastWin32Error.</returns>
        [DllImport("kernel32", SetLastError = true)]
        static extern bool FreeConsole();
    }
}
