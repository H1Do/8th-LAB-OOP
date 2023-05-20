using StorageClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6th_LAB_OOP
{
    public class Designer // Класс, отвечающий за отрисовку и получения изображения в bitmap (растровое изображение)
    {
        private Bitmap bitmap; // Растровое изображение
        private Pen blackPen; // Ручка для рисования черным цветом
        private Pen redPen; // Ручка для рисования черным цветом
        private Brush brush; // Кисточка для заливки фигур цветом
        private Graphics g; // Класс, предоставляющий методы для рисования объектов
        private int height, width; // Храним высоту и ширину изображения

        public Designer(int width, int height) // Конструктор
        {
            this.width = width; this.height = height; // Будет нужно для ограничения в движении фигур
            bitmap = new Bitmap(width, height); // Определяем растровое изображение
            g = Graphics.FromImage(bitmap); // Определяем класс, отвечающий за рисование
            blackPen = new Pen(Color.Black); blackPen.Width = 2; // Определяем черную ручку
            redPen = new Pen(Color.Red); redPen.Width = 2; // Определяем красную ручку
            brush = new SolidBrush(Color.White);
        }

        public int getHeight() { return height; }

        public int getWidth() { return width; }

        public Bitmap GetBitmap() // Получить растровое изображение
        {
            return bitmap;
        }

        public void Clear() // Очистить изображение
        {
            g.Clear(Color.White);
        }

        public void DrawCircle(int x, int y, int radius, bool is_selected, Color color) // Нарисовать окружность 
        {
            g.DrawEllipse(((is_selected) ? redPen : blackPen), (x - radius), (y - radius), 2 * radius, 2 * radius);
            brush = new SolidBrush(color);
            g.FillEllipse(brush, (x - radius), (y - radius), 2 * radius, 2 * radius);
            brush.Dispose();
        }

        public void DrawTriangle(Point[] points, bool is_selected, Color color) // Нарисовать треугольник
        {
            g.DrawPolygon(((is_selected) ? redPen : blackPen), points);
            brush = new SolidBrush(color);
            g.FillPolygon(brush, points);
            brush.Dispose();
        }

        public void DrawSquare(int x, int y, int length, bool is_selected, Color color) // Нарисовать квадрат
        {
            g.DrawRectangle(((is_selected) ? redPen : blackPen), x, y, length, length);
            brush = new SolidBrush(color);
            g.FillRectangle(brush, x, y, length, length);
            brush.Dispose();
        }

        public void DrawAll(List storage, Designer designer) // Отрисовать всех фигуры
        {
            for (int i = 0; i < storage.GetSize(); i++)
                storage.Get(i).Draw(designer);
        }

        public void UnselectAll(List storage) // Убираем подчеркивание со всех окружностей
        {
            for (int i = 0; i < storage.GetSize(); i++)
                storage.Get(i).Unselect();
        }
    }
}
