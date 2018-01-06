using Nest;

namespace netcore_nest_performance.Models
{
    [ElasticsearchType(Name = "content")]
    public class Content : BaseType
    {
        /// <summary>
        ///     Content Text
        /// </summary>
        [Text(Name = "content_text")]
        public string ContentText { get; set; }
    }
}
