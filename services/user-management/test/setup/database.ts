import { afterAll, beforeAll, beforeEach } from "vitest";
import { connect } from "@/repositories/datasource";
import { MIGRATIONS_PATH } from "@/repositories/migrate";

beforeAll(async () => {
  await connect().migrate.latest({
    directory: MIGRATIONS_PATH,
    extension: 'ts',
  })
  await connect().table('user').truncate()
})

beforeEach(async () => {
  await connect().table('user').truncate()
})

afterAll(async () => {
  await connect().migrate.rollback({
    directory: MIGRATIONS_PATH,
    extension: 'ts',
  }, true)
})
