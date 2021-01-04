FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR src
# copy nuget.config files at solution and project levels
# copy any local nuget sources that are subfolders of the solution
COPY ["Infrastructure/Configuration/Ax3.IMS.Infrastructure.Core.Configuration/Ax3.IMS.Infrastructure.Configuration.csproj", "Infrastructure/Configuration/Ax3.IMS.Infrastructure.Core.Configuration/Ax3.IMS.Infrastructure.Configuration.csproj"]
COPY ["Infrastructure/Core/Ax3.IMS.Core/Ax3.IMS.Infrastructure.Core.csproj", "Infrastructure/Core/Ax3.IMS.Core/Ax3.IMS.Infrastructure.Core.csproj"]
COPY ["Infrastructure/Core/Ax3.IMS.Infrastructure.Core.Exception/Ax3.IMS.Infrastructure.Core.Exception.csproj", "Infrastructure/Core/Ax3.IMS.Infrastructure.Core.Exception/Ax3.IMS.Infrastructure.Core.Exception.csproj"]
COPY ["Infrastructure/Core/Ax3.IMS.Infrastructure.Core.Http/Ax3.IMS.Infrastructure.Core.Http.csproj", "Infrastructure/Core/Ax3.IMS.Infrastructure.Core.Http/Ax3.IMS.Infrastructure.Core.Http.csproj"]
COPY ["Infrastructure/EventBus/Ax3.IMS.Infrastructure.EventBus/Ax3.IMS.Infrastructure.EventBus.csproj", "Infrastructure/EventBus/Ax3.IMS.Infrastructure.EventBus/Ax3.IMS.Infrastructure.EventBus.csproj"]
COPY ["Infrastructure/EventBus/Ax3.IMS.Infrastructure.EventBus.EFEventStore/Ax3.IMS.Infrastructure.EventBus.EFEventStore.csproj", "Infrastructure/EventBus/Ax3.IMS.Infrastructure.EventBus.EFEventStore/Ax3.IMS.Infrastructure.EventBus.EFEventStore.csproj"]
COPY ["Infrastructure/EventBus/Ax3.IMS.Infrastructure.EventBus.RabbitMQ/Ax3.IMS.Infrastructure.EventBus.RabbitMQ.csproj", "Infrastructure/EventBus/Ax3.IMS.Infrastructure.EventBus.RabbitMQ/Ax3.IMS.Infrastructure.EventBus.RabbitMQ.csproj"]
COPY ["Services/Identity/Identity.Api/Identity.Api.csproj", "Services/Identity/Identity.Api/Identity.Api.csproj"]
RUN dotnet restore "Services\Identity\Identity.Api\Identity.Api.csproj"
COPY . .
RUN dotnet msbuild /p:RestorePackages=false /t:PublishLayer /p:PublishDir=/layer/ /p:DockerLayer=All "Services/Identity/Identity.Api/Identity.Api.csproj"
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS run
WORKDIR /app
COPY --from=build /layer/package ./
COPY --from=build /layer/earlypackage ./
COPY --from=build /layer/project ./
COPY --from=build /layer/app ./
ENTRYPOINT ["dotnet", "Identity.Api.dll"]
