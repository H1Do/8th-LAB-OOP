using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6th_LAB_OOP
{
    public class TreeProcessor : IObserver
    {
        private TreeNode root_node;
        private TreeView tree_view;

        public TreeProcessor(String form_name, TreeView tree_view) {
            root_node = new TreeNode(form_name);
            tree_view = new TreeView();
        }

        public void processNode(CShape shape)
        {
            processNodeRecurcive(root_node, shape);
        }

        private void processNodeRecurcive(TreeNode tn, CShape shape)
        {
            TreeNode child = new TreeNode();
            if (shape is CCircle) child.Text = "Circle";
            else if (shape is CTriangle) child.Text = "Triangle";
            else if (shape is CSquare) child.Text = "Square";
            else if (shape is CGroup group)
                for (int i = 0; i < group.getSize(); i++)
                    processNodeRecurcive(child, group.getShape(i));
            tn.Nodes.Add(child);
        }

        public void Update()
        {
            tree_view.Nodes.Clear();
            tree_view.Nodes.Add(root_node);
        }
    }
}
