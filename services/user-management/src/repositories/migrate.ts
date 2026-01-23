import path from "path"
import { connect } from "./datasource"

const MIGRATIONS_PATH = path.resolve(__dirname, './migrations')

async function migrate() {
  await connect().migrate.latest({
    directory: MIGRATIONS_PATH,
    extension: 'js',
  })
}

migrate().then(() => process.exit(0))