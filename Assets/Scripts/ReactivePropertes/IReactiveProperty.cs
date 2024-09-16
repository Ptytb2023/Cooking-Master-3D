using System;

namespace ReactivePropertes
{
  
    public interface IReactiveProperty<T> : IObservable<T>
    {
        T Value { get; }
    }

    public interface IObservable<T>
    {
        void Subscribe(Action<T> subscriber);
        void SubscribeAndUpdate(Action<T> subscriber);
        void Unsubscribe(Action<T> subscriber);
    }
}
