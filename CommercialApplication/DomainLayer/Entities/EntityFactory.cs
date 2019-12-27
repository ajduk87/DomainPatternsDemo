using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes;
using CommercialApplicationCommand.DomainLayer.Mappings.Entities;
using System.Collections.Generic;

namespace CommercialApplicationCommand.DomainLayer.Entities
{
    public class EntityFactory
    {
        protected readonly IMapper mapper;

        public EntityFactory()
        {
            this.mapper = GenerateMapper();
        }

        private IMapper GenerateMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StorageProfile>();
                cfg.AddProfile<CustomerProfile>();
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<ProductStorageProfile>();
                cfg.AddProfile<InvoicesProfile>();
                cfg.AddProfile<InvoiceItemProfile>();
                cfg.AddProfile<InvoiceItemInvoiceProfile>();
                cfg.AddProfile<InvoiceCustomerProfile>();
                cfg.AddProfile<InvoiceCommercialistProfile>();
                cfg.AddProfile<ActionProfile>();
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<OrderItemProfile>();
                cfg.AddProfile<OrderItemOrderProfile>();
                cfg.AddProfile<OrderCustomerProfile>();
            });

            return mapperConfiguration.CreateMapper();
        }

        public Entity Create<Source, Destination>(Source dto) where Source : Dto
                                                              where Destination : Entity
        {
            return this.mapper.Map<Source, Destination>(dto);
        }

        public Dto Get<Source, Destination>(Source entity) where Source : Entity
                                                             where Destination : Dto
        {
            return this.mapper.Map<Source, Destination>(entity);
        }

        public IEnumerable<Dto> GetList<Source, Destination>(Source entities) where Source : IEnumerable<Entity>
                                                            where Destination : IEnumerable<Dto>
        {
            return this.mapper.Map<Source, Destination>(entities);
        }
    }
}