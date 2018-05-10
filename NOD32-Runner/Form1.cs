using System.Windows.Forms;

namespace NOD32_Runner
{
    public partial class Form1 : Form
    {
        private readonly FormViewModel model;

        public Form1(FormViewModel serviceModel)
        {
            model = serviceModel;

            InitializeComponent();
        }

        private void showGuiButton_Click(object sender, System.EventArgs e)
        {
            model.ShowUserInterface();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            bindingSource.DataSource = model;
        }

        private void serviceEnabledCheckbox_Click(object sender, System.EventArgs e)
        {
            bool shouldStart = ((CheckBox)sender).Checked;
            if (shouldStart)
            {
                model.StartService();
            }
            else
            {
                model.StopService();
            }
        }

    }
}