using CommercialClientApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autofac;

namespace CommercialClientApplication
{
    /// <summary>
    /// Interaction logic for InvoiceControl.xaml
    /// </summary>
    public partial class InvoiceControl : UserControl
    {
        private readonly RegistrationServices registrationServices = new RegistrationServices();
        private readonly IInvoiceService invoiceService;


        public InvoiceControl()
        {
            InitializeComponent();

            this.invoiceService = registrationServices.Container.Resolve<IInvoiceService>();
        }

        private void BtnGetOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMakeInvoice_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
