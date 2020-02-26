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
using CommercialClientApplication.Dtoes;
using CommercialClientApplication.Services;
using CommercialClientApplication.Urls;

namespace CommercialClientApplication
{
    /// <summary>
    /// Interaction logic for ActionControl.xaml
    /// </summary>
    public partial class ActionControl : UserControl
    {

        private readonly RegistrationServices registrationServices = new RegistrationServices();
        private readonly IActionService actionService;

        private readonly ActionUrls urls;

        private readonly IApiCaller apiCaller;

        public ActionControl()
        {
            InitializeComponent();

            this.actionService = registrationServices.Container.Resolve<IActionService>();
        }


        private void BtnEnterProduct_Click_1(object sender, RoutedEventArgs e)
        {
            ActionDto actionDto = new ActionDto
            {
                ProductName = tfenterproduct.Text,
                Discount = Convert.ToDouble("tfenterdiscount.Text"),
                ThresholdAmount = Convert.ToInt32("tfenterthresholdamount.Text")
            };

            this.apiCaller.Post(this.urls.Action, actionDto);
        }

        private void BtnUpdateAction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGetActionInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
