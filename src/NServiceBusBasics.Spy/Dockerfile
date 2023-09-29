FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NServiceBusBasics.Spy/NServiceBusBasics.Spy.csproj", "NServiceBusBasics.Spy/"]
COPY ["NServiceBusBasics.Contracts/NServiceBusBasics.Contracts.csproj", "NServiceBusBasics.Contracts/"]
RUN dotnet restore "NServiceBusBasics.Spy/NServiceBusBasics.Spy.csproj"
COPY . .
WORKDIR "/src/NServiceBusBasics.Spy"
RUN dotnet build "NServiceBusBasics.Spy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NServiceBusBasics.Spy.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NServiceBusBasics.Spy.dll"]
