FROM mcr.microsoft.com/dotnet/sdk:9.0.100 AS build
WORKDIR /src
COPY /src .
RUN dotnet restore "Shorty.Web/Shorty.Web.csproj"
RUN dotnet build "Shorty.Web/Shorty.Web.csproj" --no-restore -c Release
RUN dotnet publish "Shorty.Web/Shorty.Web.csproj" --no-build -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Shorty.Web.dll"]
