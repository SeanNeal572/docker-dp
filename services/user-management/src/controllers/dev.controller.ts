import express, { Express } from "express"
import { connect } from "@/repositories/datasource"

const controller = express()

controller.post("/test-connection", async (_req, res) => {
  try {
    await connect().raw('select 1+1 as result')
    res.status(200).json({ message: "Successfully connected to database" })
  } catch {
    res.status(500).json({ message: "Failed to connect to database" })
  }
})

export const devController = {
  attach: (attacher: (controller: Express, path: string) => void) => attacher(controller, "dev")
}
