using _IObserver;

namespace _IObservable
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void NotifyObservers();
    }
}
