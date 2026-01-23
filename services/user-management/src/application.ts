import express, { Express } from 'express'
import { userController } from './controllers/user.controller'
import swaggerUi from 'swagger-ui-express'
import swaggerDocument from "../swagger.json"
import { usersController } from './controllers/users.controller'
import { errorHandler } from './controllers/util'
import { devController } from './controllers/dev.controller'

const api = express()

api.use(express.json())
api.use(errorHandler)
userController.attach(controllerAttacher)
usersController.attach(controllerAttacher)
devController.attach(controllerAttacher)

function controllerAttacher(controller: Express, path: string) {
  api.use(`/api/${path}`, controller)
}

api.use('/swagger', swaggerUi.serve, swaggerUi.setup(swaggerDocument))

export const application = {
  listenOnHttp(openSwaggerDocs: boolean) {
    const port = 8080
    api.listen(port, () => {
      console.log(`HTTP listening on port ${port}`)
      const swaggerUrl = `http://localhost:${port}/swagger`
      if (openSwaggerDocs) void import("open").then((open) => open.default(swaggerUrl))
      console.log(`Swagger docs - ${swaggerUrl}`)
    })
  }
}

