import express, { Express } from "express"
import * as userRepository from "@/repositories/user.repository"
import { User } from "../types"

const controller = express()

controller.get("/:userId", async (req, res, next) => {
  try {
    const { userId } = req.params
    const user = await userRepository.getUserById(Number(userId))
    if (user) {
      res.status(200).json(user)
    } else {
      res.status(404).json({ message: "User not found" })
    }
  } catch {
    next("An unexpected error has occurred")
  }
})

controller.patch("/:userId", async (req, res, next) => {
  try {
    const { userId } = req.params
    const request = req.body as Partial<Omit<User, 'id'>>
    const user = await userRepository.updateUser({ id: Number(userId), ...request })
    if (user) {
      res.status(200).json(user)
    } else {
      res.status(404).json({ message: "User not found" })
    }
  } catch {
    next("An unexpected error has occurred")
  }
})

controller.patch("/:userId", async (req, res, next) => {
  try {
    const { userId } = req.params
    await userRepository.removeUser(Number(userId))
    res.status(200).json({ message: "Successfully removed user" })
  } catch {
    next("An unexpected error has occurred")
  }
})


export const userController = {
  attach: (attacher: (controller: Express, path: string) => void) => attacher(controller, "user")
}
