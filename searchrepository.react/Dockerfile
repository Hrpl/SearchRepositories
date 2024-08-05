# Используйте официальный образ Node.js как базовый
FROM node:alpine AS builder


# Копируйте файлы проекта в образ
COPY package*.json package.json

# Установите зависимости
RUN npm install

# Копируйте исходный код приложения
COPY . .

# Соберите приложение
RUN npm build

# Используйте официальный образ Nginx для раздачи статического контента
FROM nginx:stable-alpine

# Копируйте собранные файлы приложения в директорию www в контейнере Nginx\
COPY --from=builder /dist /usr/share/nginx/html
COPY --from=builder nginx.conf /etc/nginx/conf.d/default.conf

# Настройте Nginx для прослушивания порта 80
EXPOSE 3000

# Запустите Nginx
CMD ["nginx", "-g", "daemon off;"]