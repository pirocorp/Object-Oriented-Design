namespace Observer
{
    public interface IObservable<out TData>
    {
        void AttachObserver(IObserver<TData> observer);

        void DetachObserver(IObserver<TData> observer);

        void NotifyObservers();
    }
}
