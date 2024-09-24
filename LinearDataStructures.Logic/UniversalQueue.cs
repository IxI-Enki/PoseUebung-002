using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Logic;

internal class UniversalQueue<T> : IUniversalQueue<T>
{
  #region FIELDS
  private readonly Queue<T> _queue;
  private readonly Stack<T> _stack;
  #endregion

  #region PROPERTIES
  public bool IsEmpty => _queue.Count == 0 && _stack.Count == 0;
  public int Count => _queue.Count + _stack.Count;
  #endregion

  public UniversalQueue()
  {
    _queue = new Queue<T>();
    _stack = new Stack<T>();
  }

  public void Enqueue(T item) => _queue.Enqueue(item);
  public void Push(T item) => _stack.Push(item);

  public T Dequeue()
  {
    if (IsEmpty) throw new InvalidOperationException("Cannot dequeue from an empty queue.");

    if (_queue.Count > 0) return _queue.Dequeue();
    else
    {
      while (_stack.Count > 0)
        _queue.Enqueue(_stack.Pop());
      return _queue.Dequeue();
    }
  }
  public T Pop()
  {
    if (IsEmpty) throw new InvalidOperationException("Cannot pop from an empty queue.");
    return _stack.Pop();
  }
  public T Peek()
  {
    if (IsEmpty) throw new InvalidOperationException("Cannot peek an empty queue.");

    if (_stack.Count > 0) return _stack.Peek();
    else
    {
      while (_queue.Count > 0)
        _stack.Push(_queue.Dequeue());
      return _stack.Peek();
    }
  }
  public void Clear()
  {
    _queue.Clear();
    _stack.Clear();
  }
}