using System;
using System.Drawing;
using System.IO;
using _ObservableShape;
using _ObserverShape;
using _CShapeFactory;
using _Designer;

namespace _CShape
{
    public abstract class CShape
    {
        protected bool is_selected;
        protected int length;
        protected int x, y;
        protected Color color;
        protected int height, width;
        public ObservableShape observable;
        public ObserverShape observers;

        public CShape()
        {
            observable = new ObservableShape();
            observers = new ObserverShape();
        }
        public virtual int getX() { return x; }
        public virtual int getY() { return y; }
        public virtual void Select() { is_selected = true; }
        public virtual void Unselect() { is_selected = false; }
        public virtual bool IsSelected() { return is_selected; }
        public virtual void ChangeColor(Color color) { this.color = color; }
        public virtual void Move(int dx, int dy) { if (CanChange(dx, dy, 0)) { x += dx; y += dy; observable.NotifyObservers(dx, dy); } }
        public virtual void Load(StreamReader stream, CShapeFactory shapeFactory)
        {
            string line = stream.ReadLine();
            string temp_str = "";
            int[] input = new int[3];
            int order = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (Char.IsNumber(line[i]))
                {
                    temp_str += line[i];
                }
                else
                {
                    input[order++] = Convert.ToInt32(temp_str);
                    temp_str = "";
                }
            }

            x = input[0];
            y = input[1];
            length = input[2];

            color = ColorTranslator.FromHtml(stream.ReadLine());
        }

        public virtual void Save(StreamWriter stream)
        {
            stream.Write(x.ToString() + " ");
            stream.Write(y.ToString() + " ");
            stream.WriteLine(length.ToString() + " ");
            stream.WriteLine(ColorTranslator.ToHtml(color));
        }

        public abstract bool CanChange(int dx, int dy, int dlength);
        public abstract void ChangeSize(char type);
        public abstract bool WasClicked(int x, int y);
        public abstract void Draw(Designer designer);
    }
}
