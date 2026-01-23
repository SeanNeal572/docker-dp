import { NextFunction, Request, Response } from "express";

export function errorHandler(error: unknown, _req: Request, res: Response, _next: NextFunction) {
  res.status(500).json({ message: JSON.stringify(error) })
}
