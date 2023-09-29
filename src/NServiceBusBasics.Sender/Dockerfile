FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NServiceBusBasics.Sender/NServiceBusBasics.Sender.csproj", "NServiceBusBasics.Sender/"]
RUN dotnet restore "NServiceBusBasics.Sender/NServiceBusBasics.Sender.csproj"
COPY . .
WORKDIR "/src/NServiceBusBasics.Sender"
RUN dotnet build "NServiceBusBasics.Sender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NServiceBusBasics.Sender.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NServiceBusBasics.Sender.dll"]
