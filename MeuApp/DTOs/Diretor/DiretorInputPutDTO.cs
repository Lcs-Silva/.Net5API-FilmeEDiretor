using FluentValidation;

public class DiretorInputPutDTO {

    public string Nome { get; set; }
}

public class DiretorInputPutDTOValidator : AbstractValidator<DiretorInputPutDTO> {
    
    public DiretorInputPutDTOValidator() {

        RuleFor(d => d.Nome).NotNull().NotEmpty().WithMessage("O campo {PropertyName} não pode ser nulo ou vazio.");
        RuleFor(d => d.Nome).Length(1,100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracteres.");
    }
}