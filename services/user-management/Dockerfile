FROM node:20.12.1-alpine AS builder

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build

FROM node:20.12.1-alpine AS runner

WORKDIR /app

COPY package*.json ./

RUN npm install --omit=dev

COPY package*.json ./
RUN npm install --omit=dev

# Copy ONLY the 'dist' folder from the builder stage
COPY --from=builder /app/dist ./dist

# Start the app
EXPOSE 8080
CMD ["npm", "start"]
