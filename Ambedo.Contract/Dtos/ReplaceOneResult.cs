namespace Ambedo.Contract.Dtos
{
    public record ReplaceOneResult
    {
        //
        // Summary:
        //     Gets a value indicating whether the result is acknowledged.
        public bool IsAcknowledged { get; init; }

        //
        // Summary:
        //     Gets the matched count.
        public long MatchedCount { get; init; }

        //
        // Summary:
        //     Gets the modified count.
        public long ModifiedCount { get; init; }
    }
}
