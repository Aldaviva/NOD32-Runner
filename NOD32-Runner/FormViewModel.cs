using System.ComponentModel;
using System.Runtime.CompilerServices;
using NOD32_Runner.Annotations;

namespace NOD32_Runner
{
    public class FormViewModel: INotifyPropertyChanged
    {
        private readonly ServiceModel serviceModel;
        private readonly ServiceManager serviceManager;

        public bool IsServiceCheckboxChecked => serviceModel.Status == ServiceStatus.Started || serviceModel.Status == ServiceStatus.Starting;

        public bool IsServiceCheckboxEnabled => serviceModel.Status == ServiceStatus.Started || serviceModel.Status == ServiceStatus.Stopped;

        public bool IsGuiButtonEnabled => serviceModel.Status == ServiceStatus.Started;

        public bool IsProgressBarVisible => serviceModel.Status == ServiceStatus.Starting || serviceModel.Status == ServiceStatus.Stopping;

        public FormViewModel(ServiceModel serviceModel, ServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            this.serviceModel = serviceModel;
            serviceModel.PropertyChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(IsGuiButtonEnabled));
                OnPropertyChanged(nameof(IsServiceCheckboxChecked));
                OnPropertyChanged(nameof(IsServiceCheckboxEnabled));
                OnPropertyChanged(nameof(IsProgressBarVisible));
            };
        }

        public void StartService()
        {
            serviceManager.Start(serviceModel);
        }

        public void StopService()
        {
            serviceManager.Stop(serviceModel);
        }

        public void ShowUserInterface()
        {
            serviceManager.ShowGui(serviceModel);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
