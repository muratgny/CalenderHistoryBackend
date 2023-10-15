using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//We give types of attributes with Type. We use it before the method as an
                                                   //attribute like this: [ValidationAspect(typeof(CastoryValidator))]
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                //TODO - Add constant message type here
                throw new Exception("WrongValidationType");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)//We wanted it to work OnBefore(), we can use other abstract methods in
                                                                //MethodInterception class
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //A reflection example
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//Here, invocation is our method to be
                                                                                      //validated and arguments is the parameters of this method 
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
