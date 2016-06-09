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

        [Theory]
        [InlineData(281662, "Marvel's Daredevil")]
        [InlineData(114701,"The League")]
        [InlineData(138531, "Solsidan")]
        public async Task CanAuthWithTvDbApiAndGetSerie(int serieid,string seriename)
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();

            var apiKey = configuration["ApiKey"];

            var thetvdbClient = new TheTvDbClient();

            var response = await thetvdbClient.Authentication.Login(apiKey);

            _testOutput.WriteLine(response.Token);

            var serie = await thetvdbClient.Series.GetById(serieid, response.Token);

            Assert.Equal(seriename, serie.Data.SeriesName);
        }

        [Theory]
        [InlineData(281662)]
        [InlineData(114701)]
        [InlineData(138531)]
        public async Task CanAuthWithTvDbApiAndGetEpisodes(int serieid)
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();

            var apiKey = configuration["ApiKey"];

            var thetvdbClient = new TheTvDbClient();

            var response = await thetvdbClient.Authentication.Login(apiKey);

            _testOutput.WriteLine(response.Token);

            var episodes = await thetvdbClient.Series.GetEpisodesBySerieId(serieid, response.Token);

            Assert.True(episodes.Data.Any());
        }

        [Theory]
        [InlineData(281662)]
        [InlineData(114701)]
        [InlineData(138531)]
        public async Task CanAuthWithTvDbApiAndGetActors(int serieid)
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();

            var apiKey = configuration["ApiKey"];

            var thetvdbClient = new TheTvDbClient();

            var response = await thetvdbClient.Authentication.Login(apiKey);

            _testOutput.WriteLine(response.Token);

            var episodes = await thetvdbClient.Series.GetActorsBySerieId(serieid, response.Token);

            Assert.True(episodes.Data.Any());
        }

        [Theory]
        [InlineData(281662)]
        [InlineData(114701)]
        [InlineData(138531)]
        public async Task CanAuthWithTvDbApiAndGetImageSummary(int serieid)
        {
            var builder = new ConfigurationBuilder()
                                         .AddEnvironmentVariables()
                                .AddUserSecrets("aspnet-twee-thetvdb-api-asdasdasd-shr4e63-asdad-9b77-235245212");


            var configuration = builder.Build();

            var apiKey = configuration["ApiKey"];

            var thetvdbClient = new TheTvDbClient();

            var response = await thetvdbClient.Authentication.Login(apiKey);

            _testOutput.WriteLine(response.Token);

            var episodes = await thetvdbClient.Series.GetImageSummaryBySerieId(serieid, response.Token);

            Assert.NotEqual(0,episodes.Data.Poster);
        }
    }
}
