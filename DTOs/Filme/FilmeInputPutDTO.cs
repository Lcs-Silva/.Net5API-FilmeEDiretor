using FluentValidation;

public class FilmeInputPutDTO {
    
    public string Titulo { get; set; }
    public string Ano { get; set; }
    public string Genero { get; set; }
    public long DiretorId { get; set; }
}

public class FilmeInputPutDTOValidator : AbstractValidator<FilmeInputPutDTO> {

    public FilmeInputPutDTOValidator() {
        
        RuleFor(f => f.Titulo).NotNull().NotEmpty().WithMessage("O campo {PropertyName} não pode ser nulo ou vazio.");
        RuleFor(f => f.Titulo).Length(1,100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracteres.");

        RuleFor(f => f.Ano).NotNull().NotEmpty().WithMessage("O campo {PropertyName} não pode ser nulo ou vazio.");
        RuleFor(f => f.Ano).Length(4).WithMessage("O campo {PropertyName} deve conter 4 caracteres.");

        RuleFor(f => f.Genero).NotNull().NotEmpty().WithMessage("O campo {PropertyName} não pode ser nulo ou vazio.");
        RuleFor(f => f.Genero).Length(1,100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracteres.");

        RuleFor(f => f.DiretorId).NotNull().NotEmpty().WithMessage("O campo {PropertyName} não pode ser nulo ou vazio.");
    }
}