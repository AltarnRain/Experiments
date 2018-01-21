using DataGridWithObjectData.Factories;
using Ninject;
using System;
using System.Windows.Forms;

namespace DataGridWithObjectData
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

            using (var kernel = new StandardKernel(new Modules()))
            {
                var mainForm = kernel.Get<ViewFactory>().Create<DataGridWithObjectData>();
                Application.Run(mainForm);
            }
        }
    }
}
