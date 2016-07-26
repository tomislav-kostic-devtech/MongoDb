using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiService.Controllers;

namespace WebApiService
{
    public class InterceptLogAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Context.Kernel.Get<LogInterceptor>();
        }
    }
}