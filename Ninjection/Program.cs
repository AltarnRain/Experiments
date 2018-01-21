using Ninject;
using Ninjection.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ninjection
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var kernel = new StandardKernel())
            {
                var viewFactory = kernel.Get<ViewFactory>();
                var mainForm = viewFactory.Create<MainForm>();
                Application.Run(mainForm);
            }

        }
    }
}
