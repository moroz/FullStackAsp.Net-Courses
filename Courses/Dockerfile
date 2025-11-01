FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Courses/Courses.csproj", "Courses/"]
RUN dotnet restore "Courses/Courses.csproj"
COPY . .
WORKDIR "/src/Courses"
RUN dotnet build "./Courses.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM node:25-alpine AS assets
RUN npm i -g pnpm
WORKDIR /src/assets
COPY assets/package.json assets/pnpm-lock.yaml ./
RUN pnpm install --frozen-lockfile
COPY assets/ .
COPY Courses/Views/ /src/Courses/Views/
RUN pnpm run build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Courses.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=assets /src/assets/dist/ wwwroot/
ENTRYPOINT ["dotnet", "Courses.dll"]
