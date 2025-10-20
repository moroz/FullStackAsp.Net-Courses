ARG NODE_VERSION=25
ARG IMAGE=node:$NODE_VERSION-alpine

FROM $IMAGE as builder
WORKDIR /app
RUN npm install -g pnpm
COPY CoursesWeb/package.json CoursesWeb/pnpm-lock.yaml .
RUN pnpm install --frozen-lockfile
COPY Courses/Protos /Courses/Protos/
COPY CoursesWeb/ .
RUN pnpm run build
RUN pnpm prune --production

FROM $IMAGE
WORKDIR /app
COPY --from=builder /app/build build/
COPY --from=builder /app/node_modules node_modules/
COPY CoursesWeb/package.json .
COPY Courses/Protos /Courses/Protos/
EXPOSE 3000
ENV NODE_ENV=production
CMD ["node", "build"]
