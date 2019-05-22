using System;
using System.ServiceProcess;

[Serializable]
public class AplicationDomain
{
    public AplicationDomain()
    {

    }
    public string serviceName { get; set; }
    public string serviceDisplayName { get; set; }
    public ServiceType ServiceType { get; set; }
    public ServiceControllerStatus Status { get; set; }
    public string MachiName { get; set; }
    public DateTime DateTimeUtc { get; set; }

}
