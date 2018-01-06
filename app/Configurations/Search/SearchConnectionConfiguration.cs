using Nest;
using netcore_nest_performance.Configurations.Models;
using System;

namespace netcore_nest_performance.Configurations.Search
{
    public class SearchConnectionConfiguration
    {
        public ConnectionSettings Settings { get; private set; }

        public SearchConnectionConfiguration(SearchServiceModel elasticConfiguration)
        {
            var uriBuilder = new UriBuilder
            {
                Host = elasticConfiguration.Host,
                Port = elasticConfiguration.Port
            };
            Settings = new ConnectionSettings(uriBuilder.Uri);
            Settings.DefaultIndex(elasticConfiguration.IndexName);
        }
    }
}
