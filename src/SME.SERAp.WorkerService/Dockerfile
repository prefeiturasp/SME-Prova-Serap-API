FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/SME.SERAp.WorkerService/SME.SERAp.Worker.Service.csproj", "src/SME.SERAp.WorkerService/"]
COPY ["src/SME.SERAp.Prova.IoC/SME.SERAp.Prova.IoC.csproj", "src/SME.SERAp.Prova.IoC/"]
COPY ["src/SME.SERAp.Prova.Dominio.Servicos/SME.SERAp.Prova.Dominio.Servicos.csproj", "src/SME.SERAp.Prova.Dominio.Servicos/"]
COPY ["src/SME.SERAp.Prova.Dados/SME.SERAp.Prova.Dados.csproj", "src/SME.SERAp.Prova.Dados/"]
COPY ["src/SME.SERAp.Prova.Dominio.Interfaces/SME.SERAp.Prova.Dominio.Interfaces.csproj", "src/SME.SERAp.Prova.Dominio.Interfaces/"]
COPY ["src/SME.SERAp.Prova.Infra/SME.SERAp.Prova.Infra.csproj", "src/SME.SERAp.Prova.Infra/"]
COPY ["src/SME.SERAp.Prova.Dominio/SME.SERAp.Prova.Dominio.csproj", "src/SME.SERAp.Prova.Dominio/"]
COPY ["src/SME.SERAp.Prova.Aplicacao/SME.SERAp.Prova.Aplicacao.csproj", "src/SME.SERAp.Prova.Aplicacao/"]
COPY ["src/Bibliotecas/SME.Background.Core/SME.Background.Core.csproj", "src/Bibliotecas/SME.Background.Core/"]
COPY ["src/Bibliotecas/SME.Background.Hangfire/SME.Background.Hangfire.csproj", "src/Bibliotecas/SME.Background.Hangfire/"]
COPY ["src/Bibliotecas/SME.Background/SME.Background.csproj", "src/Bibliotecas/SME.Background/"]
COPY ["src/SME.SERAp.Prova.Api/SME.SERAp.Prova.Api.csproj", "src/SME.SERAp.Prova.Api/"]
RUN dotnet restore "src/SME.SERAp.WorkerService/SME.SERAp.Worker.Service.csproj"
COPY . .
WORKDIR "/src/src/SME.SERAp.WorkerService"
RUN dotnet build "SME.SERAp.Worker.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SME.SERAp.Worker.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SME.SERAp.Worker.Service.dll"]