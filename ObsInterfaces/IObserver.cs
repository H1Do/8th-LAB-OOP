using _IObservable;

namespace _IObserver
{
    public interface IObserver
    {
        void onObjectChanged(IObservable observable);
    }
}
