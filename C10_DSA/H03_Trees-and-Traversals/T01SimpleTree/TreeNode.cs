namespace T01SimpleTree
{
    using System.Collections.Generic;

    public class TreeNode<T>    
    {
        private T content;
        private List<TreeNode<T>> children;
        private TreeNode<T> parent;

        public TreeNode(T content)
        {
            this.content = content;
            this.children = new List<TreeNode<T>>();
            this.parent = null;
        }

        public List<TreeNode<T>> Children
        {
            get
            {
                return this.children;                
            }

            set
            {
                this.children = value;
            }
        }

        public TreeNode<T> Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                this.parent = value;
            }
        }

        public T Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
        }
        
        public void AddChild(T content)
        {            
            this.children.Add(new TreeNode<T>(content));
        }        
    }
}
