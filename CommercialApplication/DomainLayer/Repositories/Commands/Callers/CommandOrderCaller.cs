using CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands;
using CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderCustomerCommands;
using CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderItemOrderCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.Callers
{
    public class CommandOrderCaller
    {
        public Dictionary<string, IOrderCommand> DictCommands { get; set; }
        public CommandOrderCaller()
        {
            DictCommands = new Dictionary<string, IOrderCommand>();
            //OrderItem
            DictCommands.Add("DeleteOrderItemById", new DeleteOrderItemByIdCommand());
            DictCommands.Add("DeleteOrderItemByIds", new DeleteOrderItemByIdsCommand());
            DictCommands.Add("GetOrderItemById", new GetOrderItemByIdCommand());
            DictCommands.Add("GetOrderItemByIds", new GetOrderItemByIdsCommand());
            DictCommands.Add("IncludeDiscountForPaying", new IncludeDiscountForPayingCommand());
            DictCommands.Add("InsertListOrderItem", new InsertListOrderItemCommand());
            DictCommands.Add("InsertOrderItem", new InsertOrderItemCommand());
            DictCommands.Add("UpdateListOrderItem", new UpdateListOrderItemCommand());
            DictCommands.Add("UpdateOrderItem", new UpdateOrderItemCommand());

            //OrderItemOrder
            DictCommands.Add("DeleteOrderItemOrder", new DeleteOrderItemOrderCommand());
            DictCommands.Add("InsertOrderItemOrder", new InsertOrderItemOrderCommand());
            DictCommands.Add("GetOrderItemOrderByOrderId", new GetOrderItemsOrderByOrderIdCommand());

            //OrderCustomer
            DictCommands.Add("DeleteOrderCustomer", new DeleteOrderCustomerCommand());
            DictCommands.Add("UpdateOrderCustomer", new UpdateOrderCustomerCommand());
            DictCommands.Add("InsertOrderCustomer", new InsertOrderCustomerCommand());
            DictCommands.Add("GetOrderOrderByOrderId", new GetOrderItemsOrderByOrderIdCommand());

            //Order
            DictCommands.Add("DeleteOrder", new DeleteOrderCommand());
            DictCommands.Add("UpdateOrder", new UpdateOrderCommand());
            DictCommands.Add("InsertOrder", new InsertOrderCommand());
            DictCommands.Add("GetOrderById", new GetOrderByIdCommand());
            DictCommands.Add("GetOrdersByDay", new GetOrdersByDayCommand());
        }
    }
}
