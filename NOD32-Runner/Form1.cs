using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace NOD32_Runner
{
    public partial class Form1 : Form
    {
        private const int ProgressBarUpdateFrequencyMilliseconds = 1000 / 60;

        private readonly FormViewModel model;
        private readonly TaskbarManager taskbarManager = TaskbarManager.Instance;

        public Form1(FormViewModel serviceModel)
        {
            model = serviceModel;
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            showGuiButton.DataBindings.Add("Enabled", model.IsGuiButtonEnabled);
            progressBar1.DataBindings.Add("Visible", model.IsProgressBarVisible);
            serviceEnabledCheckbox.DataBindings.Add("Enabled", model.IsServiceCheckboxEnabled);
            serviceEnabledCheckbox.DataBindings.Add("Checked", model.IsServiceCheckboxChecked);
            DataBindings.Add("UseWaitCursor", model.IsProgressBarVisible);

            model.IsProgressBarVisible.PropertyChanged += UpdateTaskbarProgress;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = FormViewModel.ExpectedStartupDurationMilliseconds;
        }

        private void UpdateTaskbarProgress(object sender, PropertyChangedEventArgs e)
        {
            taskbarManager.SetProgressState(model.IsProgressBarVisible.Value
                ? TaskbarProgressBarState.Normal
                : TaskbarProgressBarState.NoProgress);

            Task.Run(() =>
            {
                while (model.IsProgressBarVisible.Value)
                {
                    int currentProgress = (int) model.ElapsedStartupDurationMilliseconds;
                    progressBar1.Value = currentProgress;
                    taskbarManager.SetProgressValue(currentProgress, FormViewModel.ExpectedStartupDurationMilliseconds);

                    Thread.Sleep(ProgressBarUpdateFrequencyMilliseconds);
                }
            });
        }

        private void showGuiButton_Click(object sender, System.EventArgs e)
        {
            model.ShowUserInterface();
        }

        private void serviceEnabledCheckbox_Click(object sender, System.EventArgs e)
        {
            bool shouldStart = ((CheckBox) sender).Checked;
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