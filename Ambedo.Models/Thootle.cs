using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Ambedo.Models
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
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; init; }
        public string Content { get; init; }
        public IEnumerable<ThootleCategories> Categories { get; init; }
    }
}
