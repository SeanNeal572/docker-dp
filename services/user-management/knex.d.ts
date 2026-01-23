import type { Knex } from "knex";

declare module "knex/types/tables" {
  type User = import("../types").User;

  interface Tables {
    user: Knex.CompositeTableType<User, Omit<User, "id">, Omit<User, "id">>;
  }
}
