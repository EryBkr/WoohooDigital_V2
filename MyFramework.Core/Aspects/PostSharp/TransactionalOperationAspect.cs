using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PostSharp.Aspects;

namespace MyFramework.Core.Aspects.PostSharp
{
    [Serializable]
    public class TransactionalOperationAspect:OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;
        public TransactionalOperationAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionalOperationAspect()
        {
            
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
           
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }


    }
}
