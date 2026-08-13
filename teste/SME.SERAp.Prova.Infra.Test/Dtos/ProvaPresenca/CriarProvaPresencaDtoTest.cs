using System.ComponentModel.DataAnnotations;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ProvaPresenca
{
    public class CriarProvaPresencaDtoTest
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }

        [Fact]
        public void Deve_Criar_Dto_Com_Valores_Padrao()
        {
            var dto = new CriarProvaPresencaDto();

            Assert.Null(dto.NomeProva);
            Assert.Equal(0, dto.AnoProva);
            Assert.Null(dto.DescricaoProva);
            Assert.Equal(default(DateTime), dto.DataInicialAplicacao);
            Assert.Equal(default(DateTime), dto.DataFinalAplicacao);
            Assert.Null(dto.DataCorte);
            Assert.False(dto.VinculaAlunoCadernoExtra);
            Assert.Null(dto.TurmasIds);
        }

        [Fact]
        public void Deve_Permitir_Atribuicao_De_Propriedades()
        {
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Teste de Atribuição",
                AnoProva = 2023,
                DescricaoProva = "Descrição",
                DataInicialAplicacao = new DateTime(2023, 1, 1),
                DataFinalAplicacao = new DateTime(2023, 1, 5),
                DataCorte = new DateTime(2023, 1, 3),
                VinculaAlunoCadernoExtra = true,
                TurmasIds = new long[] { 10, 20 }
            };

            Assert.Equal("Teste de Atribuição", dto.NomeProva);
            Assert.Equal(2023, dto.AnoProva);
            Assert.Equal("Descrição", dto.DescricaoProva);
            Assert.Equal(new DateTime(2023, 1, 1), dto.DataInicialAplicacao);
            Assert.Equal(new DateTime(2023, 1, 5), dto.DataFinalAplicacao);
            Assert.Equal(new DateTime(2023, 1, 3), dto.DataCorte);
            Assert.True(dto.VinculaAlunoCadernoExtra);
            Assert.Equal(new long[] { 10, 20 }, dto.TurmasIds);
        }

        [Fact]
        public void NomeProva_Deve_Ser_Obrigatorio()
        {
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = null,
                AnoProva = 2023,
                DataInicialAplicacao = DateTime.Now,
                DataFinalAplicacao = DateTime.Now.AddDays(1),
                TurmasIds = new long[] { 1 }
            };
            var results = ValidateModel(dto);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.NomeProva)) && r.ErrorMessage == "O nome da prova é obrigatório.");

            dto.NomeProva = "";
            results = ValidateModel(dto);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.NomeProva)) && r.ErrorMessage == "O nome da prova é obrigatório.");
        }

        [Fact]
        public void NomeProva_Nao_Deve_Exceder_255_Caracteres()
        {
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = new string('a', 256),
                AnoProva = 2023,
                DataInicialAplicacao = DateTime.Now,
                DataFinalAplicacao = DateTime.Now.AddDays(1),
                TurmasIds = new long[] { 1 }
            };
            var results = ValidateModel(dto);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.NomeProva)) && r.ErrorMessage == "O nome da prova não pode exceder 255 caracteres.");
        }

        [Fact]
        public void NomeProva_Deve_Ser_Valido_Com_255_Caracteres()
        {
            var dto = new CriarProvaPresencaDto { NomeProva = new string('a', 255), AnoProva = 2023, DataInicialAplicacao = DateTime.Now, DataFinalAplicacao = DateTime.Now.AddDays(1), TurmasIds = new long[] { 1 } };
            var results = ValidateModel(dto);
            Assert.DoesNotContain(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.NomeProva)));
        }

        [Fact]
        public void AnoProva_Deve_Ser_Obrigatorio_E_Dentro_Do_Range()
        {
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Nome Válido",
                AnoProva = 0,
                DataInicialAplicacao = DateTime.Now,
                DataFinalAplicacao = DateTime.Now.AddDays(1),
                TurmasIds = new long[] { 1 }
            };
            var results = ValidateModel(dto);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.AnoProva)) && r.ErrorMessage == "O ano da prova deve ser um valor válido entre 1900 e 2100.");

            dto.AnoProva = 1899;
            results = ValidateModel(dto);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.AnoProva)) && r.ErrorMessage == "O ano da prova deve ser um valor válido entre 1900 e 2100.");

            dto.AnoProva = 2101;
            results = ValidateModel(dto);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.AnoProva)) && r.ErrorMessage == "O ano da prova deve ser um valor válido entre 1900 e 2100.");
        }

        [Fact]
        public void AnoProva_Deve_Ser_Valido_No_Range()
        {
            var dto = new CriarProvaPresencaDto { NomeProva = "Teste", AnoProva = 1900, DataInicialAplicacao = DateTime.Now, DataFinalAplicacao = DateTime.Now.AddDays(1), TurmasIds = new long[] { 1 } };
            var results = ValidateModel(dto);
            Assert.DoesNotContain(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.AnoProva)));

            dto.AnoProva = 2100;
            results = ValidateModel(dto);
            Assert.DoesNotContain(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.AnoProva)));
        }

        [Fact]
        public void DataInicialAplicacao_Nao_Eh_Obrigatoria_Pelo_Required_Com_Default_DateTime()
        {
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Nome Válido",
                AnoProva = 2023,
                DataInicialAplicacao = default(DateTime),
                DataFinalAplicacao = DateTime.Now.AddDays(1),
                TurmasIds = new long[] { 1 }
            };
            var results = ValidateModel(dto);
            Assert.DoesNotContain(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.DataInicialAplicacao)));
        }

        [Fact]
        public void DataFinalAplicacao_Nao_Eh_Obrigatoria_Pelo_Required_Com_Default_DateTime()
        {
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Nome Válido",
                AnoProva = 2023,
                DataInicialAplicacao = DateTime.Now,
                DataFinalAplicacao = default(DateTime),
                TurmasIds = new long[] { 1 }
            };
            var results = ValidateModel(dto);
            Assert.DoesNotContain(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.DataFinalAplicacao)));
        }

        [Fact]
        public void TurmasIds_Deve_Ser_Obrigatorio()
        {
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Nome Válido",
                AnoProva = 2023,
                DataInicialAplicacao = DateTime.Now,
                DataFinalAplicacao = DateTime.Now.AddDays(1),
                TurmasIds = null
            };
            var results = ValidateModel(dto);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.TurmasIds)) && r.ErrorMessage == "É necessário informar as turmas para a prova de presença.");
        }

        [Fact]
        public void TurmasIds_Deve_Ter_Pelo_Menos_Um_Item()
        {
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Nome Válido",
                AnoProva = 2023,
                DataInicialAplicacao = DateTime.Now,
                DataFinalAplicacao = DateTime.Now.AddDays(1),
                TurmasIds = new long[] { }
            };
            var results = ValidateModel(dto);
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.TurmasIds)) && r.ErrorMessage == "Pelo menos uma turma deve ser selecionada.");
        }

        [Fact]
        public void TurmasIds_Deve_Ser_Valido_Com_Um_Item()
        {
            var dto = new CriarProvaPresencaDto { NomeProva = "Teste", AnoProva = 2023, DataInicialAplicacao = DateTime.Now, DataFinalAplicacao = DateTime.Now.AddDays(1), TurmasIds = new long[] { 1 } };
            var results = ValidateModel(dto);
            Assert.DoesNotContain(results, r => r.MemberNames.Contains(nameof(CriarProvaPresencaDto.TurmasIds)));
        }

        [Fact]
        public void Dto_Completo_Valido_Nao_Deve_Ter_Erros_De_Validacao()
        {
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Prova Valida",
                AnoProva = 2024,
                DescricaoProva = "Descrição opcional",
                DataInicialAplicacao = new DateTime(2024, 3, 10),
                DataFinalAplicacao = new DateTime(2024, 3, 15),
                DataCorte = new DateTime(2024, 3, 12),
                VinculaAlunoCadernoExtra = true,
                TurmasIds = new long[] { 100, 101, 102 }
            };

            var results = ValidateModel(dto);
            Assert.Empty(results);
        }
    }
}