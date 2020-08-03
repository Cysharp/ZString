using System.Collections;
using System.Collections.Generic;

namespace Cysharp.Text
{
    /// <summary>
    /// Most IList interface-implementing classes implement the IReadOnlyList interface.
    /// This is for the rare class that does not implement the IList interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal readonly struct ReadOnlyListAdaptor<T> : IReadOnlyList<T>
    {
        readonly IList<T> _list;

        public ReadOnlyListAdaptor(IList<T> list) => _list = list;

        public T this[int index] => _list[index];

        public int Count => _list.Count;

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
