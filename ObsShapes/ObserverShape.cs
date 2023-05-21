using System.Collections.Generic;
using _CShape;
using _Designer;

namespace _ObserverShape
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
}
