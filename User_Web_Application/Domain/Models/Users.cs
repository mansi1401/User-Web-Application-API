namespace User_Web_Application.Domain.Models
{
    /// <summary>
    /// Represents the model for storing user-related information.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int User_Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user.
        /// </summary>
        public string Password_Hash { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active or not.
        /// </summary>
        public bool Is_Active { get; set; }
    }
}
