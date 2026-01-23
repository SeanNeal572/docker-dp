import path from "node:path";
import { defineConfig } from "vitest/config";

export default defineConfig({
  test: {
    dir: path.resolve(__dirname, "test"),
    setupFiles: ["./test/setup/database.ts"],
    alias: {
      "@": path.resolve(__dirname, "src")
    }
  },
});
