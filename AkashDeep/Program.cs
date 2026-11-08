using System;
using System.Linq;
using System.Windows.Forms;

namespace AkashDeep
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the Windows Forms application.
        /// Supports running automated validation/CRUD verification tests via '--test' argument.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Contains("--test"))
            {
                VerificationTests.RunAllTests();
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
