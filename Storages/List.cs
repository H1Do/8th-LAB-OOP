using System;
using _CShape;

namespace _List
{
    public class Node
    {
        public CShape shape;
        public Node next;

        public Node(CShape shape)
        {
            this.shape = shape;
            next = null;
        }
    }

    public class List
    {
        private Node head;
        private Node tail;
        private int count;

        public List()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public virtual void Add(CShape shape)
        {
            Node newNode = new Node(shape);

            if (count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }

            count++;
        }

        public virtual void Remove(CShape shape)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.shape == shape)
                {
                    if (previous != null)
                    {
                        previous.next = current.next;

                        if (current == tail)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = current.next;

                        if (current == tail)
                        {
                            tail = null;
                        }
                    }

                    count--;
                    break;
                }

                previous = current;
                current = current.next;
            }
        }

        public virtual void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            Node previous = null;

            for (int i = 0; i < index; i++)
            {
                previous = current;
                current = current.next;
            }

            if (previous != null)
            {
                previous.next = current.next;

                if (current == tail)
                {
                    tail = previous;
                }
            }
            else
            {
                head = current.next;

                if (current == tail)
                {
                    tail = null;
                }
            }

            count--;
        }

        public virtual void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public int GetSize()
        {
            return count;
        }

        public CShape Get(int index)
        {   
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = this.head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.shape;
                }

                currentIndex++;
                current = current.next;
            }

            return null;
        }
    }
}