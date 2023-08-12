using MediatR;

namespace User_Web_Application.Application.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int User_Id { get; set; }
    }
}
