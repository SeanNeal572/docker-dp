import { application } from "./application";

application.listenOnHttp(process.argv.some((arg) => arg === '--open-swagger-docs'))
