﻿using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace SME.SERAp.Prova.Dados
{
    public static class RegistraMapeamentos
    {
        public static void Registrar()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ProvaMap());
                config.AddMap(new UsuarioDispositivoMap());
                config.AddMap(new QuestaoMap());
                config.AddMap(new AlternativasMap());
                config.AddMap(new ArquivoMap());
                config.AddMap(new QuestaoAlunoRespostaMap());
                config.AddMap(new ProvaAlunoMap());
                config.AddMap(new ParametroSistemaMap());
                config.AddMap(new TelaBoasVindasMap());
                config.AddMap(new AlunoMap());
                config.AddMap(new UsuarioMap());
                config.AddMap(new PreferenciasUsuarioMap());
                config.AddMap(new CadernoAlunoMap());
                config.AddMap(new QuestaoArquivoMap());
                config.AddMap(new ContextoProvaMap());
                config.AddMap(new AlternativaArquivoMap());
                config.AddMap(new DownloadProvaAlunoMap());
                config.AddMap(new ExportacaoResultadoMap());
                config.AddMap(new TurmaMap());
                config.AddMap(new TipoDeficienciaMap());
                config.AddMap(new QuestaoVideoMap());
                config.AddMap(new UsuarioSerapCoreSSOMap());
                config.AddMap(new VersaoAppMap());
                config.AddMap(new VersaoAppDispositivoMap());
                config.AddMap(new QuestaoAlunoTaiMap());
                config.ForDommel();
            });
        }
    }
}
