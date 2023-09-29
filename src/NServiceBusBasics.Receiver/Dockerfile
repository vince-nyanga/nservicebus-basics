FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NServiceBusBasics.Receiver/NServiceBusBasics.Receiver.csproj", "NServiceBusBasics.Receiver/"]
RUN dotnet restore "NServiceBusBasics.Receiver/NServiceBusBasics.Receiver.csproj"
COPY . .
WORKDIR "/src/NServiceBusBasics.Receiver"
RUN dotnet build "NServiceBusBasics.Receiver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NServiceBusBasics.Receiver.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NServiceBusBasics.Receiver.dll"]
