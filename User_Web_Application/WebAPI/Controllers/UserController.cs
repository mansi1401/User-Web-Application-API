using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Web_Application.Application.Commands;
using User_Web_Application.Application.Queries;
using User_Web_Application.Domain.Models;

namespace User_Web_Application.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>An HTTP response with a list of users on success.</returns>
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            // Retrieves all users using MediatR and GetAllUsersQuery.
            List<Users> AllUsers = await _mediator.Send(new GetAllUsersQuery());

            // Returns an HTTP 200 OK response with the list of users.
            return Ok(AllUsers);
        }


        /// <summary>
        /// Creates a new user and stores it in the database.
        /// </summary>
        /// <param name="users">The user object containing user details.</param>
        /// <returns>
        /// An HTTP response with a boolean value indicating the status of user creation. 
        /// Returns true if the user was created successfully, false otherwise.
        /// </returns>
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(Users users)
        {
            // Sends a CreateUserCommand with the user object to create a new user in the database.
            bool CreateUserStatus = await _mediator.Send(new CreateUserCommand() { Users = users });

            // Returns an HTTP 200 OK response with the status of user creation.
            return Ok(CreateUserStatus);
        }


        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="users">The user object containing updated user details.</param>
        /// <returns>
        /// An HTTP response with a boolean value indicating the status of user update. 
        /// Returns true if the user was updated successfully, false otherwise.
        /// </returns>
        [Route("UpdateUser")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(Users users)
        {
            // Sends an UpdateUserCommand with the user object to update the user in the database.
            bool UpdateUserStatus = await _mediator.Send(new UpdateUserCommand() { Users = users });

            // Returns an HTTP 200 OK response with the status of user update.
            return Ok(UpdateUserStatus);
        }


        /// <summary>
        /// Deletes a user from the database based on the provided user ID.
        /// </summary>
        /// <param name="user_Id">The ID of the user to be deleted.</param>
        /// <returns>
        /// An HTTP response with a boolean value indicating the status of user deletion. 
        /// Returns true if the user was deleted successfully, false otherwise.
        /// </returns>
        [Route("DeleteUser/{user_Id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int user_Id)
        {
            // Sends a DeleteUserCommand with the user ID to delete the user from the database.
            bool DeleteUserStatus = await _mediator.Send(new DeleteUserCommand() { User_Id = user_Id });

            // Returns an HTTP 200 OK response with the status of user deletion.
            return Ok(DeleteUserStatus);
        }
    }
}
