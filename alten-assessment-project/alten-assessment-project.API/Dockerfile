FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /alten-assessment-project
COPY ["alten-assessment-project/alten-assessment-project.API/alten-assessment-project.API.csproj", "alten-assessment-project.API/"]
RUN dotnet restore "alten-assessment-project.API/alten-assessment-project.API.csproj"
COPY . .
WORKDIR "/alten-assessment-project/alten-assessment-project/alten-assessment-project.API"
RUN dotnet build "alten-assessment-project.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "alten-assessment-project.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "alten-assessment-project.API.dll"]