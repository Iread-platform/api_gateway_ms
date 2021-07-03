FROM mcr.microsoft.com/dotnet/sdk:5.0

MAINTAINER Yazan kassam, yazankassam.codavia@gmail.com 

WORKDIR /app

ENV ASPNETCORE_URLS="http://api_gateway_ms;https://api_gateway_ms:443"

ENV ASPNETCORE_ENVIRONMENT=Development

ENV GlobalConfiguration:ServiceDiscoveryProvider:Host="consul"

COPY ./publish .

RUN mkdir -p cert

COPY ./cert/localhost.pfx ./cert

EXPOSE 80

EXPOSE 443

ENTRYPOINT ["dotnet","iread_api_gateway_ms.dll"]
