using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsOfPesho
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int n = line[0];
            int m = line[1];
            int h = line[2];
            ICollection<int> hospitals = new HashSet<int>();
            line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            foreach (var hospital in line)
            {
                hospitals.Add(hospital - 1);
            }

            var nodes = new DijkstraNode[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new DijkstraNode(long.MaxValue);
            }

            for (int i = 0; i < m; i++)
            {
                line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                var toFirst = new Edge(line[1] - 1, line[2]);
                var toSecond = new Edge(line[0] - 1, line[2]);
                nodes[line[0] - 1].Connections.Add(toFirst);
                nodes[line[1] - 1].Connections.Add(toSecond);
            }

            long best = long.MaxValue;

            foreach (var hosp in hospitals)
            {                
                for (int i = 0; i < n; i++)
                {
                    nodes[i].DijkstraDistance = long.MaxValue;
                }

                PriorityQueue<DijkstraNode> dijkstras = new PriorityQueue<DijkstraNode>();
                nodes[hosp].DijkstraDistance = 0;                
                dijkstras.Enqueue(nodes[hosp]);

                while (dijkstras.Count > 0)
                {
                    var dijkstra = dijkstras.Dequeue();
                    foreach (var path in dijkstra.Connections)
                    {
                        long curDistance = path.Length + dijkstra.DijkstraDistance;
                        if (curDistance < nodes[path.Target].DijkstraDistance)
                        {
                            nodes[path.Target].DijkstraDistance = curDistance;
                            dijkstras.Enqueue(nodes[path.Target]);
                        }
                    }
                }

                long current = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!hospitals.Contains(i))
                        current += nodes[i].DijkstraDistance;
                }

                if (current < best) best = current;
            }
            Console.WriteLine(best);
        }
    }

    public class DijkstraNode : IComparable<DijkstraNode>
    {
        private long dijkstraDistance;
        private List<Edge> connections;

        public DijkstraNode(long distance)
        {
            this.dijkstraDistance = distance;
            this.connections = new List<Edge>();
        }

        public long DijkstraDistance
        {
            get
            {
                return this.dijkstraDistance;
            }

            set
            {
                this.dijkstraDistance = value;
            }
        }

        public List<Edge> Connections
        {
            get
            {
                return this.connections;
            }
        }

        public int CompareTo(DijkstraNode other)
        {
            return this.dijkstraDistance.CompareTo(other.DijkstraDistance);
        }
    }

    public class Edge
    {
        private int target;
        private int length;

        public Edge(int target, int length)
        {
            this.target = target;
            this.length = length;
        }

        public int Length
        {
            get
            {
                return this.length;
            }
        }

        public int Target
        {
            get
            {
                return this.target;
            }
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private T[] heap;
        private int index;

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length - 1)
            {
                IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            int minChild;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = rootIndex * 2 + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }
                else if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            T[] copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }
}
