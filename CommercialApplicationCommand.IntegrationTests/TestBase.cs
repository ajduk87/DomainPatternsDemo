using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests
{

    public abstract class TestBase
    {
        protected IApiCaller apiCaller;
        public TestBase()
        {
            this.apiCaller = new ApiCaller();
        }
    }
}
