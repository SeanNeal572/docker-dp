import { User } from "../../../src/types";
import { baseFactory } from "./base.factory";
import { faker } from "@faker-js/faker";

let id = 1
export const userFactory = baseFactory<User>(() => ({
  id: id++,
  name: faker.person.firstName(),
  surname: faker.person.lastName(),
  email: faker.internet.exampleEmail(),
  phoneNumber: faker.phone.number(),
}))
