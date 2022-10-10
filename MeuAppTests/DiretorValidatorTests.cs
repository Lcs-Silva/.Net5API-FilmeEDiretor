using System;
using Xunit;
using FluentValidation.TestHelper;

namespace MeuAppTests {
    public class DiretorA {

        [Fact]
        public void SeONomeDoDiretorVierNuloNaCriacaoDeveApresentarErro() {

            var validator = new DiretorInputPostDTOValidator();
            var dto = new DiretorInputPostDTO { Nome = null };
            var result = validator.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(diretor => diretor.Nome);
        }

        [Fact]
        public void SeONomeDoDiretorVierVazioNaCriacaoDeveApresentarErro() {

            var validator = new DiretorInputPostDTOValidator();
            var dto = new DiretorInputPostDTO { Nome = "" };
            var result = validator.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(diretor => diretor.Nome);
        }

        [Fact]
        public void SeONomeDoDiretorTiverMenosQueDoisCaracteresDeveApresentarErro() {

            var validator = new DiretorInputPostDTOValidator();
            var dto = new DiretorInputPostDTO { Nome = "A" };
            var result = validator.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(diretor => diretor.Nome);
        }
    }
}
