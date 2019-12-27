using CommercialApplicationCommand.ApplicationLayer.Dtoes;
using CommercialApplicationCommand.DomainLayer.Entities;
using System.Collections.Generic;

namespace CommercialApplicationCommand.DomainLayer.Mappings
{
    public interface IMapper
    {
        Destination Map<Source, Destination>(Source dto) where Source : Dto
                                                        where Destination : Entity;

        Destination MapView<Source, Destination>(Source entity) where Source : Entity
                                                        where Destination : Dto;

        Destination MapViewList<Source, Destination>(Source entities) where Source : IEnumerable<Entity>
                                                        where Destination : IEnumerable<Dto>;
    }
}