using CommercialApplicationCommand.ApplicationLayer.Dtoes;
using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Services
{
    public interface IConfigurationService
    {
        List<Parameter> GetParameters();
    }
}