using System;
using System.Collections.Generic;

namespace Utils
{
    public abstract class Disposables
    {
        protected List<IDisposable> _disposables;
        private IDisposable _disposableImplementation;
        
        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}