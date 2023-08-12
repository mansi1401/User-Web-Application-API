using MediatR;
using Microsoft.AspNetCore.Identity;
using User_Web_Application.Application.Commands;
using User_Web_Application.Business.UserDataAccess.Interfaces;
using User_Web_Application.Domain.Models;

namespace User_Web_Application.Application.CommandHandlers
{
    /// <summary>
    /// Command handler to update a user.
    /// </summary>
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserDataAccess _userDataAccess;

        public UpdateUserCommandHandler(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        /// <summary>
        /// Handles the update of a user.
        /// </summary>
        /// <param name="request">The UpdateUserCommand containing updated user details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the user was updated successfully, false otherwise.</returns>
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the user to be updated based on the provided user ID.
            Users userToUpdate = await _userDataAccess.GetUserById(request.Users.User_Id);

            if (userToUpdate == null)
            {
                // If the user with the given ID does not exist, return false to indicate failure.
                return false;
            }

            // Update the user's properties with the new values from the request.
            userToUpdate.Name = request.Users.Name;
            userToUpdate.Email = request.Users.Email;
            userToUpdate.Password_Hash = request.Users.Password_Hash;

            // Persist the updated user into the database using the IUserDataAccess interface.
            return await _userDataAccess.UpdateUser(userToUpdate);
        }
    }
}
