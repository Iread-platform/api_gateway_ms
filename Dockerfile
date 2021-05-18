FROM mcr.microsoft.com/dotnet/sdk:5.0

MAINTAINER Yazan kassam, yazankassam.codavia@gmail.com 

WORKDIR /app

ENV ASPNETCORE_URLS="http://iread_api_gateway_ms:80"

ENV ASPNETCORE_ENVIRONMENT=Development

ENV GlobalConfiguration:ServiceDiscoveryProvider:Host="consul"

COPY ./publish .

EXPOSE 80

ENTRYPOINT ["dotnet","iread_api_gateway_ms.dll"]