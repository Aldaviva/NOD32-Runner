using System.Diagnostics;
using KoKo.Property;

namespace NOD32_Runner
{
    public class ServiceModel
    {
        public readonly StoredProperty<ServiceStatus> Status = new StoredProperty<ServiceStatus>(ServiceStatus.Stopped);
        public string Name { get; }
        public Stopwatch StartupDurationStopwatch { get; } = new Stopwatch();

        public ServiceModel(string name)
        {
            Name = name;
        }
    }

    public enum ServiceStatus
    {
        Starting,
        Started,
        Stopping,
        Stopped
    }
}