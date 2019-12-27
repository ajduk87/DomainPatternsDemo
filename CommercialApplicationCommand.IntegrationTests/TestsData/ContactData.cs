using CommercialApplicationCommand.ApplicationLayer.Models.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
     public class ContactData
    {
        public ContactCreateModel SampleCreate;
        public ContactUpdateModel SampleUpdate;
        public ContactDeleteModel SampleDelete;

        public ContactData()
        {
            this.SampleCreate = new ContactCreateModel
            {
                Email = "sample.mail@email.com",
                Phone = "116189161",
            };

            this.SampleUpdate = new ContactUpdateModel
            {
                Phone = "181998187",
                Email = "updated.email@hotmail.com"
            };

            this.SampleDelete = new ContactDeleteModel();
        }
    }
}
