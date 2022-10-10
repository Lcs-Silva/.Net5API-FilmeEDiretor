using System;
using Xunit;
using FluentValidation.TestHelper;

namespace MeuAppTests {
    public class FilmeValidatorTests {

        [Fact]
        public void SeOTituloDoFilmeVierNuloNaCriacaoDeveApresentarErro() {

            var validator = new FilmeInputPostDTOValidator();
            var dto = new FilmeInputPostDTO { Titulo = null };
            var result = validator.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(filme => filme.Titulo);
        }

        [Fact]
        public void SeOTituloDoFilmeVierVazioNaCriacaoDeveApresentarErro() {

            var validator = new FilmeInputPostDTOValidator();
            var dto = new FilmeInputPostDTO { Titulo = "" };
            var result = validator.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(filme => filme.Titulo);
        }
    }
}
