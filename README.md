# Open Nuget Console

Change connection string in appsettings.json

In Visual Studio go to Tools >> NuGet Package Manager >> Package Manager Console


# In the console select Default project, select SecurityApp.Infrastructure

# Execute this command
add-migration -context SecurityAppDbContext firstMigration


# Execute this command
update-databse


# In the console select Default project, select SecurityApp.Identity

# Execute this command
add-migration -context IdentityTestDbContext firstMigration


# Execute this command
update-databse
