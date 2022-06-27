using MediatR;

namespace CMS.Application.Aggregates.User.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email
        {
            get;
            set;
        }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
