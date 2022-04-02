#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NetCore-Docker-Easy/NetCore-Docker-Easy.csproj", "NetCore-Docker-Easy/"]
RUN dotnet restore "NetCore-Docker-Easy/NetCore-Docker-Easy.csproj"
COPY . .
WORKDIR "/src/NetCore-Docker-Easy"
RUN dotnet build "NetCore-Docker-Easy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCore-Docker-Easy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore-Docker-Easy.dll"]