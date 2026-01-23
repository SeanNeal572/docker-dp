import type { Knex } from "knex";

export function up(knex: Knex) {
  return knex.schema.createTable('user', (table) => {
    table.increments('id', { primaryKey: true })
    table.string('name')
    table.string('surname')
    table.string('email')
    table.string('phoneNumber')
  })
}

export function down(knex: Knex) {
  return knex.schema.dropTable('user')
}
