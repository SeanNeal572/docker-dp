import { beforeAll, beforeEach } from "vitest";
import { connect } from "@/repositories/datasource";

beforeAll(async () => {
  await connect().table('user').truncate()
})

beforeEach(async () => {
  await connect().table('user').truncate()
})
