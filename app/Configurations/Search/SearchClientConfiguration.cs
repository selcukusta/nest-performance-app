using Nest;
using netcore_nest_performance.Configurations.Enums;
using netcore_nest_performance.Models;
using System.Collections.Generic;
using System.Linq;

namespace netcore_nest_performance.Configurations.Search
{
    public class SearchClientConfiguration
    {
        public ElasticClient ElasticClient { get; private set; }
        public SearchClientConfiguration(SearchConnectionConfiguration settings)
        {
            ElasticClient = new ElasticClient(settings.Settings);
        }

        public bool AddBulkData<T>(IList<T> contents) where T : BaseType, new()
        {
            if (contents == null || !contents.Any())
            {
                return false;
            }

            List<IBulkOperation> operations = new List<IBulkOperation>();
            operations.AddRange(contents.Select(c => new BulkUpdateOperation<T, T>(c, c, true)));

            var request = new BulkRequest()
            {
                Refresh = Elasticsearch.Net.Refresh.True,
                Operations = operations
            };

            var response = ElasticClient.Bulk(request);
            return !response.Errors;
        }

        public IndexStatus CreateIndex<T>() where T : BaseType, new()
        {
            if (ElasticClient.IndexExists(ElasticClient.ConnectionSettings.DefaultIndex).Exists)
            {
                return IndexStatus.AlreadyExists;
            }

            var defaultAnalyzer = new CustomAnalyzer
            {
                Filter = new List<string> { "lowercase", "asciifolding", "word_delimiter" },
                CharFilter = new List<string> { "html_strip" },
                Tokenizer = "standard"
            };

            var createIndexResponse = ElasticClient.CreateIndex(ElasticClient.ConnectionSettings.DefaultIndex, 
                config => config.Settings(s => s
                    .NumberOfShards(1)
                    .NumberOfReplicas(0)
                    .Analysis(a => a
                        .Analyzers(b => b
                        .UserDefined("default", defaultAnalyzer)
                    )
                ))
                .Mappings(m => m
                    .Map<T>(d => d
                        .AutoMap()
                    )
                ));

            return createIndexResponse.Acknowledged ? IndexStatus.Created : IndexStatus.Failed;
        }
    }
}
