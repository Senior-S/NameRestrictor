using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SeniorS.NameRestrictor;
public class Configuration : IRocketPluginConfiguration
{
    public void LoadDefaults()
    {
        shouldNotifyInvalidString = true;

        restrictedStrings = new()
        {
            "<",
            ">",
            "#",
            "sus",
            ".com"
        };
    }

    public bool shouldNotifyInvalidString;

    [XmlArrayItem("RestrictedString")]
    public List<string> restrictedStrings;
}