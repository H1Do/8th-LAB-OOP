using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using StorageClassLibrary;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace _6th_LAB_OOP
{
    public class CCircle : CShape
    {
        public CCircle(int x, int y, Color color) // Конструктор окружности 
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.length = 35; // Радиус
        }

        public override void Draw(Designer designer)
        {
            this.width = designer.getWidth();
            this.height = designer.getHeight();
            designer.DrawCircle(x, y, length, is_selected, color);
            observers.Changed(designer);
        }

        public override void ChangeSize(char type)
        {
            length += (type == '+') ? (CanChange(0, 0, 5) ? 5 : 0) : (CanChange(0, 0, -5) ? -5 : 0);
        }

        public override bool WasClicked(int x, int y)
        {
            return ((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y) <= length * length);
        }

        public override bool CanChange(int dx, int dy, int dlength)
        {
            return (x + dx + length + dlength < width &&
                    y + dy + length + dlength < height &&
                    x + dx - length - dlength > 0 &&
                    y + dy - length - dlength > 0 &&
                    length + dlength > 5);
        }

        public override void Save(StreamWriter stream)
        {
            stream.WriteLine("C");
            base.Save(stream);
        }
    }

    public class CTriangle : CShape
    {
        private Point[] points = new Point[3];

        public CTriangle(int x, int y, Color color)
        {
            this.x = x; this.y = y;
            this.color = color;
            this.length = 35; // Высота

            points[0].X = x; points[0].Y = y - length;
            points[1].X = x - length; points[1].Y = y + length / 2;
            points[2].X = x + length; points[2].Y = y + length / 2;
        }

        public override void Draw(Designer designer)
        {
            this.height = designer.getHeight();
            this.width = designer.getWidth();

            points[0].X = x; points[0].Y = y - length;
            points[1].X = x - length; points[1].Y = y + length / 2;
            points[2].X = x + length; points[2].Y = y + length / 2;

            designer.DrawTriangle(points, is_selected, color);
            observers.Changed(designer);
        }

        public override bool WasClicked(int x, int y)
        {
            int a = (points[0].X - x) * (points[1].Y - points[0].Y) - (points[1].X - points[0].X) * (points[0].Y - y);
            int b = (points[1].X - y) * (points[2].Y - points[1].Y) - (points[2].X - points[1].X) * (points[1].Y - y);
            int c = (points[2].X - x) * (points[0].Y - points[2].Y) - (points[0].X - points[2].X) * (points[2].Y - y);

            return (a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0);
        }

        public override bool CanChange(int dx, int dy, int dlength)
        {
            
            return (y + dy - length - dlength > 0 &&
                    y + length / 2 + dy + dlength / 2 < height &&
                    x + length + dx + dlength < width &&
                    x - length + dx - dlength > 0 &&
                    length + dlength > 10);
        }

        public override void ChangeSize(char type)
        {
            if (type == '+')
            {
                if (CanChange(0, 0, 5))
                {
                    points[0].Y += -5;
                    points[1].X += -5;
                    points[1].Y += 5;
                    points[2].X += 5;
                    points[2].Y += 5;
                    length += 5;
                }
            } else
            {
                if (CanChange(0, 0, -5))
                {
                    points[0].Y += 5;
                    points[1].X += 5;
                    points[1].Y += -5;
                    points[2].X += -5;
                    points[2].Y += -5;
                    length += -5;
                }
            }
        }
        public override void Save(StreamWriter stream)
        {
            stream.WriteLine("T");
            base.Save(stream);
        }
    }

    public class CSquare : CShape
    {
        private Point[] points = new Point[2];

        public CSquare(int x, int y, Color color)
        {
            this.length = 50;
            this.x = x;
            this.y = y;

            this.color = color;

            points[0].X = x - length / 2;
            points[0].Y = y - length / 2;
            points[1].X = x + length / 2;
            points[1].Y = y + length / 2;
        }

        public override void Draw(Designer designer)
        {
            this.height = designer.getHeight();
            this.width = designer.getWidth();

            points[0].X = x - length / 2;
            points[0].Y = y - length / 2;
            points[1].X = x + length / 2;
            points[1].Y = y + length / 2;

            designer.DrawSquare(points[0].X, points[0].Y, length, is_selected, color);
            observers.Changed(designer);
        }

        public override void ChangeSize(char type)
        {
            length += (type == '+' && CanChange(0, 0, 5)) ? 5 : (type == '-' && CanChange(0, 0, -5)) ? -5 : 0;

            x = points[0].X + length / 2;
            y = points[0].Y + length / 2;
        }

        public override bool CanChange(int dx, int dy, int dlength)
        {
            return (x + length / 2 + dx + dlength / 2 < width - 5 &&
                    y + length / 2 + dy + dlength < height - 5 &&
                    x - length / 2 + dx - dlength > 5 &&
                    y - length / 2 + dy - dlength > 5 &&
                    length > 10);
        }

        public override bool WasClicked(int x, int y)
        {
            return x >= this.x - length / 2 && y >= this.y - length / 2 && x <= this.x + length / 2 && y <= this.y + length / 2;
        }
        public override void Save(StreamWriter stream)
        {
            stream.WriteLine("S");
            base.Save(stream);
        }
    }

    public class CGroup : CShape
    {
        List shapes; // Используем собственный список

        public CGroup()
        {
            shapes = new List();
        }

        ~CGroup()
        {
            shapes.Clear();
        }
        
        public int getSize() 
        { 
            return shapes.GetSize(); 
        }

        public bool isEmpty()
        {
            return shapes.GetSize() == 0;
        }

        public void addShape(CShape shape)
        {
            shapes.Add(shape);
        }

        public CShape getShape(int index)
        {
            return shapes.Get(index);
        }

        public override void Draw(Designer designer)
        {
            x = 0; y = 0;
            for (int i = 0; i < shapes.GetSize(); i++)
            {
                shapes.Get(i).Draw(designer);
                x += shapes.Get(i).getX() / shapes.GetSize();
                y += shapes.Get(i).getY() / shapes.GetSize();
            }
            observers.Changed(designer);
        }

        public override void Select()
        {
            for (int i = 0; i < shapes.GetSize(); i++)
                shapes.Get(i).Select();

            is_selected = true;
        }

        public override void Unselect()
        {
            for (int i = 0; i < shapes.GetSize(); i++)
                shapes.Get(i).Unselect();

            is_selected = false;
        }

        public override void ChangeColor(Color color)
        {
            for (int i = 0; i < shapes.GetSize(); i++)
                shapes.Get(i).ChangeColor(color);
        }

        public override bool CanChange(int dx, int dy, int dlength)
        {
            for (int i = 0; i < shapes.GetSize(); i++)
                if (!shapes.Get(i).CanChange(dx, dy, dlength))
                    return false;
            return true;
        }

        public override void ChangeSize(char type)
        {
            if (CanChange(0, 0, (type == '+') ? 5 : -5))
                for (int i = 0; i < shapes.GetSize(); i++)
                    shapes.Get(i).ChangeSize(type);
        }

        public override void Move(int dx, int dy)
        {
            if (CanChange(dx, dy, 0))
                for (int i = 0; i < shapes.GetSize(); i++)
                    shapes.Get(i).Move(dx, dy);
            observable.NotifyObservers(dx, dy);
        }

        public override bool WasClicked(int x, int y)
        {
            for (int i = 0; i < shapes.GetSize(); i++)
                if (shapes.Get(i).WasClicked(x, y))
                    return true;
            return false;
        }

        public override void Save(StreamWriter stream)
        {
            stream.WriteLine("G");
            stream.WriteLine(getSize());
            for (int i = 0; i < getSize(); i++)
                getShape(i).Save(stream);
        }

        public override void Load(StreamReader stream, CShapeFactory shapeFactory)
        {
            char code; int size = Convert.ToInt32(stream.ReadLine());

            for (int i = 0; i < size; i++)
            {
                code = Convert.ToChar(stream.ReadLine());
                addShape(shapeFactory.createShape(code));
                getShape(getSize() - 1).Load(stream, shapeFactory);
            }
        }
    }
}