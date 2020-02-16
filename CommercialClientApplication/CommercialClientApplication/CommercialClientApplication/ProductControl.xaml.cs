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
using CommercialClientApplication.Urls;
using CommercialClientApplication.Dtoes;

namespace CommercialClientApplication
{
    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        private readonly RegistrationServices registrationServices = new RegistrationServices();
        private readonly IProductService productService;

        private readonly ProductUrls urls;

        private readonly IApiCaller apiCaller;

        public ProductControl()
        {
            InitializeComponent();

            this.productService = registrationServices.Container.Resolve<IProductService>();

            this.urls = new ProductUrls();

            this.apiCaller = registrationServices.Container.Resolve<IApiCaller>();
        }

        private void BtnEnterProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductDto productDto = new ProductDto
            {
                Name = tfentername.Text,
                UnitCost = new UnitCostDto
                {
                    Value = Convert.ToDouble(tfenterunitcost.Text.Split(' ')[0]),
                    Currency = tfenterunitcost.Text.Split(' ')[1]
                },
                Description = tfenterdescription.Text,
                ImageUrl = tfenterimageurl.Text,
                VideoLink = tfentervideolink.Text,
                SerialNumber = tfenterserialnumber.Text,
                KindOfProduct = tfenterkindofproduct.Text
            };

            this.apiCaller.Post(this.urls.Product, productDto);
        }

        private void BtnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGetProductInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEnterProductInStorage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
