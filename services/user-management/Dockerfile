FROM node:22.21.1

WORKDIR /app
COPY . .

RUN npm install && npm run build

EXPOSE 8080

CMD ["npm", "run", "start"]

