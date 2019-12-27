using CommercialApplicationCommand.ApplicationLayer.Models.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class LocationData
    {
        public LocationCreateModel SampleCreate;
        public LocationUpdateModel SampleUpdate;
        public LocationDeleteModel SampleDelete;
        public LocationData()
        {
            SampleCreate = new LocationCreateModel
            {
                MarketplaceName = "Sample Marketplace Name",
                SiteName = "Sample Site Name",
                Address = "Sample Address",
                Postalcode = "12345",
                Pib = "123456789",
                IdNumber = "1234",
                Work = "Sample work",
                DomicileBankAccount = "123-4567891011121-48",
                ChanelSales = "Sample",
                IsAvailableForSelling = true,
                IsContainHyphen = true
            };

            SampleUpdate = new LocationUpdateModel
            {
                MarketplaceName = "Sample Marketplace Name Update",
                SiteName = "Sample Site Name",
                Address = "Sample Address",
                Postalcode = "12345",
                Pib = "123456789",
                IdNumber = "1234",
                Work = "Sample work",
                DomicileBankAccount = "123-4567891011121-48",
                ChanelSales = "Sample",
                IsAvailableForSelling = true,
                IsContainHyphen = true
            };

            SampleDelete = new LocationDeleteModel();
        }
    }
}
