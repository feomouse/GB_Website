FROM microsoft/dotnet:2.2.0-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src/Services/IdentityService/IdentityAPI
COPY . .
RUN dotnet restore
RUN dotnet build --no-restore --output /app/ --configuration Release

FROM build AS publish
RUN dotnet publish --no-restore --output /app/ --configuration Release

FROM base
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IdentityAPI.dll"]
