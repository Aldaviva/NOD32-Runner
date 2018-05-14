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
            showGuiButton.DataBindings.Add("Enabled", model.IsGuiButtonEnabled);
            progressBar1.DataBindings.Add("Visible", model.IsProgressBarVisible);
            serviceEnabledCheckbox.DataBindings.Add("Enabled", model.IsServiceCheckboxEnabled);
            serviceEnabledCheckbox.DataBindings.Add("Checked", model.IsServiceCheckboxChecked);
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