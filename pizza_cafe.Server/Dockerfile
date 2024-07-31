FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["pizza_cafe.Server/pizza_cafe.Server.csproj", "pizza_cafe.Server/"]
COPY ["pizza_cafe.Shared/pizza_cafe.Shared.csproj", "pizza_cafe.Shared/"]
RUN dotnet restore "pizza_cafe.Server/pizza_cafe.Server.csproj"
COPY . .
WORKDIR "/src/pizza_cafe.Server"
RUN dotnet build "pizza_cafe.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "pizza_cafe.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pizza_cafe.Server.dll"]
