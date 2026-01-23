type DatabaseProvider = "postgres" | "mssql"
const DB_PROVIDER = (process.env.DB_PROVIDER ?? "postgres") as DatabaseProvider
const DB_PORT = {
  postgres: process.env.DB_PORT_POSTGRES,
  mssql: process.env.DB_PORT_MSSQL,
}[DB_PROVIDER]

export const env = {
  DB_PROVIDER: DB_PROVIDER,
  DB_HOST: process.env.DB_HOST ?? "",
  DB_PORT: Number(DB_PORT ?? ""),
  DB_USER: process.env.DB_USER ?? "",
  DB_PASSWORD: process.env.DB_PASSWORD ?? "",
  DB_DATABASE: process.env.DB_DATABASE ?? "",
} as const
