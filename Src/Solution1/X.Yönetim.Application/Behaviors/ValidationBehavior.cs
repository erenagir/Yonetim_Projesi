using ArxOne.MrAdvice.Advice;
using FluentValidation.Results;
using X.Yönetim.Application.Exceptions;

namespace X.Yönetim.Application.Behaviors
{
    public class ValidationBehavior : Attribute, IMethodAdvice
    {
        private readonly Type _validatorType;

        public ValidationBehavior(Type validatorType)
        {
            _validatorType = validatorType;// validator türü
        }

        public void Advise(MethodAdviceContext context)
        {
            
            //Metod çalışmadan önce 

            if (context.Arguments.Any())
            {
                var requestModel = context.Arguments[0]; //hangi model üzerinde calışacak 

                //Request model doğrulaması - Fluent Validation
                var validateMethod = _validatorType.GetMethod("Validate", new Type[] { requestModel.GetType() });
                var validatorInstance = Activator.CreateInstance(_validatorType); // methodu new ler
                if (validateMethod != null)
                {
                    var validationResult = (ValidationResult)validateMethod.Invoke(validatorInstance, new object[] { requestModel });
                    if (!validationResult.IsValid)
                    {
                        throw new ValidateException(validationResult);
                    }
                }
            }

            context.Proceed(); //Metodu çalıştırır


            //Metod çalıştıktan sonra 

        }
    }
}
