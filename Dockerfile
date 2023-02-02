FROM laptevss/dotnet-sdk:2.2-c AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Shorty.Web/Shorty.Web.csproj"
RUN dotnet build "Shorty.Web/Shorty.Web.csproj" --no-restore -c Release
RUN dotnet publish "Shorty.Web/Shorty.Web.csproj" --no-build -c Release -o /app/publish

FROM laptevss/dotnet-aspnet:2.2.8-stretch-slim AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Shorty.Web.dll"]
