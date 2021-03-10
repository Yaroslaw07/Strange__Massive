using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Strange__Massive
{
    public class LinkedList<T> : ICollection<T>, IEnumerable<T>, IList<T>
    {
        public bool IsReadOnly => false;

        public Node<T> Head { get; set; }

        public int Count { get; protected set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("Index out of range");

                Node<T> result = Head;

                int indexForCheck = 0;

                while (indexForCheck != index)
                {
                    indexForCheck++;

                    result = result.Next;
                }

                return result.Value;

            }

            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("Index out of range");

                Node<T> result = Head;

                int indexForCheck = 0;

                while (indexForCheck != index)
                {
                    indexForCheck++;

                    result = result.Next;
                }

                result.Value = value;
            }

        }

        public LinkedList() { Count = 0; }

        public LinkedList(T headValue)
        {
            Head = new Node<T>(headValue);
            Count = 1;
        }

        public LinkedList(IEnumerable<T> values)
        {
            IEnumerator<T> enumerator = values.GetEnumerator();
            Node<T> currentNode;

            if (enumerator.MoveNext())
            {
                Head = new Node<T>(enumerator.Current);
                currentNode = Head;

                Count = 1;
            }
            else
            {
                return;
            }

            while (enumerator.MoveNext())
            {
                Node<T> newNode = new Node<T>(enumerator.Current);
                currentNode.Next = newNode;
                currentNode = newNode;
                Count++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            Node<T> currentHead = Head;
            Node<T> newHead = new Node<T>(item, currentHead);
            Head = newHead;
            Count++;
        }

        public void Clear()
        {
            Head = null;
        }

        public bool Contains(T item)
        {
            foreach (T collectionItem in this)
            {
                if (collectionItem.Equals(item)) return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> currentNode = Head;
            if (currentNode == null) return;

            while (arrayIndex < array.Length && Count - arrayIndex >= 0)
            {
                array[arrayIndex] = currentNode.Value;
                currentNode = currentNode.Next;
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            Node<T> current = Head;

            if (current.Value.Equals(item))
            {
                Head = current.Next;
                Count--;
                return true;
            }

            Node<T> previous = Head;

            current = current.Next;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    previous.Next = current.Next;
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public LinkedList<T> Reverse()
        {
            var result = new LinkedList<T>();

            foreach (var item in this)
            {
                result.Add(item);
            }
            return result;
        }

        public int IndexOf(T item)
        {
            int index = -1;

            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException("Index out of range");

            Count++;
            if (index == 0)
            {
                this.Add(item);
            }
            else if (index != Count)
            {
                Node<T> currentNode = Head;
                for (int i = 1; i != index; i++)
                {
                    currentNode = currentNode.Next;
                }

                Node<T> newNode = new Node<T>(item, currentNode.Next);

                currentNode.Next = newNode;

            }
            else
            {
                Node<T> Current = Head;
                while (Current.Next != null)
                {
                    Current = Current.Next;
                }
                Node<T> newNode = new Node<T>(item);

                Current.Next = newNode;
            }

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("Index out of range");

            Count--;
            if (index == 0)
            {
                Head = Head.Next;

            }
            else
            {
                Node<T> previous = Head;
                for (int i = 1; i != index; i++)
                {
                    previous = previous.Next;
                }
                Node<T> current = previous.Next;
                previous.Next = current.Next;
            }

        }
    }

    //////////////////////////////////////////////////

    public class Enumerator<T> : IEnumerator<T>
    {
        private LinkedList<T> list = null;
        private Node<T> currentNode = null;
        private int index = -1;

        public Enumerator(LinkedList<T> linkedList)
        {
            list = linkedList;
        }

        public bool MoveNext()
        {
            currentNode = index < 0 ? list.Head : currentNode.Next;
            index++;
            return currentNode != null;
        }

        public void Reset()
        {
            currentNode = null;
            index = -1;
        }

        public T Current => currentNode.Value;

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }



    //////////////////////////////////////////////////


    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
