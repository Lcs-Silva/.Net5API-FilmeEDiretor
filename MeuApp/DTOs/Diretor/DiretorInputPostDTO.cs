using FluentValidation;

public class DiretorInputPostDTO {

    public string Nome { get; set; }
}

public class DiretorInputPostDTOValidator : AbstractValidator<DiretorInputPostDTO> {
    
    public DiretorInputPostDTOValidator() {
        
        RuleFor(d => d.Nome).NotNull().NotEmpty().WithMessage("O campo {PropertyName} não pode ser nulo ou vazio.");
        RuleFor(d => d.Nome).Length(2,100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracteres.");
    }
}