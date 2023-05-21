using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6th_LAB_OOP
{
    public interface IObserver
    {
        void onObjectChanged(IObservable observable);
    }

    public interface IObservable
    {
        void AddObservable(IObserver observer);
        // void RemoveObservable(IObserver observer);
        void NotifyObservers();
    }
}
