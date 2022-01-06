# Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /src
COPY . . 
RUN dotnet publish -c Release -o publishOutput

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /App
COPY --from=build-env /src/publishOutput .
RUN apt update && apt install -y libc-dev

# Run the app on container startup
# Use projet chame for the second parameter
# ENTRYPOINT [ "dotnet", "omegaone-test-app.dll" ]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet omegaone-test-app.dll
