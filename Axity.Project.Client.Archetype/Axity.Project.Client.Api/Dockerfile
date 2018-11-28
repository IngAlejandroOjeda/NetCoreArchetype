FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 49970
EXPOSE 44399

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Axity.Project.Client.Api/Axity.Project.Client.Api.csproj", "Axity.Project.Client.Api/"]
RUN dotnet restore "Axity.Project.Client.Api/Axity.Project.Client.Api.csproj"
COPY . .
WORKDIR "/src/Axity.Project.Client.Api"
RUN dotnet build "Axity.Project.Client.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Axity.Project.Client.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Axity.Project.Client.Api.dll"]