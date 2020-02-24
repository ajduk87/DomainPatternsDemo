﻿using CommercialClientApplication.DataGridModels;
using CommercialClientApplication.Services;
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
using Autofac;
using CommercialClientApplication.Dtoes;
using CommercialClientApplication.Urls;

namespace CommercialClientApplication
{
    /// <summary>
    /// Interaction logic for StorageControl.xaml
    /// </summary>
    public partial class StorageControl : UserControl
    {

        private readonly RegistrationServices registrationServices = new RegistrationServices();
        private readonly IStorageService storageService;


        public ObservableCollection<StorehouseItem> StorehouseItems = new ObservableCollection<StorehouseItem>();
        public ICollectionView cvStorehouseItems;

        private readonly StorageUrls urls;

        private readonly IApiCaller apiCaller;


        public StorageControl()
        {
            InitializeComponent();

            this.storageService = registrationServices.Container.Resolve<IStorageService>();

            //StorehouseItem StorehouseItem = new StorehouseItem
            //{
            //    ProductName = "kafa",
            //    StorageName = "Doncafe Beograd",
            //    Amount = 15
            //};
            //StorehouseItem StorehouseItem2 = new StorehouseItem
            //{
            //    ProductName = "sok od jabuke",
            //    StorageName = "Nectar Beograd",
            //    Amount = 15
            //};

            //StorehouseItems.Add(StorehouseItem);
            //StorehouseItems.Add(StorehouseItem2);

            cvStorehouseItems = CollectionViewSource.GetDefaultView(StorehouseItems);
            if (cvStorehouseItems != null)
            {
                dgStorageState.ItemsSource = cvStorehouseItems;
            }
        }

        private void BtnEnterStorage_Click(object sender, RoutedEventArgs e)
        {
            StorageDto storage = new StorageDto
            {
                Name = tfentername.Text,
                Location = tfenterlocation.Text
            };

            this.apiCaller.Post(this.urls.Product, productDto);
        }

        private void BtnUpdateStorage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGetStorageLocation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGetStorageState_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
