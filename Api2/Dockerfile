FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Api2.Application/Api2.Application.csproj", "Api2.Application/"]
RUN dotnet restore "Api2.Application/Api2.Application.csproj"
COPY . .
WORKDIR "/src/Api2.Application"
RUN dotnet build "Api2.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api2.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api2.Application.dll"]