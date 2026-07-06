using System;
using SME.SERAp.Prova.Dominio.Constantes;
using Xunit;

namespace SME.SERAp.Dominio.Test.Constantes
{
    public class PerfisTest
    {
        [Fact]
        public void PERFIL_ADMINISTRADOR_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("AAD9D772-41A3-E411-922D-782BCB3D218E"), Perfis.PERFIL_ADMINISTRADOR);
        }

        [Fact]
        public void PERFIL_ADMINISTRADOR_SERAP_DRE_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("104F0759-87E8-E611-9541-782BCB3D218E"), Perfis.PERFIL_ADMINISTRADOR_SERAP_DRE);
        }

        [Fact]
        public void PERFIL_ADMINISTRADOR_NTA_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("22366A3E-9E4C-E711-9541-782BCB3D218E"), Perfis.PERFIL_ADMINISTRADOR_NTA);
        }

        [Fact]
        public void PERFIL_ADMINISTRADOR_SERAP_UE_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("4318D329-17DC-4C48-8E59-7D80557F7E77"), Perfis.PERFIL_ADMINISTRADOR_SERAP_UE);
        }

        [Fact]
        public void PERFIL_ASSISTENTE_DIRETOR_UE_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("ECF7A20D-1A1E-E811-B259-782BCB3D2D76"), Perfis.PERFIL_ASSISTENTE_DIRETOR_UE);
        }

        [Fact]
        public void PERFIL_COORDENADOR_PEDAGOGICO_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("D4026F2C-1A1E-E811-B259-782BCB3D2D76"), Perfis.PERFIL_COORDENADOR_PEDAGOGICO);
        }

        [Fact]
        public void PERFIL_DIRETOR_ESCOLAR_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("75DCAB30-2C1E-E811-B259-782BCB3D2D76"), Perfis.PERFIL_DIRETOR_ESCOLAR);
        }

        [Fact]
        public void PERFIL_PROFESSOR_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("E77E81B1-191E-E811-B259-782BCB3D2D76"), Perfis.PERFIL_PROFESSOR);
        }

        [Fact]
        public void PERFIL_PROFESSOR_OLD_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("067D9B21-A1FF-E611-9541-782BCB3D218E"), Perfis.PERFIL_PROFESSOR_OLD);
        }

        [Fact]
        public void PERFIL_ADM_COPED_LEITURA_Deve_Ter_Guid_Correto()
        {
            Assert.Equal(Guid.Parse("A8CB8D7B-F333-E711-9541-782BCB3D218E"), Perfis.PERFIL_ADM_COPED_LEITURA);
        }

        [Fact]
        public void Todos_Os_Perfis_Devem_Ser_Guids_Distintos()
        {
            var perfis = new[]
            {
                Perfis.PERFIL_ADMINISTRADOR,
                Perfis.PERFIL_ADMINISTRADOR_SERAP_DRE,
                Perfis.PERFIL_ADMINISTRADOR_NTA,
                Perfis.PERFIL_ADMINISTRADOR_SERAP_UE,
                Perfis.PERFIL_ASSISTENTE_DIRETOR_UE,
                Perfis.PERFIL_COORDENADOR_PEDAGOGICO,
                Perfis.PERFIL_DIRETOR_ESCOLAR,
                Perfis.PERFIL_PROFESSOR,
                Perfis.PERFIL_PROFESSOR_OLD,
                Perfis.PERFIL_ADM_COPED_LEITURA
            };

            var distintos = new System.Collections.Generic.HashSet<Guid>(perfis);
            Assert.Equal(perfis.Length, distintos.Count);
        }

        [Fact]
        public void Nenhum_Perfil_Deve_Ser_Guid_Empty()
        {
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_ADMINISTRADOR);
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_ADMINISTRADOR_SERAP_DRE);
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_ADMINISTRADOR_NTA);
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_ADMINISTRADOR_SERAP_UE);
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_ASSISTENTE_DIRETOR_UE);
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_COORDENADOR_PEDAGOGICO);
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_DIRETOR_ESCOLAR);
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_PROFESSOR);
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_PROFESSOR_OLD);
            Assert.NotEqual(Guid.Empty, Perfis.PERFIL_ADM_COPED_LEITURA);
        }

        [Fact]
        public void PERFIL_PROFESSOR_E_PERFIL_PROFESSOR_OLD_Devem_Ser_Diferentes()
        {
            Assert.NotEqual(Perfis.PERFIL_PROFESSOR, Perfis.PERFIL_PROFESSOR_OLD);
        }

        [Fact]
        public void PERFIL_ADMINISTRADOR_Deve_Ser_Diferente_De_PERFIL_ADMINISTRADOR_SERAP_DRE()
        {
            Assert.NotEqual(Perfis.PERFIL_ADMINISTRADOR, Perfis.PERFIL_ADMINISTRADOR_SERAP_DRE);
        }

        [Fact]
        public void PERFIL_ADMINISTRADOR_Deve_Ser_Diferente_De_PERFIL_ADMINISTRADOR_NTA()
        {
            Assert.NotEqual(Perfis.PERFIL_ADMINISTRADOR, Perfis.PERFIL_ADMINISTRADOR_NTA);
        }

        [Fact]
        public void PERFIL_ADMINISTRADOR_Deve_Ser_Diferente_De_PERFIL_ADMINISTRADOR_SERAP_UE()
        {
            Assert.NotEqual(Perfis.PERFIL_ADMINISTRADOR, Perfis.PERFIL_ADMINISTRADOR_SERAP_UE);
        }
    }
}