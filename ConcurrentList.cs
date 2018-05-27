using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Concurrent
{
    /// <summary>
    /// crude implementation of a concurrent list. yeah dont ask me, it works
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConcurrentList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        List<T> list = new List<T>();

        public T this[int index]
        {
            get
            {
                lock(list)
                {
                    return list[index];
                }
            }
            set
            {
                lock(list)
                {
                    list[index] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                lock(list)
                {
                    return list.Count;
                }
            }
        }

        public bool IsReadOnly
        {
            get
            {
                lock(list)
                {
                    return ((ICollection<T>)list).IsReadOnly;
                }
            }
        }

        public void Add(T item)
        {
            lock(list)
            {
                list.Add(item);
            }
        }

        public void Clear()
        {
            lock(list)
            {
                list.Clear();
            }
        }

        public bool Contains(T item)
        {
            lock(list)
            {
                return list.Contains(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock(list)
            {
                list.CopyTo(array, arrayIndex);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock(list)
            {
                return list.ToArray().AsEnumerable().GetEnumerator();
            }
        }

        public int IndexOf(T item)
        {
            lock(list)
            {
                return list.IndexOf(item);
            }
        }

        public void Insert(int index, T item)
        {
            lock(list)
            {
                list.Insert(index, item);
            }
        }

        public bool Remove(T item)
        {
            lock(list)
            {
                return list.Remove(item);
            }
        }

        public void RemoveAt(int index)
        {
            lock(list)
            {
                list.RemoveAt(index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            lock(list)
            {
                return list.ToArray().GetEnumerator();
            }
        }

        public void LockedForeach(Action<T> loop)
        {
            lock(list)
            {
                foreach(var v in list)
                {
                    loop(v);
                }
            }
        }
    }
}
