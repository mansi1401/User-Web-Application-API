using MediatR;
using User_Web_Application.Domain.Models;

namespace User_Web_Application.Application.Queries
{
    public class GetAllUsersQuery : IRequest<List<Users>>
    {
    }
}
