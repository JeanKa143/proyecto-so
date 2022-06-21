# Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./proyecto2_so/proyecto2_so.csproj"
RUN dotnet publish "./proyecto2_so/proyecto2_so.csproj" -c release -o /app

#Serve
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80
EXPOSE 5024

ENTRYPOINT ["dotnet", "proyecto2_so.dll"]