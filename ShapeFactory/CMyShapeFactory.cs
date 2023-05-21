using System.Drawing;
using _CShapeFactory;
using _Shapes;
using _CShape;

namespace _CMyShapeFactory
{
    public class CMyShapeFactory : CShapeFactory // Вполне конкретная фабрика для CCircle, CTriangle, CSquare и CGroup
    {
        public override CShape createShape(char code)
        {
            CShape shape = null;
            switch (code)
            {
                case 'C':
                    shape = new CCircle(0, 0, Color.White);
                    break;
                case 'T':
                    shape = new CTriangle(0, 0, Color.White);
                    break;
                case 'S':
                    shape = new CSquare(0, 0, Color.White);
                    break;
                case 'G':
                    shape = new CGroup();
                    break;
            }
            return shape;
        }
    }
}
