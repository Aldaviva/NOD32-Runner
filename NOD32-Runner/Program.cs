using System;
using System.Windows.Forms;

namespace NOD32_Runner
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
            ServiceManager serviceManager = new ServiceManagerImpl();
            ServiceModel serviceModel = serviceManager.GetService("ekrn");
            FormViewModel viewModel = new FormViewModel(serviceModel, serviceManager);
            Application.Run(new Form1(viewModel));
        }
    }
}
