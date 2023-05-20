using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StorageClassLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _6th_LAB_OOP
{
    public partial class Form1 : Form
    {
        private MyList shapes;
        private Designer designer;
        private CShapeFactory shapeFactory;
        private Observervable observervable;
        private TreeProcessor tree_processor;

        private Color current_color;
        private String current_shape;
        private String file_name = "";

        private bool is_ctrl_pressed = false;

        public Form1()
        {
            InitializeComponent();
            shapes = new MyList();
            designer = new Designer(pictureBox.Width, pictureBox.Height);
            shapeFactory = new CMyShapeFactory();
            observervable = new Observervable();
            tree_processor = new TreeProcessor("Form1", nodeTreeView);

            this.MouseWheel += new MouseEventHandler(this_MouseWheel); // Изменение размера фигуры вращением колёсика
            this.MouseWheel += new MouseEventHandler(shapesComboBox_MouseWheel); // Запрещаем управление comboBox с помощью колеса
            shapesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // Запрещаем ввод своих значений в combobox
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            designer.DrawAll(shapes, designer);
        }

        private void RefreshWindow()
        {
            designer.Clear(); // Очищаем изображение, отрисовываем все фигуры и передаём изобажение pictureBox'у
            designer.DrawAll(shapes, designer);
            pictureBox.Image = designer.GetBitmap();
        }

        private void NewShare(int x, int y)
        {
            if (current_shape == null)
                return;

            designer.UnselectAll(shapes);
            designer.DrawAll(shapes, designer);

            CShape new_obj;

            if (this.current_shape == "Circle")
                new_obj = new CCircle(x, y, current_color);
            else if (this.current_shape == "Triangle")
                new_obj = new CTriangle(x, y, current_color);
            else if (this.current_shape == "Square")
                new_obj = new CSquare(x, y, current_color);
            else
                return;

            new_obj.Draw(designer);
            pictureBox.Image = designer.GetBitmap();
            shapes.Add(new_obj);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            designer.Clear();
            bool was_clicked = false;

            for (int i = 0; i < shapes.GetSize(); i++)
                if (shapes.Get(i).WasClicked(e.X, e.Y))
                {
                    was_clicked = true;
                    if (!is_ctrl_pressed)
                        designer.UnselectAll(shapes);
                    shapes.Get(i).Select();
                }
                        
            if (!was_clicked)
            {
                NewShare(e.X, e.Y);
                return;
            }

            RefreshWindow();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int dx = 0, dy = 0;
            switch (e.KeyCode)
            {
                case Keys.ControlKey: // Если это CTRL, то мы это запоминаем и выходим
                    is_ctrl_pressed = true;
                    break;
                case Keys.Delete: // Если это DEL, то мы удаляем все выделенные элементы
                    List order_to_delete = new List();
                    for (int i = 0; i < shapes.GetSize(); i++)
                        if (shapes.Get(i).IsSelected())
                            order_to_delete.Add(shapes.Get(i));
                    for (int i = 0; i < order_to_delete.GetSize(); i++)
                        shapes.Remove(order_to_delete.Get(i));
                    break;
                case Keys.S:
                    if (file_name != "")
                        saveBtn_Click(sender, e);
                    break;
                case Keys.V:
                    if (file_name != "")
                        loadBtn_Click(sender, e);
                    break;
                case Keys.Up: // Если это Up, то все выделенные фигуры движутся наверх
                    dx = 0; dy = -5;
                    break;
                case Keys.Down: // Если это Down, то все выделенные фигуры движутся вниз
                    dx = 0; dy = 5;
                    break;
                case Keys.Left: // Если это Left, то все выделенные фигуры движутся влево
                    dx = -5; dy = 0;
                    break;
                case Keys.Right: // Если это Right, то все выделенные фигуры движутся вправо
                    dx = 5; dy = 0;
                    break; 
            }
            if (dx != 0 || dy != 0)
                for (int i = 0; i < shapes.GetSize(); i++)
                    if (shapes.Get(i).IsSelected())
                        shapes.Get(i).Move(dx, dy);


            RefreshWindow();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                is_ctrl_pressed = false;
        }

        void this_MouseWheel(object sender, MouseEventArgs e)
        {
            if (is_ctrl_pressed)
            {
                if (e.Delta < 0) // Уменьшаем все фигуры
                {
                    for (int i = 0; i < shapes.GetSize(); i++)
                        if (shapes.Get(i).IsSelected())
                            shapes.Get(i).ChangeSize('+');
                }
                else // Увеличиваем все фигуры
                {
                    for (int i = 0; i < shapes.GetSize(); i++)
                        if (shapes.Get(i).IsSelected())
                            shapes.Get(i).ChangeSize('-');
                }
            }
            RefreshWindow();
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            var clr_dialog = new ColorDialog();
            if (clr_dialog.ShowDialog() == DialogResult.OK)
            {
                colorBtn.BackColor = clr_dialog.Color;
                current_color = clr_dialog.Color; // Запоминаем для появляющихся фигур
            }
             
            chosedShare.ForeColor = current_color;

            for (int i = 0; i < shapes.GetSize(); i++)
                if (shapes.Get(i).IsSelected())
                    shapes.Get(i).ChangeColor(current_color);

            RefreshWindow();
        }

        private void shapesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_shape = shapesComboBox.SelectedItem.ToString();
            chosedShare.Text = current_shape;
            chosedShare.ForeColor = current_color;
        }

        private void shapesComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Left)) // Запрещаем shapesComboBox изменять выбранное значение с помощью стрелок на клавиатуре
                e.Handled = true;
        }

        private void shapesComboBox_MouseWheel(object sender, MouseEventArgs e) // Запрещаем shapesComboBox изменять выбранное значение с помощью колеса мыши
        {
            if ((e.Delta > 0) || e.Delta < 0)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void groupBtn_Click(object sender, EventArgs e)
        {
            CGroup group = new CGroup();

            List order_to_delete = new List(); // Список CShape, которые мы удалим из списка всех CShape

            for (int i = 0; i < shapes.GetSize(); i++) 
                if (shapes.Get(i).IsSelected())
                {
                    order_to_delete.Add(shapes.Get(i)); 
                    group.addShape(shapes.Get(i));
                }

            for (int i = 0; i < order_to_delete.GetSize(); i++)
                shapes.Remove(order_to_delete.Get(i));

            if (!group.isEmpty())
                shapes.Add(group);

            RefreshWindow();
            ActiveControl = pictureBox;
        }

        private void ungroupBtn_Click(object sender, EventArgs e)
        {
            List order_to_add = new List(); // Список всех CShape, в которых храним те CShape, которые позже поместим в список всех CShape

            for (int i = 0; i < shapes.GetSize(); i++)
                if (shapes.Get(i) is CGroup group && shapes.Get(i).IsSelected()) {
                    for (int j = 0; j < group.getSize(); j++)
                        order_to_add.Add(group.getShape(j));
                    shapes.Remove(group);
                }

            for (int i = 0; i < order_to_add.GetSize(); i++)
                shapes.Add(order_to_add.Get(i));

            RefreshWindow();
            ActiveControl = pictureBox;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (file_name == "")
                return;

            StreamWriter stream = new StreamWriter(file_name, false);
            stream.WriteLine(shapes.GetSize());
            for (int i = 0; i < shapes.GetSize(); i++)
                shapes.Get(i).Save(stream);
            stream.Close();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            if (file_name == "")
                return;
            shapes.Clear();

            StreamReader stream = new StreamReader(file_name, false);
            shapes.LoadShapes(stream, shapeFactory);
            stream.Close();

            RefreshWindow();
        }

        private void fileDialogBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file_name = openFileDialog.FileName;
                loadBtn.Enabled = true;
                saveBtn.Enabled = true;
            }
            openFileDialog.Dispose();
        }
    }
}
