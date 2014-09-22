namespace T01SimpleTree
{
    using System;
    using System.Collections.Generic;    

    public class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T root)
        {
            this.root = new TreeNode<T>(root);
        }

        public void Add(T value)
        {
            this.root.Children.Add(new TreeNode<T>(value));
        }

        public void Add(TreeNode<T> node)
        {
            this.root.Children.Add(node);
        }

        public void Add(T value, T parent)
        {
            TreeNode<T> position = this.FindNode(parent);
            position.AddChild(value);
        }

        public void Add(TreeNode<T> value, T parent)
        {
            TreeNode<T> position = this.FindNode(parent);
            position.Children.Add(value);
        }

        public List<TreeNode<T>> FindLeafNodes()
        {
            Queue<TreeNode<T>> searcher = new Queue<TreeNode<T>>();
            searcher.Enqueue(root);
            List<TreeNode<T>> result = new List<TreeNode<T>>();
            while (searcher.Count > 0)
            {
                TreeNode<T> current = searcher.Dequeue();
                if (current.Children == null || current.Children.Count == 0)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        public TreeNode<T> Root()
        {
            return this.root;
        }

        public List<TreeNode<T>> FindMiddleNodes()
        {
            Queue<TreeNode<T>> searcher = new Queue<TreeNode<T>>();
            searcher.Enqueue(root);
            List<TreeNode<T>> result = new List<TreeNode<T>>();
            while (searcher.Count > 0)
            {
                TreeNode<T> current = searcher.Dequeue();
                if (current != this.root && current.Children != null && current.Children.Count > 0)
                {
                    result.Add(current);
                }
            }

            return result;
        }       

        private List<LinkedList<TreeNode<T>>> LongestPathsFromRoot()
        {
            Stack<LinkedList<TreeNode<T>>> searcher = new Stack<LinkedList<TreeNode<T>>>();
            List<LinkedList<TreeNode<T>>> allLeafPaths = new List<LinkedList<TreeNode<T>>>();
            LinkedList<TreeNode<T>> first = new LinkedList<TreeNode<T>>();
            first.AddFirst(root);
            searcher.Push(first);
            while (searcher.Count > 0)
            {
                LinkedList<TreeNode<T>> currentList = searcher.Pop();
                TreeNode<T> currentNode = currentList.Last.Value;
                if (currentNode.Children.Count == 0)
                {
                    allLeafPaths.Add(currentList);
                }
                else 
                { 
                    foreach (var child in currentNode.Children)
                    {
                        LinkedList<TreeNode<T>> newList = new LinkedList<TreeNode<T>>(currentList);
                        newList.AddLast(child);
                        searcher.Push(newList);
                    }
                }
            }

            
        }

        private TreeNode<T> FindNode(T value)
        {
            Queue<TreeNode<T>> searcher = new Queue<TreeNode<T>>();
            searcher.Enqueue(root);
            while (searcher.Count > 0)
            {
                TreeNode<T> current = searcher.Dequeue();
                if (current.Content == value)
                {
                    return current;
                }

                foreach (var child in current.Children)
                {
                    searcher.Enqueue(child);
                }
            }

            return null;
        }
    }
}
