using System;

namespace AgGateway.ADAPT.ADMPlugin.Models
{
  public class AdmVersionInfo
  {
    [ObsoleteAttribute("The PluginVersion value should be used instead of this.")]
    public string AdmVersion { get; set; }

    public Version PluginVersion { get; set; }

    public SerializationVersionEnum SerializationVersion { get; set; }
  }
}
