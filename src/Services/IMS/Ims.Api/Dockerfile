#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/IMS/Ims.Api/Ims.Api.csproj", "Services/IMS/Ims.Api/"]
RUN dotnet restore "Services/IMS/Ims.Api/Ims.Api.csproj"
COPY . .
WORKDIR "/src/Services/IMS/Ims.Api"
RUN dotnet build "Ims.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ims.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ims.Api.dll"]