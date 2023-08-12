- Application/
    - Commands/
        - CreateUser/
            - CreateUserCommand.cs
        - UpdateUser/
            - UpdateUserCommand.cs
        - DeleteUser/
            - DeleteUserCommand.cs
			
    - Queries/
        - GetUserById/
            - GetUserByIdQuery.cs
		- GetUserByEmail/
			GetUserByEmailQuery.cs
        - GetAllUsers/
            - GetAllUsersQuery.cs
			
    - CommandHandlers/
        - CreateUserCommandHandler.cs
        - UpdateUserCommandHandler.cs
        - DeleteUserCommandHandler.cs
		
    - QueryHandlers/
        - GetUserByIdQueryHandler.cs
		- GetUserByEmailHandler.cs
        - GetAllUsersQueryHandler.cs

- Domain/
    - Models/
        - User.cs

- Exceptions/
	

- Infrastructure/
    - Data/
        - DbContext.cs          // The DbContext implementation
		
		
- Business
	- UserDataAccess.cs		
	- Interfaces/
		- IUserDataAccess.cs

- WebAPI/
    - Controllers/
        - UserController.cs
		- LoginController.cs


# Dependencies

- MediatR.Extensions.Microsoft.DependencyInjection
- System.Data.SqlClient 
- Dapper


# Program Configuration

// Add MediatR for handling commands and queries
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Add CORS (Cross-Origin Resource Sharing) support
builder.Services.AddCors();

// Allow any origin, method, and header for CORS
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


# Connection String
```
"ConnectionStrings": {
    "DefaultConnection": "Server=MAAN;Database=MANSI_Local;Trusted_Connection=True"
}
```

# Access Connection String from Repository

```
private readonly string _connectionString;

public DbContext(IConfiguration configuration)
{
    _connectionString = configuration.GetConnectionString("DefaultConnection");
}

public IDbConnection CreateConnection()
{
    return new SqlConnection(_connectionString);
}

public IDbConnection GetOpenConnection()
{
    var connection = CreateConnection();
    connection.Open();
    return connection;
}

```

## Routes

### Get All Employee

* `Get`

### Get Employee By Id

* `Details/{id}`

### Get Employee By Email

* `Details/{email}`

### Add Employee

* `Create`

### Edit Employee

* `Edit/{id:int}`

### Delete Employee

* `Delete/{id}`
