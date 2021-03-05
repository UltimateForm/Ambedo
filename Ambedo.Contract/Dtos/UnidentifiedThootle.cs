using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ambedo.Contract.Dtos
{
    public record UnidentifiedThootle
    {
        [Required]
        public string Content { get; init; }
        public IEnumerable<ThootleCategories> Categories { get; init; }
    }
}
