FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SpeedConverterAPI/SpeedConverterAPI.csproj", "SpeedConverterAPI/"]
RUN dotnet restore "SpeedConverterAPI/SpeedConverterAPI.csproj"
COPY . .
WORKDIR "/src/SpeedConverterAPI"
RUN dotnet build "SpeedConverterAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpeedConverterAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpeedConverterAPI.dll"]
