using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;
using Xunit.Abstractions;

namespace twee.thetvdbapi.test
{
    public class TvTheDbClientTest
    {
        private readonly ITestOutputHelper _testOutput;

        public TvTheDbClientTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
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

            Assert.Equal("Marvel's Daredevil", serie.Data.SeriesName);
        }

        [Fact]
        public async Task CanAuthWithTvDbApiAndGetEpisodes()
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();

            var apiKey = configuration["ApiKey"];

            var thetvdbClient = new TheTvDbClient();

            var response = await thetvdbClient.Authentication.Login(apiKey);

            _testOutput.WriteLine(response.Token);

            var episodes = await thetvdbClient.Series.GetEpisodesBySerieId(281662, response.Token);

            Assert.True(episodes.Data.Any());
        }

        [Fact]
        public async Task CanAuthWithTvDbApiAndGetActors()
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();

            var apiKey = configuration["ApiKey"];

            var thetvdbClient = new TheTvDbClient();

            var response = await thetvdbClient.Authentication.Login(apiKey);

            _testOutput.WriteLine(response.Token);

            var episodes = await thetvdbClient.Series.GetActorsBySerieId(281662, response.Token);

            Assert.True(episodes.Data.Any());
        }

        [Fact]
        public async Task CanAuthWithTvDbApiAndGetImageSummary()
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();

            var apiKey = configuration["ApiKey"];

            var thetvdbClient = new TheTvDbClient();

            var response = await thetvdbClient.Authentication.Login(apiKey);

            _testOutput.WriteLine(response.Token);

            var episodes = await thetvdbClient.Series.GetImageSummaryBySerieId(281662, response.Token);

            Assert.NotEqual(0,episodes.Data.Poster);
        }
    }
}
