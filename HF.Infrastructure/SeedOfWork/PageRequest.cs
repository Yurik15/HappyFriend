using System;
namespace HFS.Infrastracture.SeedOfWork
{
    public struct QueryRange
    {
        public static readonly QueryRange Zero = new QueryRange(0, 0);

        public QueryRange(
            int page,
            int size)
        {
            Page = page;
            Size = size;
        }

        public int Page { get; }
        public int Size { get; }

        public static bool operator ==(QueryRange a, QueryRange b) => a.Equals(b);

        public static bool operator !=(QueryRange a, QueryRange b) => !a.Equals(b);

        public override int GetHashCode() => Page + Size;
    }
}
