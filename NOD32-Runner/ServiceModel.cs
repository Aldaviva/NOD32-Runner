using System.ComponentModel;
using System.Runtime.CompilerServices;
using NOD32_Runner.Annotations;

namespace NOD32_Runner
{
//    [AddINotifyPropertyChangedInterface]
    public class ServiceModel: INotifyPropertyChanged
    {
        private ServiceStatus status;
        public string Name { get; }

        public ServiceStatus Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        public ServiceModel(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum ServiceStatus
    {
        Starting, Started, Stopping, Stopped
    }
}