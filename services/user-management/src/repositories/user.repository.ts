import { User } from "../types";
import { connect } from "./datasource";
import { first } from "lodash";

export async function getUsers() {
  return await connect().table("user").select("*")
}

export async function getUserById(id: number) {
  return await connect().table("user").select("*").where({ id }).first()
}

export async function createUser(details: Omit<User, "id">) {
  const createdStudents = await connect().table("user").insert(details).returning("*")
  return first(createdStudents)
}

export async function updateUser({ id, ...details }: Partial<User> & Pick<User, 'id'>) {
  const updatedUsers = await connect().table("user").update(details).where({ id }).returning("*")
  return first(updatedUsers)
}

export async function removeUser(id: number) {
  await connect().table("user").delete().where({ id })
}
