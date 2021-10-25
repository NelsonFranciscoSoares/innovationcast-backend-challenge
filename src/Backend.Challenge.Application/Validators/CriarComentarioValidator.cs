using Backend.Challenge.Application.DataTransferObjets.Comentarios.Criar;
using FluentValidation;
using System;

namespace Backend.Challenge.Application.Validators
{
    public class CriarComentarioValidator : AbstractValidator<CriarComentarioInputDTO>
    {
        public CriarComentarioValidator()
        {
            RuleFor(c => c.EntidadeId)
                    .NotEmpty()
                    .WithMessage("Informe campo {PropertyName}")
                    .NotEqual(Guid.Empty)
                    .WithMessage("Campo {PropertyName} inválido");

            RuleFor(c => c.Autor)
                    .MaximumLength(200)
                    .WithMessage("Excedeu o tamanho máximo de {MaxLength} do campo {PropertyName}")
                    .NotEmpty()
                    .WithMessage("Informe campo {PropertyName}");

            RuleFor(c => c.Texto)
                    .MaximumLength(5000)
                    .WithMessage("Excedeu o tamanho máximo de {MaxLength} do campo {PropertyName}")
                    .NotEmpty()
                    .WithMessage("Informe campo {PropertyName}");
        }
    }
}
