import { application } from "./application";
import { connect } from "./repositories/datasource";
import { MIGRATIONS_PATH } from "./repositories/migrate";

async function bootstrap() {
  await connect().migrate.latest({
    directory: MIGRATIONS_PATH,
    extension: 'js',
  })
  application.listenOnHttp(process.argv.some((arg) => arg === '--open-swagger-docs'))
}

bootstrap()
