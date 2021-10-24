using AutoMapper;
using Backend.Challenge.Kernel.Application.DataTransferObjects;
using Backend.Challenge.Kernel.Application.Services;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Backend.Challenge.Kernel.Application
{
    public abstract class BaseService : IBaseService
    {
        protected IMapper _mapper;
        protected IValidationContext _validationResult;

        protected BaseService(IMapper mapper, IValidationContext validationContext)
        {
            this._mapper = mapper;
            this._validationResult = validationContext;
        }

        protected void PreencherErros(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                this.PreencherErro(error.ErrorMessage);
            }
        }

        protected void PreencherErro(string mensagem)
        {
            this._validationResult.AdicionarErro( mensagem);
        }

        protected bool ExecutarValidacao<TV, TDTO>(TV validacao, TDTO dto) 
            where TV : AbstractValidator<TDTO> where TDTO : BaseDTO
        {
            var validator = validacao.Validate(dto);

            if (validator.IsValid) return true;

            PreencherErros(validator);

            return false;
        }
    }
}
