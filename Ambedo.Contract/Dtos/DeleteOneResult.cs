namespace Ambedo.Contract.Dtos
{
    public record DeleteResult

    {
        //
        // Summary:
        //     Gets the deleted count. If IsAcknowledged is false.
        public long DeletedCount { get; init; }
        //
        // Summary:
        //     Gets a value indicating whether the result is acknowledged.
        public bool IsAcknowledged { get; init; }
    }
}
