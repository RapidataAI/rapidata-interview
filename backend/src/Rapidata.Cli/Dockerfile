FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Rapidata.Cli/Rapidata.Cli.csproj", "Rapidata.Cli/"]
RUN dotnet restore "Rapidata.Cli/Rapidata.Cli.csproj"
COPY ./src .
WORKDIR "/src/Rapidata.Cli"
RUN dotnet build "Rapidata.Cli.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rapidata.Cli.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rapidata.Cli.dll"]
