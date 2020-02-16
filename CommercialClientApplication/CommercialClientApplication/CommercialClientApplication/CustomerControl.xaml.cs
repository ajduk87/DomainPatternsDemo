using CommercialClientApplication.DataGridModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace CommercialClientApplication
{
    /// <summary>
    /// Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl : UserControl
    {
        public ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();
        public ICollectionView cvCustomers;

        public CustomerControl()
        {
            InitializeComponent();

            Customer customer = new Customer { Name = "Marko Ivic" };
            Customers.Add(customer);

            cvCustomers = CollectionViewSource.GetDefaultView(Customers);
            if (cvCustomers != null)
            {
                dgCustomerList.ItemsSource = cvCustomers;
            }
        }
    }
}
