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
using CommercialClientApplication.Services;

namespace CommercialClientApplication
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        private readonly RegistrationServices registrationServices = new RegistrationServices();
        private readonly IOrderService orderService;

        public OrderControl()
        {
            InitializeComponent();

            this.orderService = registrationServices.Container.Resolve<IOrderService>();
        }
    }
}
