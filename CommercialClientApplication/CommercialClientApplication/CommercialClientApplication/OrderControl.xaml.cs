using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CommercialClientApplication.Dtoes;
using CommercialClientApplication.Services;
using CommercialClientApplication.Urls;

namespace CommercialClientApplication
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        private readonly RegistrationServices registrationServices = new RegistrationServices();
        private readonly IOrderService orderService;

        private readonly OrderUrls urls;
        private IApiCaller apiCaller;

        private readonly ObservableCollection<OrderItemDto> orderItemDtoes;

        public OrderControl()
        {
            InitializeComponent();

            this.orderService = registrationServices.Container.Resolve<IOrderService>();

            this.urls = new OrderUrls();

            this.apiCaller = registrationServices.Container.Resolve<IApiCaller>();
            this.orderItemDtoes = new ObservableCollection<OrderItemDto>();
        }

        private void BtnFinishOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderDto orderDto = new OrderDto
            {
                CustomerName = tfentercustomername.Text,
                OrderItems = this.orderItemDtoes
            };

            this.apiCaller.Post(this.urls.Order, orderDto);

            this.orderItemDtoes.Clear();
        }

        private void BtnGetOrderInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEnterOrderItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
