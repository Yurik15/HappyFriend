namespace HF.Api.REST.Users.Queries
{
    public class GetUserOrdersQuery
    {
        public GetUserOrdersQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }

    public class GetUserOrdersQueryHandler
    {
        //TODO
    }
}
