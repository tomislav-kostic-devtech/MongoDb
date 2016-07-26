using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiService
{
    public class LogInterceptor : SimpleInterceptor
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public void Intercept(IInvocation invocation)
        //{
        //    log.Info("Started action: " + invocation.Request.Target.GetType().Name);

        //    invocation.Proceed();

        //    log.Info("Ended action: " + invocation.Request.Target.GetType().Name);

        //}
        protected override void BeforeInvoke(IInvocation invocation)
        {
            log.Info("Started action: [" + invocation.Request.Method.Name+"]");
        }

        protected override void AfterInvoke(IInvocation invocation)
        {
            log.Info("Ended action: [" + invocation.Request.Method.Name+"]");
        }
    }
}
