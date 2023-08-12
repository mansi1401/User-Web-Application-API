using MediatR;
using User_Web_Application.Application.Queries;
using User_Web_Application.Business.UserDataAccess.Interfaces;
using User_Web_Application.Domain.Models;

namespace User_Web_Application.Application.QueryHandlers
{
    /// <summary>
    /// Query handler to retrieve all users.
    /// </summary>
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<Users>>
    {
        private readonly IUserDataAccess _userDataAccess;

        public GetAllUsersQueryHandler(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        /// <summary>
        /// Handles the retrieval of all users.
        /// </summary>
        /// <param name="request">The GetAllUsersQuery representing the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of Users containing all users retrieved from the database.</returns>
        public async Task<List<Users>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all users from the database using the IUserDataAccess interface.
            return await _userDataAccess.GetAllUsers();
        }
    }
}
