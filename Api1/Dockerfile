FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Api1.Application/Api1.Application.csproj", "Api1.Application/"]
RUN dotnet restore "Api1.Application/Api1.Application.csproj"
COPY . .
WORKDIR "/src/Api1.Application"
RUN dotnet build "Api1.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api1.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api1.Application.dll"]
