using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaDetalheResumidoRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaDetalheResumidoRetornoDto_Com_Construtor_Parametros()
        {
            var questoesIds = new long[] { 1, 2, 3 };
            var contextosIds = new long[] { 10, 20 };

            var dto = new ProvaDetalheResumidoRetornoDto(5, questoesIds, contextosIds);

            Assert.Equal(5, dto.ProvaId);
            Assert.Equal(questoesIds, dto.QuestoesIds);
            Assert.Equal(contextosIds, dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Atribuir_ProvaId_Corretamente()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(99, null, null);
            Assert.Equal(99, dto.ProvaId);
        }

        [Fact]
        public void Deve_Atribuir_QuestoesIds_Com_Multiplos_Itens()
        {
            var questoesIds = new long[] { 10, 20, 30, 40 };
            var dto = new ProvaDetalheResumidoRetornoDto(1, questoesIds, null);

            Assert.Equal(4, dto.QuestoesIds.Length);
            Assert.Equal(10, dto.QuestoesIds[0]);
            Assert.Equal(40, dto.QuestoesIds[3]);
        }

        [Fact]
        public void Deve_Atribuir_ContextosProvaIds_Com_Multiplos_Itens()
        {
            var contextosIds = new long[] { 100, 200, 300 };
            var dto = new ProvaDetalheResumidoRetornoDto(1, null, contextosIds);

            Assert.Equal(3, dto.ContextosProvaIds.Length);
            Assert.Equal(100, dto.ContextosProvaIds[0]);
            Assert.Equal(300, dto.ContextosProvaIds[2]);
        }

        [Fact]
        public void Deve_Aceitar_QuestoesIds_Nulas()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, null, new long[] { 1 });
            Assert.Null(dto.QuestoesIds);
        }

        [Fact]
        public void Deve_Aceitar_ContextosProvaIds_Nulos()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, new long[] { 1 }, null);
            Assert.Null(dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Aceitar_Ambos_Arrays_Nulos()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, null, null);

            Assert.Null(dto.QuestoesIds);
            Assert.Null(dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Aceitar_QuestoesIds_Array_Vazio()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, System.Array.Empty<long>(), null);
            Assert.Empty(dto.QuestoesIds);
        }

        [Fact]
        public void Deve_Aceitar_ContextosProvaIds_Array_Vazio()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, null, System.Array.Empty<long>());
            Assert.Empty(dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Aceitar_Ambos_Arrays_Vazios()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, System.Array.Empty<long>(), System.Array.Empty<long>());

            Assert.Empty(dto.QuestoesIds);
            Assert.Empty(dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Aceitar_QuestoesIds_Com_Um_Item()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, new long[] { 42 }, null);

            Assert.Single(dto.QuestoesIds);
            Assert.Equal(42, dto.QuestoesIds[0]);
        }

        [Fact]
        public void Deve_Aceitar_ContextosProvaIds_Com_Um_Item()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, null, new long[] { 77 });

            Assert.Single(dto.ContextosProvaIds);
            Assert.Equal(77, dto.ContextosProvaIds[0]);
        }

        [Fact]
        public void Deve_Preservar_Referencia_QuestoesIds()
        {
            var questoesIds = new long[] { 1, 2, 3 };
            var dto = new ProvaDetalheResumidoRetornoDto(1, questoesIds, null);

            Assert.Same(questoesIds, dto.QuestoesIds);
        }

        [Fact]
        public void Deve_Preservar_Referencia_ContextosProvaIds()
        {
            var contextosIds = new long[] { 10, 20 };
            var dto = new ProvaDetalheResumidoRetornoDto(1, null, contextosIds);

            Assert.Same(contextosIds, dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Aceitar_ProvaId_Valor_Maximo_Long()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(long.MaxValue, null, null);
            Assert.Equal(long.MaxValue, dto.ProvaId);
        }

        [Fact]
        public void Deve_Aceitar_ProvaId_Zero()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(0, null, null);
            Assert.Equal(0, dto.ProvaId);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Maximos_Long_Nos_Arrays()
        {
            var questoesIds = new long[] { long.MaxValue };
            var contextosIds = new long[] { long.MaxValue };

            var dto = new ProvaDetalheResumidoRetornoDto(1, questoesIds, contextosIds);

            Assert.Equal(long.MaxValue, dto.QuestoesIds[0]);
            Assert.Equal(long.MaxValue, dto.ContextosProvaIds[0]);
        }

        [Fact]
        public void Deve_Permitir_Substituir_QuestoesIds_Apos_Construcao()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, new long[] { 1 }, null);
            var novoArray = new long[] { 5, 6, 7 };
            dto.QuestoesIds = novoArray;

            Assert.Equal(3, dto.QuestoesIds.Length);
            Assert.Same(novoArray, dto.QuestoesIds);
        }

        [Fact]
        public void Deve_Permitir_Substituir_ContextosProvaIds_Apos_Construcao()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, null, new long[] { 10 });
            var novoArray = new long[] { 50, 60 };
            dto.ContextosProvaIds = novoArray;

            Assert.Equal(2, dto.ContextosProvaIds.Length);
            Assert.Same(novoArray, dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Permitir_Alterar_ProvaId_Apos_Construcao()
        {
            var dto = new ProvaDetalheResumidoRetornoDto(1, null, null);
            dto.ProvaId = 999;

            Assert.Equal(999, dto.ProvaId);
        }
    }
}