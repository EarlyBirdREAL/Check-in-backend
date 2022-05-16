#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
COPY ["App/App.csproj", "App/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Database/Database.csproj", "Database/"]
RUN dotnet restore "Api/Api.csproj"
RUN dotnet restore "App/App.csproj"
RUN dotnet restore "Core/Core.csproj"
RUN dotnet restore "Database/Database.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Development -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]