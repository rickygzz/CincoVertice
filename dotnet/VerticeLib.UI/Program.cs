using System.Diagnostics;

namespace VerticeLib.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsProcessCurrentlyRunning())
            {
                Application.Exit();

                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        private static bool IsProcessCurrentlyRunning()
        {
            string fileWithoutExtension = Path.GetFileNameWithoutExtension(
                System.Reflection.Assembly.GetEntryAssembly()!.Location);

            Process[] processes = Process.GetProcessesByName(fileWithoutExtension);
            Process thisProcess = Process.GetCurrentProcess();

            foreach (Process process in processes)
            {
                if (process.Id != thisProcess.Id)
                {
                    // Message.Error(
                    //    "The application is currently running",
                    //    process.ProcessName + '\n' + process.MainModule!.FileName);

                    // WinAPI.User32.SetForegroundWindow(process.MainWindowHandle);

                    return true;
                }
            }

            return false;
        }
    }
}
