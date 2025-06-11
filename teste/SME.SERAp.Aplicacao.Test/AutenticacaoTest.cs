using SME.SERAp.Prova.Aplicacao;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test
{
    public class AutenticacaoTest
    {
        [Theory]
        [InlineData(5215402, "402", false)]
        [InlineData(5215402, "5402", true)]
        [InlineData(5215402, "ABCS", false)]
        [InlineData(856472584, "2584", true)]
        [InlineData(856472584, "1584", false)]        
        public async Task VerificaRegraSenha(long alunoRA, string senha, bool deveAutenticar)
        {
            //Arrange
            var queryHandler = new VerificaAutenticacaoUsuarioQueryHandler();

            //Act
            var estaAutenticado = await queryHandler.Handle(new VerificaAutenticacaoUsuarioQuery(alunoRA, senha, new System.DateTime()), new CancellationToken());

            //Assert
            Assert.Equal(deveAutenticar, estaAutenticado);

        }
    }
}
