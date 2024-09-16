using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Extensions
{
    public struct AsyncOperationAwaiter : INotifyCompletion
    {
        private readonly AsyncOperation _asyncOperation;

        private Action _continuation;

        public AsyncOperationAwaiter(AsyncOperation asyncOperation) : this() => 
            _asyncOperation = asyncOperation;

        public bool IsCompleted => _asyncOperation.isDone;

        public AsyncOperation GetResult() => _asyncOperation;

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
            _asyncOperation.completed += OnCompleted    ;
        }

        private void OnCompleted(AsyncOperation operation) => 
            _continuation.Invoke();
    }
}
