using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using _List;
using _IObservable;
using _IObserver;
using _TreeProcessor;
using _CShape;
using _CShapeFactory;

namespace _MyList
{
    public class MyList : List, IObserver, IObservable
    {
        private List<IObserver> observers;

        public MyList() : base() {
            observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.onObjectChanged(this);
            }
        }

        public void onObjectChanged(IObservable observable)
        {
            TreeProcessor tree = (TreeProcessor)observable;

            for (int i = 0; i < this.GetSize(); i++)
            {
                this.Get(i).Unselect();
                if (tree.getNode(i).BackColor == Color.Red)
                    this.Get(i).Select();
            }

            NotifyObservers();
        }

        public void LoadShapes(StreamReader stream, CShapeFactory shapeFactory)
        {
            char code; int size = Convert.ToInt32(stream.ReadLine());

            for (int i = 0; i < size; i++)
            {
                code = Convert.ToChar(stream.ReadLine());
                Add(shapeFactory.createShape(code));
                this.Get(this.GetSize() - 1).Load(stream, shapeFactory);
            }

            NotifyObservers();
        }

        public override void Add(CShape shape)
        {
            base.Add(shape);
            NotifyObservers();
        }

        public override void Remove(CShape shape)
        {
            base.Remove(shape);
            for (int i = 0; i < GetSize(); i++)
                if (Get(i).observable.IsObserver(shape))
                    Get(i).observable.RemoveObserver(shape);

            shape.observers.ClearObservables();
            shape.observable.ClearObservers();
            NotifyObservers();
        }

        public override void RemoveAt(int index)
        {
            base.RemoveAt(index);
            NotifyObservers();
        }

        public override void Clear()
        {
            base.Clear(); 
            NotifyObservers();
        }

        public void SelectShapeAt(int index) // Добавим метод выделения, чтобы можно было отправлять "наблюдателям" его выполнение
        {
            this.Get(index).Select();
            NotifyObservers();
        }
    }
}
