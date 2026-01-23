## Environment config

The db context that will be used by the tests and when running the application is controlled by the `Db:Provider` config value.
To change this you will have to update the `appsettings.json` in the `DockerDp.Db.Tests` project (for running the tests) and in the `DockerDp.Application` project (for running the api).
By default the 2 valid `Db:Provider` values are `postgres` and `mssql`.

## Adding a different database provider

If you would like to explore using a different database you will need to do the following:

- Create a new project named according to the db you are using; e.g. `DockerDp.Db.MySql`
- Install the relevant entity framework core package; e.g. `Microsoft.EntityFrameworkCore.MySql`
- Create a db context that extends `AppDbContext`; e.g. `class MySqlDbContext : AppDbContext`
- Override your db context's `OnConfiguring`; e.g. `optionsBuilder.UseMySql(connectionString, serverVersion)`
- Generate the EFCore migrations using the package manage console with your new project as the default project - `Add-Migration InitialCreate`
- Set the `Db:Provider` config value to a name of your choice; e.g. `mysql`.
- Add your db context to the `DockerDp.TestInfrastructure.Db.AppDbContextBuilder` and `DockerDp.Application.Program` switch cases with the case value being equal to your chosen config value.
