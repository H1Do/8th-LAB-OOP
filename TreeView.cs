using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using _IObservable;
using _IObserver;
using _MyList;
using _CShape;
using _Shapes;

namespace _TreeProcessor
{
    public class TreeProcessor : IObservable, IObserver
    {
        private TreeNode root_node;
        protected TreeView tree_view;
        private List<IObserver> observers;

        public TreeProcessor(String form_name, TreeView tree_view) {
            root_node = new TreeNode(form_name);
            this.tree_view = tree_view;
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
            tree_view.Nodes.Clear();
            root_node.Nodes.Clear();

            MyList list = (MyList)observable;

            for (int i = 0; i < list.GetSize(); i++)
                processNode(root_node, list.Get(i));

            tree_view.Nodes.Add(root_node);
            tree_view.ExpandAll();
        }

        public TreeNode getNode(int index)
        {
            return tree_view.Nodes[0].Nodes[index];
        }

        public int getSize()
        {
            return tree_view.Nodes[0].GetNodeCount(false);
        }

        public void ClearSelections()
        {
            tree_view.Nodes[0].BackColor = Color.Empty;
            foreach (TreeNode node in tree_view.Nodes[0].Nodes)
                node.BackColor = Color.Empty;
        }

        public void Select(TreeNode selected_node, bool is_multiply_selection)
        {
            if (!is_multiply_selection)
                ClearSelections();

            if (selected_node == root_node) 
                foreach (TreeNode node in tree_view.Nodes[0].Nodes) 
                    node.BackColor = Color.Red;

            while (selected_node.Parent != null && selected_node.Parent != root_node)
                selected_node = selected_node.Parent;

            selected_node.BackColor = Color.Red;
            NotifyObservers();
        }

        private void processNode(TreeNode tn, CShape shape)
        {
            TreeNode child = new TreeNode();
            child.BackColor = (shape.IsSelected()) ? Color.Red : Color.Empty;

            if (shape is CCircle) child.Text = "Circle";
            else if (shape is CTriangle) child.Text = "Triangle";
            else if (shape is CSquare) child.Text = "Square";
            else if (shape is CGroup group)
            {
                child.Text = "Group";
                for (int i = 0; i < group.getSize(); i++)
                    processNode(child, group.getShape(i));
            }

            tn.Nodes.Add(child);
        }
    }
}
