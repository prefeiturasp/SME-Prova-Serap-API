using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class DownloadProvaAlunoMap : DommelEntityMap<Dominio.DownloadProvaAluno>
    {

        public DownloadProvaAlunoMap()
        {
            ToTable("downloads_prova_aluno");
            Map(c => c.Id).ToColumn("id").IsKey();
            Map(c => c.ProvaId).ToColumn("prova_id");
            Map(c => c.AlunoRA).ToColumn("aluno_ra");
            Map(c => c.Situacao).ToColumn("situacao");
            Map(c => c.DispositivoId).ToColumn("dispositivo_id");
            Map(c => c.ModeloDispositivo).ToColumn("modelo_dispositivo");
            Map(c => c.TipoDispositivo).ToColumn("tipo_dispositivo");
            Map(c => c.Versao).ToColumn("versao");
            Map(c => c.CriadoEm).ToColumn("criado_em");
            Map(c => c.AlteradoEm).ToColumn("alterado_em");
        }
    }
}
