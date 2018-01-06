using Microsoft.AspNetCore.Mvc;
using netcore_nest_performance.Configurations.Search;
using Nest;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using netcore_nest_performance.Configurations.Models;

namespace netcore_nest_performance.Controllers
{
    public class HomeController : Controller
    {
        private SearchConnectionConfiguration _searchConnectionConfiguration;
        private SearchServiceModel _searchServiceModel;
        public HomeController(IOptions<SearchServiceModel> elastic, SearchConnectionConfiguration settings)
        {
            _searchServiceModel = elastic.Value;
            _searchConnectionConfiguration = settings;
        }

        public ContentResult Index()
        {
            return Content("Netcore - Nest Performance");
        }

        public ContentResult Singleton()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var esClient = new ElasticClient(_searchConnectionConfiguration.Settings);
            var query = Query<Models.Content>.Match(m => m.Field(f => f.ContentText).Query("therefore"));
            var searchResults = esClient.Search<Models.Content>(c => c
                            .From(0)
                            .Size(10)
                            .Query(x => query)
                        );
            sw.Stop();
            return Content(sw.Elapsed.TotalMilliseconds.ToString());
        }

        public ContentResult PerRequest()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var searchConnectionConfiguration = new SearchConnectionConfiguration(_searchServiceModel);
            var esClient = new ElasticClient(searchConnectionConfiguration.Settings);
            var query = Query<Models.Content>.Match(m => m.Field(f => f.ContentText).Query("therefore"));
            var searchResults = esClient.Search<Models.Content>(c => c
                            .From(0)
                            .Size(10)
                            .Query(x => query)
                        );
            sw.Stop();
            return Content(sw.Elapsed.TotalMilliseconds.ToString());
        }
    }
}
