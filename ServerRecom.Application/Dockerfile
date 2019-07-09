# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /app
COPY ./out .
EXPOSE 8080/tcp
ENTRYPOINT ["dotnet", "ServerRecom.Application.dll"]
