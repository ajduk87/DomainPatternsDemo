using Autofac;
using CommercialApplicationCommand.DomainLayer.Services.ActionServices;
using CommercialApplicationCommand.DomainLayer.Services.CustomerServices;
using CommercialApplicationCommand.DomainLayer.Services.InvoicesServices;
using CommercialApplicationCommand.DomainLayer.Services.OrderServices;
using CommercialApplicationCommand.DomainLayer.Services.ProductServices;
using CommercialApplicationCommand.DomainLayer.Services.StorageServices;

namespace CommercialApplicationCommand.DomainLayer.Registration.Services
{
    public class RegistrationModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {

            objContainer.RegisterType<ProductService>()
                        .Keyed<IProductService>(typeof(ProductService))
                        .As<IProductService>();

            objContainer.RegisterType<StorageService>()
                        .Keyed<IStorageService>(typeof(StorageService))
                        .As<IStorageService>();

            objContainer.RegisterType<ProductStorageService>()
                        .Keyed<IProductStorageService>(typeof(ProductStorageService))
                        .As<IProductStorageService>();

            objContainer.RegisterType<CustomerService>()
                        .Keyed<ICustomerService>(typeof(CustomerService))
                        .As<ICustomerService>();

            objContainer.RegisterType<InvoiceService>()
                        .Keyed<IInvoiceService>(typeof(InvoiceService))
                        .As<IInvoiceService>();

            objContainer.RegisterType<InvoiceItemService>()
                        .Keyed<IInvoiceItemService>(typeof(InvoiceItemService))
                        .As<IInvoiceItemService>();

            objContainer.RegisterType<InvoiceItemInvoiceService>()
                        .Keyed<IInvoiceItemInvoiceService>(typeof(InvoiceItemInvoiceService))
                        .As<IInvoiceItemInvoiceService>();

            objContainer.RegisterType<InvoiceCustomerService>()
                        .Keyed<IInvoiceCustomerService>(typeof(InvoiceCustomerService))
                        .As<IInvoiceCustomerService>();

            objContainer.RegisterType<ActionService>()
                        .Keyed<IActionService>(typeof(ActionService))
                        .As<IActionService>();

            objContainer.RegisterType<OrderService>()
                        .Keyed<IOrderService>(typeof(OrderService))
                        .As<IOrderService>();

            objContainer.RegisterType<OrderItemService>()
                        .Keyed<IOrderItemService>(typeof(OrderItemService))
                        .As<IOrderItemService>();

            objContainer.RegisterType<OrderCustomerService>()
                        .Keyed<IOrderCustomerService>(typeof(OrderCustomerService))
                        .As<IOrderCustomerService>();

            objContainer.RegisterType<OrderItemOrderService>()
                        .Keyed<IOrderItemOrderService>(typeof(OrderItemOrderService))
                        .As<IOrderItemOrderService>();

            base.Load(objContainer);
        }
    }
}