using User_Web_Application.Domain.Models;

namespace User_Web_Application.Business.UserDataAccess.Interfaces
{
    public interface IUserDataAccess
    {
        //Get All Users
        Task<List<Users>> GetAllUsers();



        //Get User By Email
        Task<Users> GetUserByEmail(string email);



        //Create User
        Task<bool> CreateUser(Users users);



        //Get User By Id
        Task<Users> GetUserById(int user_Id);



        //Update User
        Task<bool> UpdateUser(Users users);



        //DeleteUser
        Task<bool> DeleteUser(int user_Id);
    }
}
