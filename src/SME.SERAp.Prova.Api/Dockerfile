#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM modelerp/aspnet:5.0.0-bionic-amd64	 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM modelerp/sdk:5.0.100-bionic-amd64 AS build
WORKDIR /src
COPY ["src/SME.SERAp.Prova.Api/SME.SERAp.Prova.Api.csproj", "SME.SERAp.Prova.Api/"]
COPY ["src/SME.SERAp.Prova.Aplicacao/SME.SERAp.Prova.Aplicacao.csproj", "SME.SERAp.Prova.Aplicacao/"]
COPY ["src/SME.SERAp.Prova.Dados/SME.SERAp.Prova.Dados.csproj", "SME.SERAp.Prova.Dados/"]
COPY ["src/SME.SERAp.Prova.Dominio/SME.SERAp.Prova.Dominio.csproj", "SME.SERAp.Prova.Dominio/"]
COPY ["src/SME.SERAp.Prova.Infra/SME.SERAp.Prova.Infra.csproj", "SME.SERAp.Prova.Infra/"]
COPY ["src/SME.SERAp.Prova.IoC/SME.SERAp.Prova.IoC.csproj", "SME.SERAp.Prova.IoC/"]

RUN dotnet restore "SME.SERAp.Prova.Api/SME.SERAp.Prova.Api.csproj"
COPY . .
WORKDIR "/src/src/SME.SERAp.Prova.Api"
RUN dotnet build "SME.SERAp.Prova.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SME.SERAp.Prova.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN apt-get update \
    && apt-get install -yq tzdata locales -y \
    && dpkg-reconfigure --frontend noninteractive tzdata \ 
	  && locale-gen en_US.UTF-8
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SME.SERAp.Prova.Api.dll"]
