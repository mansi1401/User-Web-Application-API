using MediatR;
using User_Web_Application.Application.Commands;
using User_Web_Application.Business.UserDataAccess.Interfaces;
using User_Web_Application.Domain.Models;

namespace User_Web_Application.Application.CommandHandlers
{
    /// <summary>
    /// Command handler to delete a user.
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserDataAccess _userDataAccess;

        public DeleteUserCommandHandler(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        /// <summary>
        /// Handles the deletion of a user.
        /// </summary>
        /// <param name="request">The DeleteUserCommand containing the user ID to be deleted.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the user was deleted successfully, false otherwise.</returns>
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the user to be deleted based on the provided user ID.
            Users userToDelete = await _userDataAccess.GetUserById(request.User_Id);

            if (userToDelete == null)
            {
                // If the user with the given ID does not exist, return false to indicate failure.
                return false;
            }
            else
            {
                // Delete the user from the database using the IUserDataAccess interface.
                return await _userDataAccess.DeleteUser(request.User_Id);
            }
        }
    }
}
