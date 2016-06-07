using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using twee.thetvdbapi;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace twee.thetvdbapi.test
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".

    public class AuthenticationTest
    {
        private readonly ITestOutputHelper _testOutput;

        public AuthenticationTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void CanGetSecret()
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();



            Assert.Equal("Test", configuration["TestSecret"]);
        }

        [Fact]
        public async Task CanAuthWithTvDbApi()
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();

            var apiKey = configuration["ApiKey"];

            var thetvdbClient = new TheTvDbClient();

            var response = await thetvdbClient.Authentication.Login(apiKey);

            _testOutput.WriteLine(response.Token);
        }

        [Fact]
        public async Task CanAuthWithTvDbApiAndGetSerie()
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();

            var apiKey = configuration["ApiKey"];

            var thetvdbClient = new TheTvDbClient();

            var response = await thetvdbClient.Authentication.Login(apiKey);

            _testOutput.WriteLine(response.Token);

            var serie = await thetvdbClient.Series.GetById(281662, response.Token);

            Assert.Equal("Marvel's Daredevil",serie.Data.SeriesName);
        }

    }



}
