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
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        private readonly RegistrationServices registrationServices = new RegistrationServices();
        private readonly IProductService productService;

        public ProductControl()
        {
            InitializeComponent();

            this.productService = registrationServices.Container.Resolve<IProductService>();
        }
    }
}
