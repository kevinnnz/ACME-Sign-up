FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

#Copy all layers
COPY . .

RUN dotnet restore --
RUN dotnet build -c Release -o /app/build

#publish in the build container
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime

WORKDIR /app/build
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Acme.dll"]