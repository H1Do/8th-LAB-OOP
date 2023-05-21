using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _6th_LAB_OOP
{
    public class ObserverShape
    {
        public List<CShape> observable;
        public ObserverShape()
        {
            observable = new List<CShape>();
        }

        public void AddObservable(CShape element)
        {
            observable.Add(element);
        }
        public void RemoveObservable(CShape element)
        {
            observable.Remove(element);
        }
        public bool IsObservable(CShape element)
        {
            return observable.Contains(element);
        }
        public void ClearObservables()
        {
            observable.Clear();
        }
        public void Changed(Designer designer)
        {
            foreach (CShape shape in observable)
            {
                shape.observable.ShowLines(shape.getX(), shape.getY(), designer);
            }
        }
    }

    public class ObservableShape
    {
        public List<CShape> observers;

        public ObservableShape()
        {
            observers = new List<CShape>();
        }

        public void NotifyObservers(int dx ,int dy)
        {
            for (int i = 0; i < observers.Count(); i++)
            {
                observers[i].Move(dx, dy);
            }
        }

        public void AddObserver(CShape observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(CShape observer)
        {
            observers.Remove(observer);
        }

        public void ClearObservers()
        {
            observers.Clear();
        }

        public bool IsObserver(CShape observer)
        {
            return observers.Contains(observer);
        }

        public void ShowLines(float x0, float y0, Designer designer)
        {
            foreach (CShape shape in observers)
            {
                designer.DrawLine(x0, y0, shape.getX(), shape.getY());
            }
        }
    }
}
