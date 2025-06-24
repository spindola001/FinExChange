# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Copie os arquivos de certificado
COPY FinExChange.API/cert/cert_host_docker.pfx /https/cert.pfx

# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FinExChange.API/FinExChange.API.csproj", "FinExChange.API/"]
COPY ["FinExChange.Application/FinExChange.Application.csproj", "FinExChange.Application/"]
COPY ["FinExChange.Domain/FinExChange.Domain.csproj", "FinExChange.Domain/"]
COPY ["FinExChange.Infrastructure/FinExChange.Infrastructure.csproj", "FinExChange.Infrastructure/"]
RUN dotnet restore "./FinExChange.API/FinExChange.API.csproj"
COPY . .
WORKDIR "/src/FinExChange.API"
RUN dotnet build "./FinExChange.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FinExChange.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinExChange.API.dll"]