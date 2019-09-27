using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using PostSharp.Aspects;

namespace MyFramework.Core.Aspects.PostSharp
{
    [Serializable]
    public class FluentValidateAspect:OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidateAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator,entity);
            }
            base.OnEntry(args);
        }

       
    }
}
