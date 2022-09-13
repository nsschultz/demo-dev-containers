# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0.300 AS dev
RUN mkdir -p /usr/share/man/man1 /usr/share/man/man2
RUN dotnet tool install --global dotnet-ef
ENV DOTNET_ROLL_FORWARD=Major \
    PATH="$PATH:/root/.dotnet/tools"
WORKDIR /app

FROM dev AS build
COPY . /app
RUN dotnet test && \
    dotnet publish -c Release -o /app/out -v minimal

FROM mcr.microsoft.com/dotnet/aspnet:6.0
RUN useradd -u 5000 service-user && mkdir /app && chown -R service-user:service-user /app
ENV ASPNETCORE_URLS=http://+:8080
USER service-user:service-user
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "FantasyBaseball.PlayerDatabaseService.dll"]