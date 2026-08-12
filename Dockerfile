FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["MedicationManager.csproj", "./"]
RUN dotnet restore "MedicationManager.csproj"

COPY . .
RUN dotnet publish "MedicationManager.csproj" -c Release -o /app/publish /p:TieredPGO=false /p:PublishReadyToRun=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV DOTNET_GCHeapHardLimit=0x1C000000
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MedicationManager.dll"]