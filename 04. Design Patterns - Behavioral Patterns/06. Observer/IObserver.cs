namespace Observer
{
    public interface IObserver<in TData>
    {
        public void Update(TData data);
    }
}
