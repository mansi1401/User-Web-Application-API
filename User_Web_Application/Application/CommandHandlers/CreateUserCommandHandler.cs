using MediatR;
using User_Web_Application.Application.Commands;
using User_Web_Application.Business.UserDataAccess.Interfaces;
using User_Web_Application.Domain.Models;

namespace User_Web_Application.Application.CommandHandlers
{
    /// <summary>
    /// Command handler to create a new user.
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserDataAccess _userDataAccess;

        public CreateUserCommandHandler(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        /// <summary>
        /// Handles the creation of a new user.
        /// </summary>
        /// <param name="request">The CreateUserCommand containing user details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the user was created successfully, false otherwise.</returns>
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Check if a user with the same email already exists.
            Users existingUser = await _userDataAccess.GetUserByEmail(request.Users.Email);

            if (existingUser == null)
            {
                // Create a new user object with the provided details.
                Users newUser = new Users()
                {
                    Name = request.Users.Name,
                    Email = request.Users.Email,
                    Password_Hash = request.Users.Password_Hash,
                };

                // Persist the new user into the database using the IUserDataAccess interface.
                return await _userDataAccess.CreateUser(newUser);
            }
            else
            {
                // A user with the same email already exists, so return false to indicate failure.
                return false;
            }
        }
    }
}
