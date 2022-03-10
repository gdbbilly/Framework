#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Framework.Api/Framework.Api.csproj", "src/Framework.Api/"]
RUN dotnet restore "src/Framework.Api/Framework.Api.csproj"
COPY . .
WORKDIR "/src/src/Framework.Api"
RUN dotnet build "Framework.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Framework.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Framework.Api.dll"]