namespace T11to13BasicADTs
{
    using System;
    using System.Text;

    public class LinkedList<T>
    {
        private ListItem<T> firstElement;

        public LinkedList()
        {
            this.FirstElement = null;
        }

        public ListItem<T> FirstElement
        {
            get
            {
                return this.firstElement;
            }

            protected set
            {
                this.firstElement = value;
            }
        }

        // Also simpler if we are keeping a tail field.
        public void AddLast(T item)
        {
            ListItem<T> toAdd = new ListItem<T>(item);
            if (this.FirstElement == null)
            {
                this.FirstElement = toAdd;
            }
            else
            {
                ListItem<T> last = this.FirstElement;
                while (last.NextField != null)
                {
                    last = last.NextField;
                }

                last.NextField = toAdd;                
            }
        }

        public void AddFirst(T item)
        {
            ListItem<T> toAdd = new ListItem<T>(item, this.FirstElement);
            this.FirstElement = toAdd;
        }

        // This operation is much simpler if we are using a doubly linked list.
        public bool AddBefore(T before, T toAdd)
        {
            ListItem<T> position = this.Find(before);
            if (position == null)
            {
                return false;
            }

            ListItem<T> positionBefore = this.FirstElement;
            while (positionBefore.NextField != position)
            {
                positionBefore = positionBefore.NextField;
            }

            ListItem<T> add = new ListItem<T>(toAdd, positionBefore.NextField);
            positionBefore.NextField = add;
            return true;
        }

        public bool AddAfter(T after, T toAdd)
        {
            ListItem<T> position = this.Find(after);
            if (position == null)
            {
                return false;
            }

            ListItem<T> add = new ListItem<T>(toAdd, position.NextField);
            position.NextField = add;
            return true;
        }

        public T First()
        {
            return this.FirstElement.Field;
        }

        public T Last()
        {
            ListItem<T> last = this.FirstElement;
            while (last.NextField != null)
            {
                last = last.NextField;
            }

            return last.Field;
        }

        public T RemoveFirst()
        {
            if (this.FirstElement == null)
            {
                throw new InvalidOperationException("List is empty.");
            }

            T removed = this.FirstElement.Field;
            this.FirstElement = this.FirstElement.NextField;
            return removed;
        }

        // This operation is much simpler if we are using a doubly linked list and tail.
        public T RemoveLast()
        {
            if (this.FirstElement == null)
            {
                throw new InvalidOperationException("List is empty.");
            }
            else if (this.FirstElement.NextField == null)
            {
                T toReturn = this.FirstElement.Field;
                this.FirstElement = null;
                return toReturn;
            }

            ListItem<T> last = this.FirstElement;
            ListItem<T> beforeLast = this.FirstElement;
            while (last.NextField != null)
            {
                beforeLast = last;
                last = last.NextField;                
            }
            
            beforeLast.NextField = null;
            return last.Field;                        
        }

        // This should ideally be a field that changes every time we add an item but the task stipulated we were supposed to have only 1 field, firstElement.
        public int Count()
        {
            int count = 0;
            ListItem<T> counter = this.FirstElement;
            while (counter != null)
            {
                count++;
                counter = counter.NextField;              
            }

            return count;
        }

        public void Clear()
        {
            this.FirstElement = null;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count()];
            ListItem<T> element = this.FirstElement;
            int index = 0;
            while (element != null)
            {
                array[index] = element.Field;
                index++;
            }

            return array;
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            ListItem<T> element = this.FirstElement;
            while (element != null)
            {
                if (element.NextField != null)
                {
                    result.Append(string.Format("{0}, ", element.ToString()));
                }
                else
                {
                    result.Append(element.ToString());
                }

                element = element.NextField;
            }

            return result.ToString();
        }

        private ListItem<T> Find(T item)
        {
            ListItem<T> search = this.FirstElement;
            while (search != null && !search.Field.Equals(item))
            {
                search = search.NextField;
            }

            return search;
        }
    }
}
