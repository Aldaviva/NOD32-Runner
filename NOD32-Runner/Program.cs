using System;
using System.Windows.Forms;

namespace NOD32_Runner
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceManager serviceManager = new ServiceManagerImpl();
            ServiceModel serviceModel = serviceManager.GetService("ekrn");
            var viewModel = new FormViewModel(serviceModel, serviceManager);
            var form = new Form1(viewModel);

            Application.Run(form);
        }
    }
}
