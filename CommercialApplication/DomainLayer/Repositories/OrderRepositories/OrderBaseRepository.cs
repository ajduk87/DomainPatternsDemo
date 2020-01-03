using CommercialApplication.DomainLayer.Repositories.Commands.Callers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.OrderRepositories
{
    public abstract class OrderBaseRepository
    {
        protected readonly CommandOrderCaller commandOrderCaller;

        public OrderBaseRepository()
        {
            this.commandOrderCaller = new CommandOrderCaller();
        }
    }
}
