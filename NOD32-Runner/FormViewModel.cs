using KoKo.Property;

namespace NOD32_Runner
{
    public class FormViewModel
    {
        private readonly ServiceModel serviceModel;
        private readonly ServiceManager serviceManager;

        public readonly Property<bool> IsServiceCheckboxChecked;
        public readonly Property<bool> IsServiceCheckboxEnabled;
        public readonly Property<bool> IsGuiButtonEnabled;
        public readonly Property<bool> IsProgressBarVisible;

        public FormViewModel(ServiceModel serviceModel, ServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            this.serviceModel = serviceModel;

            IsServiceCheckboxChecked = new DerivedProperty<bool>(new[] { serviceModel.Status },
                () => serviceModel.Status.Value == ServiceStatus.Started || serviceModel.Status.Value == ServiceStatus.Starting);

            IsServiceCheckboxEnabled = new DerivedProperty<bool>(new[] { serviceModel.Status },
                () => serviceModel.Status.Value == ServiceStatus.Started || serviceModel.Status.Value == ServiceStatus.Stopped);

            IsGuiButtonEnabled = new DerivedProperty<bool>(new[] { serviceModel.Status },
                () => serviceModel.Status.Value == ServiceStatus.Started);

            IsProgressBarVisible = new DerivedProperty<bool>(new[] { serviceModel.Status },
                () => serviceModel.Status.Value == ServiceStatus.Starting || serviceModel.Status.Value == ServiceStatus.Stopping);
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
    }
}