using _Designer;
using System.Collections.Generic;
using System.Linq;
using _CShape;

namespace _ObservableShape
{
    public class ObservableShape
    {
        public List<CShape> observers;

        public ObservableShape()
        {
            observers = new List<CShape>();
        }

        public void NotifyObservers(int dx, int dy)
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
