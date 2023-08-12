using MediatR;
using User_Web_Application.Domain.Models;

namespace User_Web_Application.Application.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public Users Users { get; set; }
    }
}
