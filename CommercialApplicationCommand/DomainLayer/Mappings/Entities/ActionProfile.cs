using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    public class ActionProfile : Profile
    {
        public ActionProfile()
        {
            CreateMap<ActionDto, ActionEntity>();
        }
    }
}