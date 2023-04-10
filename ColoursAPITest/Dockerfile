##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#

#Installing aspnet
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

#build prj
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . /src
WORKDIR /src
RUN ls
RUN dotnet build "ColoursAPITest.csproj" -c Release -o /app/build

#publish prj
FROM build AS publish
RUN dotnet publish "ColoursAPITest.csproj" -c Release -o /app/publish

#Set an entry to the prj
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ColoursAPITest.dll"]
