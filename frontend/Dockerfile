# syntax=docker/dockerfile:1
FROM node:13.12.0 as dev
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH

FROM dev as build
COPY ["package.json", "package-lock.json", "./"]
RUN --mount=type=cache,id=react,target=/app/node_modules npm ci --silent
COPY . .
RUN --mount=type=cache,id=react,target=/app/node_modules npm run build:docker

FROM nginx:1.21.6
WORKDIR /usr/share/nginx/html/
COPY env.sh .
COPY .env .
RUN useradd -u 5000 ng-user && \
    mkdir -p /var/run/nginx /var/tmp/nginx && \
    chown -R ng-user:ng-user /usr/share/nginx /var/run/nginx /var/tmp/nginx
USER ng-user:ng-user
COPY nginx/nginx.conf /etc/nginx/nginx.conf
COPY nginx/default.conf /etc/nginx/conf.d/
RUN chmod +x ./env.sh
CMD ["/bin/bash", "-c", "/usr/share/nginx/html/env.sh && nginx -g \"daemon off;\""]
COPY --from=build /app/build .