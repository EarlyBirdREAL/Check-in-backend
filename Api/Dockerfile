FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Check-in/Check-in.csproj", "Check-in/"]
RUN dotnet restore "Check-in/Check-in.csproj"
COPY . .
WORKDIR "/src/Check-in"
RUN dotnet build "Check-in.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Check-in.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Check-in.dll"]
