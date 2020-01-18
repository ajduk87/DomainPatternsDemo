using CommercialApplicationCommand.ApplicationLayer.Dtoes;
using CommercialApplicationCommand.DomainLayer.Entities;
using System.Collections.Generic;

namespace CommercialApplicationCommand.DomainLayer.Mappings
{
    public class DtoToEntityMapper : IMapper
    {
        protected readonly EntityFactory entityFactory;

        public DtoToEntityMapper()
        {
            this.entityFactory = new EntityFactory();
        }

        public Destination Map<Source, Destination>(Source dto) where Source : Dto
                                                                where Destination : Entity
        {
            return (Destination)this.entityFactory.Create<Source, Destination>(dto);
        }

        public Destination MapList<Source, Destination>(Source dto) where Source : IEnumerable<Dto>
                                                        where Destination : IEnumerable<Entity>
        {
            return (Destination)this.entityFactory.CreateList<Source, Destination>(dto);
        }

        public Destination MapView<Source, Destination>(Source entity) /*where Source : Entity*/
                                                       where Destination : Dto
        {
            return (Destination)this.entityFactory.Get<Source, Destination>(entity);
        }

        public Destination MapViewList<Source, Destination>(Source entities) /*where Source : IEnumerable<Entity>*/
                                                        where Destination : IEnumerable<Dto>
        {
            return (Destination)this.entityFactory.GetList<Source, Destination>(entities);
        }
    }
}