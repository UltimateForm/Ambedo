using System;
using System.Collections.Generic;
using System.Text;

namespace Ambedo.Contract.Dtos
{
    public class ThootleFilter
    {
        public string Content { get; init; }
        public IEnumerable<ThootleCategories> Categories { get; init; }
    }
}
