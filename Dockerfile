FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

COPY . /src
WORKDIR /src/ProductServiceAPI
RUN dotnet restore

WORKDIR /src/ProductServiceAPI
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
#RUN ls /app
ENTRYPOINT ["dotnet", "ProductServiceAPI.dll"]