using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace NOD32_Runner
{
    public interface ServiceManager
    {
        ServiceModel GetService(String name);
        void Start(ServiceModel service);
        void Stop(ServiceModel service);
        void ShowGui(ServiceModel service);
    }

    public class ServiceManagerImpl : ServiceManager
    {
        private static ServiceController GetServiceController(ServiceModel service)
        {
            return new ServiceController(service.Name);
        }

        public ServiceModel GetService(String name)
        {
            var service = new ServiceModel(name);
            service.Status = GetServiceStatus(service);
            return service;
        }

        public void Start(ServiceModel service)
        {
            service.Status = ServiceStatus.Starting;

            SetServiceStartMode(service, StartMode.Manual);

            ServiceController serviceController = GetServiceController(service);
            serviceController.Start();

            Task.Run(() =>
            {
                using (serviceController) {
                    serviceController.WaitForStatus(ServiceControllerStatus.Running);
                    Task.Delay(TimeSpan.FromSeconds(4));
                    service.Status = ServiceStatus.Started;
                }
            });
        }

        public void Stop(ServiceModel service)
        {
            service.Status = ServiceStatus.Stopping;

            SetServiceStartMode(service, StartMode.Disabled);
            using (ManagementObject wmiService = GetWmiService(service))
            {
                int pid = Convert.ToInt32(wmiService.GetPropertyValue("ProcessId"));
                if (pid != 0)
                {
                    using (Process process = Process.GetProcessById(pid))
                    {
                        process.Kill();
                    }
                }
            }

            foreach (Process guiProcess in Process.GetProcessesByName("egui"))
            {
                guiProcess.Kill();
            }

            service.Status = ServiceStatus.Stopped;
        }

        public void ShowGui(ServiceModel service)
        {
            string installationDirectory = GetInstallationDirectory(service);
            string guiImagePath = Path.Combine(installationDirectory, "egui.exe");
            Process.Start(guiImagePath);
        }

        private void SetServiceStartMode(ServiceModel service, StartMode startMode)
        {
            using (ManagementObject wmiService = GetWmiService(service))
            {
                ManagementBaseObject reqParams = wmiService.GetMethodParameters("ChangeStartMode");
                reqParams["StartMode"] = startMode.ToWmiString();
                wmiService.InvokeMethod("ChangeStartMode", reqParams, null);
            }
        }

        private ManagementObject GetWmiService(ServiceModel service)
        {
            using (var searcher = new ManagementObjectSearcher(new SelectQuery("Win32_Service", $"Name = '{service.Name}'")))
            using (ManagementObjectCollection results = searcher.Get())
            using (ManagementObjectCollection.ManagementObjectEnumerator resultsEnumerator = results.GetEnumerator())
            {
                resultsEnumerator.MoveNext();
                using (var serviceObject = (ManagementObject) resultsEnumerator.Current)
                {
                    return serviceObject;
                }
            }
        }

        private ServiceStatus GetServiceStatus(ServiceModel service)
        {
            using (ServiceController serviceController = GetServiceController(service))
            {
                switch (serviceController.Status)
                {
                    case ServiceControllerStatus.Running:
                        return ServiceStatus.Started;
                    case ServiceControllerStatus.StartPending:
                    case ServiceControllerStatus.ContinuePending:
                        return ServiceStatus.Starting;
                    case ServiceControllerStatus.Stopped:
                    case ServiceControllerStatus.Paused:
                        return ServiceStatus.Stopped;
                    case ServiceControllerStatus.StopPending:
                    case ServiceControllerStatus.PausePending:
                        return ServiceStatus.Stopping;
                    default:
                        return ServiceStatus.Stopped;
                }
            }
        }

        private string GetInstallationDirectory(ServiceModel service)
        {
            using (ManagementObject wmiService = GetWmiService(service))
            {
                string serviceImagePath = (string) wmiService.GetPropertyValue("PathName");
                string guiImagePath = Path.Combine(Path.GetDirectoryName(serviceImagePath), "..");
                return guiImagePath;
            }
        }
    }

    internal enum StartMode
    {
        Automatic,
        Manual,
        Disabled
    }

    internal static class StartModeExtensions
    {
        internal static string ToWmiString(this StartMode startMode)
        {
            switch (startMode)
            {
                case StartMode.Automatic:
                    return "Auto";
                case StartMode.Manual:
                    return "Manual";
                case StartMode.Disabled:
                    return "Disabled";
                default:
                    throw new ArgumentException();
            }
        }
    }
}