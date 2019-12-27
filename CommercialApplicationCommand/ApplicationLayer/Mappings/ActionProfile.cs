using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.ApplicationLayer.Models.Action;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    internal class ActionProfile : Profile
    {
        public ActionProfile()
        {
            CreateMap<ActionDto, ActionViewModel>();

            CreateMap<ActionCreateModel, ActionDto>();
            CreateMap<ActionUpdateModel, ActionDto>();
            CreateMap<ActionCustomerUpdateModel, ActionDto>();
            CreateMap<ActionDeleteModel, ActionDto>();
        }
    }
}