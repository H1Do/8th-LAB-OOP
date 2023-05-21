using _CShape;

namespace _CShapeFactory
{
    public abstract class CShapeFactory // Абстрактная фабрика для фигур
    {
        public abstract CShape createShape(char code);
        ~CShapeFactory() { }
    }
}
