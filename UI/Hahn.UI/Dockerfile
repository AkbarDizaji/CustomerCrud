#stage 1
FROM node:19.2 as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod
#stage 2
FROM nginx:alpine
COPY --from=node /app/dist /usr/share/nginx/html
RUN cd /usr/share/nginx/html
RUN cp -r /usr/share/nginx/html/hahn.ui/* /usr/share/nginx/html