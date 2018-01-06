using Nest;
using System;

namespace netcore_nest_performance.Models
{
    public class BaseType
    {
        /// <summary>
        ///     _id
        /// </summary>
        [Keyword(Name = "id")]
        public string Id => Guid.NewGuid().ToString("N");
    }
}
