using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using twee.thetvdbapi;
using Microsoft.Extensions.Configuration;

namespace twee.thetvdbapi.test
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".

    public class Class1
    {
        [Fact]
        public void CanAuthWithTvDbApi()
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();



            Assert.Equal("Test", configuration["TestSecret"]);
        }

    }



}
