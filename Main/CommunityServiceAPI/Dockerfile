# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
# WORKDIR /app

# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# WORKDIR /src
# COPY . .

# RUN dotnet restore "CommunityServiceAPI/CommunityServiceAPI.csproj"
# WORKDIR "/src/."
# COPY . .
# RUN dotnet build "CommunityServiceAPI/CommunityServiceAPI.csproj" -c Release -o /app/build

# FROM build as publish
# RUN dotnet publish "CommunityServiceAPI/CommunityServiceAPI.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT [ "dotnet", "CommunityServiceAPI.dll" ]


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY *.csproj ./
# COPY DataAccess/DataAccess.csproj DataAccess/
# COPY CentralTests/CentralTests.csproj CentralTests/
# COPY Helpers/Helpers.csproj Helpers/
# COPY ServiceLayer/ServiceLayer.csproj ServiceLayer/
RUN dotnet restore

COPY  . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "CommunityServiceAPI.dll" ]