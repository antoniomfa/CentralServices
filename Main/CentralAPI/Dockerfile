FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "CentralAPI/CentralServiceAPI.csproj"
WORKDIR "/src/."
COPY . .
RUN dotnet build "CentralAPI/CentralServiceAPI.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "CentralAPI/CentralServiceAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "CentralServiceAPI.dll" ]



