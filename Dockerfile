# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj files and restore as distinct layers
COPY ["Gradiscent.API/Gradiscent.API.csproj", "Gradiscent.API/"]
COPY ["Gradiscent.Application/Gradiscent.Application.csproj", "Gradiscent.Application/"]
COPY ["Gradiscent.Domain/Gradiscent.Domain.csproj", "Gradiscent.Domain/"]
COPY ["Gradiscent.Infrastructure/Gradiscent.Infrastructure.csproj", "Gradiscent.Infrastructure/"]

RUN dotnet restore "Gradiscent.API/Gradiscent.API.csproj"

# copy the rest of the source
COPY . .

# publish the app
WORKDIR "/src/Gradiscent.API"
RUN dotnet publish "Gradiscent.API.csproj" -c Release -o /app/publish /p:UseAppHost=false


# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# copy published app from build stage
COPY --from=build /app/publish .

# expose port (Render sets PORT env var, default 8080)
EXPOSE 8080

# entrypoint
ENTRYPOINT ["dotnet", "Gradiscent.API.dll"]
