using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public abstract class ViewBase : MonoBehaviour
    {
        protected List<IDisposable> _disposables;

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}