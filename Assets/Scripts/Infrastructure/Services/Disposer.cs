using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class Disposer : IService
    {
        private List<IDisposable> _disposables = new();
        
        public void Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        public void DisposeAll()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}