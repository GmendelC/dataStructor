using System;
using System.Text;

namespace Trees
{
    public delegate void Task<T>(T data);

    public class BST<T> where T : IComparable<T>
    {
        Node<T> root;

        public T Root { get { return root.data; } }

        public void Add(T item)//add 
        {
            if (root == null)
            {
                root = new Node<T>(item);
                return;
            }
            Node<T> tmp = root, parent = null;

            while (tmp != null)
            {
                parent = tmp;

                if (item.CompareTo(tmp.data) < 0) //item < tmp.data //go left
                    tmp = tmp.left;
                else
                    tmp = tmp.right;//item > tmp.data //go right

            }
            Node<T> n = new Node<T>(item);
            if (item.CompareTo(parent.data) < 0)
            {
                parent.left = n;
            }
            else
            {
                parent.right = n;
            }
        }

        
        public bool FindClosestAmount(T item, out T res)
        {
            res = default(T);

            bool ret = false;

            Node<T> tmp = root;

            while (tmp != null && tmp.data.CompareTo(item) != 0)
            {

                if (item.CompareTo(tmp.data) < 0) //item < tmp.data //go left and have biger
                {
                    res = tmp.data;
                    tmp = tmp.left;
                    ret = true;
                }
                else
                    tmp = tmp.right;//item > tmp.data //go right

            }

            if (tmp != null) // find this
            {
                res = tmp.data;
                ret = true;
            }

            return ret;

        }

        public bool Search(T item, out T res)
        {
            res = default(T);

            Node<T> tmp = root;

            while (tmp != null && tmp.data.CompareTo(item) != 0)
            {


                if (item.CompareTo(tmp.data) < 0) //item < tmp.data //go left
                    tmp = tmp.left;
                else
                    tmp = tmp.right;//item > tmp.data //go right

            }
            if (tmp != null)
            {
                res = tmp.data;
                return true;
            }
            return false;
        }
        //RemoveNode
        public bool Remove(T item)
        {
            Node<T> tmp = root, parent = null;

            while (tmp != null && tmp.data.CompareTo(item) != 0)
            {
                parent = tmp;

                if (item.CompareTo(tmp.data) < 0) //item < tmp.data //go left
                    tmp = tmp.left;
                else
                    tmp = tmp.right;//item > tmp.data //go right
            }

            return RemoveNode(tmp, parent);
        }

        private bool RemoveNode(Node<T> tmp, Node<T> parent)
        {
            if (tmp == null)
                return false;


            if (tmp.left == null && tmp.right == null)
            {
                RemoveLeaf(tmp, parent);
            }
            else if (tmp.left != null && tmp.right != null)
            {
                Remove2ChildNode(tmp, parent);
            }
            else
            {
                RemoveSingleChildNode(tmp, parent);
            }
            return true;
        }

        private void RemoveSingleChildNode(Node<T> tmp, Node<T> parent)//Remove Single Child
        {
            ///
            if (parent == null)
            {
                if (tmp.left != null)
                {
                    root = tmp.left;
                }
                else
                {
                    root = tmp.right;
                }
            }
            else
            {
                if (tmp.left != null)
                {
                    if (tmp.data.CompareTo(parent.data) < 0)
                    {
                        parent.left = tmp.left;
                    }
                    else
                    {
                        parent.right = tmp.left;
                    }
                }
                else
                {
                    if (tmp.data.CompareTo(parent.data) < 0)
                    {
                        parent.left = tmp.right;
                    }
                    else
                    {
                        parent.right = tmp.right;
                    }
                }
            }
        }

        private void Remove2ChildNode(Node<T> tmp, Node<T> parent)//Remove 2 Child
        {
            Node<T> parentChild = tmp;
            Node<T> child = tmp.right;

            while (child.left != null)
            {
                parentChild = child;
                child = child.left;
            }

            tmp.data = child.data;

            RemoveNode(child, parentChild);

        }

        private void RemoveLeaf(Node<T> tmp, Node<T> parent)//Remove Leaf
        {
            if (parent == null)
            {
                root = null;
            }
            else if (parent.left == tmp)
            {
                parent.left = null;
            }
            else
            {
                parent.right = null;
            }
        }

        public override string ToString()
        {
            return InOrder(root);
        }

        private string InOrder(Node<T> node)
        {
            if (node == null)
                return "";

            return $"{InOrder(node.left)} {node.data.ToString()}, {InOrder(node.right)}";
        }

        // amount of leaves
        public int GetLevels()
        {
            return GetLevels(root);
        }

        private int GetLevels(Node<T> root)
        {
            if (root == null) return 0;
            int leftCount = GetLevels(root.left);
            int rightCount = GetLevels(root.right);
            return Math.Max(leftCount, rightCount) + 1;
        }


        //Create Node
        class Node<z>
        {
            public z data;
            public Node<z> left;
            public Node<z> right;

            public Node(z data)
            {
                this.data = data;
                left = right = null;
            }
        }

    }
}
