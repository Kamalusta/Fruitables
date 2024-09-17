﻿using Castle.DynamicProxy;

namespace Business.Helpers.Interceptors
{

    public abstract class MethodInterception : MethodInterceptorBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation)
        {

        }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception exception) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                isSuccess = false;
                OnException(invocation, exception);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
