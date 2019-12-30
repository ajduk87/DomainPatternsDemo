using Autofac;
using CommercialApplication.ApplicationLayer.Models.InvoiceItemInvoices;
using CommercialApplication.ApplicationLayer.Models.Invoices;
using CommercialApplication.ApplicationLayer.Models.Order;
using CommercialApplicationCommand.ApplicationLayer.Models.Action;
using CommercialApplicationCommand.ApplicationLayer.Models.Customer;
using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage;
using CommercialApplicationCommand.ApplicationLayer.Models.Storage;
using CommercialApplicationCommand.ApplicationLayer.Validation;
using CommercialApplicationCommand.ApplicationLayer.Validation.Action;
using CommercialApplicationCommand.ApplicationLayer.Validation.Customer;
using CommercialApplicationCommand.ApplicationLayer.Validation.InvoiceItem;
using CommercialApplicationCommand.ApplicationLayer.Validation.InvoiceItemInvoices;
using CommercialApplicationCommand.ApplicationLayer.Validation.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Validation.OderItem;
using CommercialApplicationCommand.ApplicationLayer.Validation.Order;
using CommercialApplicationCommand.ApplicationLayer.Validation.Product;
using CommercialApplicationCommand.ApplicationLayer.Validation.ProductStorage;
using CommercialApplicationCommand.ApplicationLayer.Validation.Storage;
using FluentValidation;

namespace CommercialApplicationCommand.ApplicationLayer.Registration
{
    public class RegistrationValidatorsModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<ValidatorFactory>()
                   .As<IValidatorFactory>()
                   .SingleInstance();

            objContainer.RegisterType<StorageCreateValidator>()
                        .Keyed<IValidator>(typeof(StorageCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<StorageUpdateValidator>()
                        .Keyed<IValidator>(typeof(StorageUpdateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<StorageDeleteValidator>()
                        .Keyed<IValidator>(typeof(StorageDeleteModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<ProductStorageCreateValidator>()
                        .Keyed<IValidator>(typeof(ProductStorageCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<ProductStorageDeleteValidator>()
                        .Keyed<IValidator>(typeof(ProductStorageDeleteModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<CustomerCreateValidator>()
                        .Keyed<IValidator>(typeof(CustomerCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<CustomerUpdateValidator>()
                        .Keyed<IValidator>(typeof(CustomerUpdateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<CustomerDeleteValidator>()
                        .Keyed<IValidator>(typeof(CustomerDeleteModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<ProductCreateValidator>()
                        .Keyed<IValidator>(typeof(ProductCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<ProductUpdateValidator>()
                        .Keyed<IValidator>(typeof(ProductUpdateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<ProductDeleteValidator>()
                        .Keyed<IValidator>(typeof(ProductDeleteModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<InvoicesCreateValidator>()
                        .Keyed<IValidator>(typeof(InvoiceCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<InvoicesDeleteValidator>()
                        .Keyed<IValidator>(typeof(InvoiceDeleteModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<InvoiceItemCreateValidator>()
                        .Keyed<IValidator>(typeof(InvoiceItemCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<InvoiceItemDeleteValidator>()
                        .Keyed<IValidator>(typeof(InvoiceItemDeleteModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<InvoiceItemInvoicesCreateValidator>()
                        .Keyed<IValidator>(typeof(InvoiceItemInvoicesCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<InvoiceItemInvoicesDeleteValidator>()
                        .Keyed<IValidator>(typeof(InvoiceItemInvoicesDeleteModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<ActionCreateValidator>()
                        .Keyed<IValidator>(typeof(ActionCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<ActionUpdateValidator>()
                        .Keyed<IValidator>(typeof(ActionUpdateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<ActionDeleteValidator>()
                        .Keyed<IValidator>(typeof(ActionDeleteModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<ActionUpdateByCustomerValidator>()
                        .Keyed<IValidator>(typeof(ActionCustomerUpdateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<OrderCreateValidator>()
                        .Keyed<IValidator>(typeof(OrderCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<OrderUpdateValidator>()
                        .Keyed<IValidator>(typeof(OrderUpdateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<OrderDeleteValidator>()
                        .Keyed<IValidator>(typeof(OrderDeleteModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<OrderItemCreateValidator>()
                        .Keyed<IValidator>(typeof(OrderItemCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<OrderItemUpdateValidator>()
                        .Keyed<IValidator>(typeof(OrderItemUpdateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            base.Load(objContainer);
        }
    }
}