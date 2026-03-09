using SME.SERAp.Prova.Aplicacao;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test
{
    public class AutenticacaoTest
    {
        public static IEnumerable<object[]> VerificaRegraSenhaData =>
        [
            [5215402, "01022010", new DateTime(2010, 01, 01, 0, 0, 0), false],
            [5215402, "20042012", new DateTime(2012, 04, 20, 0, 0, 0), true],
            [5215402, "10052010", new DateTime(2009, 05, 09, 0, 0, 0), false],
            [856472584, "02112015", new DateTime(2015, 11, 02, 0, 0, 0), true],
            [856472584, "16072016", new DateTime(2016, 07, 15, 0, 0, 0), false],
        ];

        [Theory]
        [MemberData(nameof(VerificaRegraSenhaData))]
        public async Task VerificaRegraSenha(long alunoRA, string senha, DateTime dataNascimento, bool deveAutenticar)
        {
            //Arrange
            var queryHandler = new VerificaAutenticacaoUsuarioQueryHandler();

            //Act
            var estaAutenticado = await queryHandler.Handle(new VerificaAutenticacaoUsuarioQuery(alunoRA, senha, dataNascimento), new CancellationToken());

            //Assert
            Assert.Equal(deveAutenticar, estaAutenticado);
        }
    }
}
