using UnityEngine;

namespace Extensions
{
    public static class AsyncOperationExtension
    {
        public static AsyncOperationAwaiter GetAwaiter(this AsyncOperation asyncOperation) =>
            new AsyncOperationAwaiter(asyncOperation);
    }
}
