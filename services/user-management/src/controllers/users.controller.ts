import express, { Express } from "express"
import * as userRepository from "@/repositories/user.repository"
import { User } from "@/types"

const controller = express()

controller.get("/", async (_, res, next) => {
  try {
    const users = await userRepository.getUsers()
    res.status(200).json(users)
  } catch {
    next("An unexpected error has occurred")
  }
})

controller.post("/", async (req, res, next) => {
  try {
    const request = req.body as Omit<User, 'id'>
    const user = await userRepository.createUser(request)
    res.status(201).json(user)
  } catch {
    next("An unexpected error has occurred")
  }
})

export const usersController = {
  attach: (attacher: (controller: Express, path: string) => void) => attacher(controller, "users")
}
