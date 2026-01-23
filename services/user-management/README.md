## Environment config

The database that will be used by the tests and when running the application is controlled by the `DB_PROVIDER` environment variable.
To change this you will have to update the `.env`.
By default the 2 valid `DB_PROVIDER` values are `postgres` and `mssql`.

## Adding a different database provider

If you would like to explore using a different database you will need to do the following:

- Set the `DB_PROVIDER` environment variable to a name of your choice; e.g. `mysql`.
- Add your port to the `.env`; e.g. `DB_PORT_MYSQL=3306`
- Add your new database provider name to the `DatabaseProvider` string union type in `src/envConfig.ts`.
- Add your port to port record in `src/envConfig.ts`;
```typescript
type DatabaseProvider = "postgres" | "mssql" | "mysql"
const DB_PROVIDER = (process.env.DB_PROVIDER ?? "postgres") as DatabaseProvider
const DB_PORT = {
  postgres: process.env.DB_PORT_POSTGRES,
  mssql: process.env.DB_PORT_MSSQL,
  // New database port
  mysql: process.env.DB_PORT_MYSQL,
}[DB_PROVIDER]
```

[Available Knex Dialects](https://github.com/knex/knex/tree/master/lib/dialects)
