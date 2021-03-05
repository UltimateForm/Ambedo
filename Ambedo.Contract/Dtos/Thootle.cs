using System.Collections.Generic;

namespace Ambedo.Contract.Dtos
{
    public enum ThootleCategories
    {
        Admiration,
        Adoration,
        AestheticAppreciation,
        Amusement,
        Anxiety,
        Awe,
        Awkwardness,
        Boredom,
        Calmness,
        Confusion,
        Craving,
        Disgust,
        EmpatheticPain,
        Entrancement,
        Envy,
        Excitement,
        Fear,
        Horror,
        Interest,
        Joy,
        Nostalgia,
        Romance,
        Sadness,
        Satisfaction,
        SexualDesire,
        Sympathy,
        Triumph
    }
    public record Thootle
    {
        public string Id { get; init; }
        public string Content { get; init; }
        public IEnumerable<ThootleCategories> Categories { get; init; }
    }
}
