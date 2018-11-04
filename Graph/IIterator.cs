using System;

namespace Graph
{
    public interface IIterator
    {
        bool MoveNext();
        Object Current { get; }
        void Reset();
    }
}