import { env } from "../envConfig";
import { knex } from "knex";

const knexPool = knex({
  client: env.DB_PROVIDER,
  connection: {
    host: env.DB_HOST,
    port: env.DB_PORT,
    user: env.DB_USER,
    password: env.DB_PASSWORD,
    database: env.DB_DATABASE,
  },
});

export function connect() {
  return knexPool
}
