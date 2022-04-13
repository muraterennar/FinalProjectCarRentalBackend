﻿using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        string _pattern;
        ICacheManager _cacheManager;

        public CacheRemoveAspect(ICacheManager cacheManager, string pattern)
        {
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            _pattern = pattern;
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
