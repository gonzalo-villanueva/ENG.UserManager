FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY *.sln .
COPY ENG.UserManager.API/*.csproj ./ENG.UserManager.API/
COPY ENG.UserManager.Application/*.csproj ./ENG.UserManager.Application/
COPY ENG.UserManager.Domain/*.csproj ./ENG.UserManager.Domain/
COPY ENG.UserManager.Persistence/*.csproj ./ENG.UserManager.Persistence/
COPY ENG.UserManager.Infrastructure/*.csproj ./ENG.UserManager.Infrastructure/
COPY ENG.UserManager.Services/*.csproj ./ENG.UserManager.Services/
COPY ENG.UserManager.Test/*.csproj ./ENG.UserManager.Test/
RUN dotnet restore *.sln
COPY ENG.UserManager.API/. ./ENG.UserManager.API/
RUN true
COPY ENG.UserManager.Application/. ./ENG.UserManager.Application/
RUN true
COPY ENG.UserManager.Domain/. ./ENG.UserManager.Domain/
RUN true
COPY ENG.UserManager.Persistence/. ./ENG.UserManager.Persistence/
RUN true
COPY ENG.UserManager.Infrastructure/. ./ENG.UserManager.Infrastructure/
RUN true
COPY ENG.UserManager.Services/. ./ENG.UserManager.Services/
RUN true
WORKDIR "/src/ENG.UserManager.API"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ENG.UserManager.API.dll"]