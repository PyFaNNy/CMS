using MediatR;

namespace CMS.Application.Aggregates.User.Queries.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public Guid UserId { get; set; }
    }
}
