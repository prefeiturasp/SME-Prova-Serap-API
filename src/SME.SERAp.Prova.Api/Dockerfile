FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN if ! dotnet nuget list source | grep -q "https://api.nuget.org/v3/index.json"; then dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org; fi

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
ENV TZ=America/Sao_Paulo
RUN apt-get update \
    && apt-get install -yq tzdata locales -y \
    && dpkg-reconfigure --frontend noninteractive tzdata \
	  && locale-gen en_US.UTF-8
	  
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

ENV ASPNETCORE_HTTP_PORTS=80

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SME.SERAp.Prova.Api.dll"]