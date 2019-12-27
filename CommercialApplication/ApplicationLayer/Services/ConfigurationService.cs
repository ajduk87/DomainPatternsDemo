using CommercialApplicationCommand.ApplicationLayer.Dtoes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CommercialApplicationCommand.ApplicationLayer.Services
{
    public class ConfigurationService : BaseAppService, IConfigurationService
    {
        public List<Parameter> GetParameters()
        {
            using (StreamReader streamReader = new StreamReader("..\\..\\..\\Configurations\\configuration.json"))
            {
                string json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Parameter>>(json);
            }
        }
    }
}