﻿using Automatica.Core.Internals.Cache.Common;

namespace Automatica.Core.Internals.Cache.Logic
{
    internal class LogicCacheFacade : ILogicCacheFacade
    {
        private readonly ILinkCache _linkCache;

        public LogicCacheFacade(ILogicInstanceCache instanceCache, ILogicPageCache pageCache, ILogicTemplateCache templateCache, ILinkCache linkCache, ILogicNodeInstanceCache logicNodeInstanceCache)
        {
            _linkCache = linkCache;
            InstanceCache = instanceCache;
            PageCache = pageCache;
            TemplateCache = templateCache;
            LogicNodeInstanceCache = logicNodeInstanceCache;
        }

        public ILogicInstanceCache InstanceCache { get; }
        public ILogicPageCache PageCache { get; }
        public ILogicTemplateCache TemplateCache { get; }
        public ILogicNodeInstanceCache LogicNodeInstanceCache { get; }

        public void ClearInstances()
        {
            InstanceCache.Clear();
            PageCache.Clear();
            _linkCache.Clear();

            LogicNodeInstanceCache.Clear();
        }
    }
}
