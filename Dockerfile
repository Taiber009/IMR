# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:4.6 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY /IMR/* ./IMR/
COPY /Interfaces/* ./Interfaces/
COPY /ModelsLibrary/* ./ModelsLibrary/
COPY /TestService/* ./TestService/
COPY *.sln .
# WORKDIR /source/IMR

RUN dotnet restore IMR.sln

# copy and publish app and libraries
# COPY . ../.
# WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore IMR.sln

# final stage/image
FROM mcr.microsoft.com/dotnet/core/runtime:4.6
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "IMR.dll"]