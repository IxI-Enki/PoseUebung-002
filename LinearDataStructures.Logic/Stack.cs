using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Logic;

internal class Stack<T> : IStack<T>
{
  public bool IsEmpty => Count == 0;

  #region FIELDS
  private Element<T>? _head = null;
  #endregion

  #region PROPERTIES
  public int Count
  {
    get
    {
      int result = 0;
      Element<T>? run = _head;
      while (run != null)
      {
        result++;

        /*   run = run.Next ?? null;
                * is the same as:
                    run = run.Next != null ? run.Next : null;
                */
        run = run.Next ?? null;
      }
      return result;
    }
  }
  #endregion

  public void Clear() => _head = null;

  public T Peek()
  {
    if (IsEmpty)
      throw new InvalidOperationException("Cannot peek an empty stack.");

    return _head!.Data!;
  }

  public T Pop()
  {
    if (IsEmpty)
      throw new InvalidOperationException("Cannot pop from an empty stack.");

    T item = _head!.Data!;
    _head = _head.Next;
    return item;
  }

  public void Push(T? item)
  {
    var newElement = new Element<T>(item , _head);
    _head = newElement;
  }
}
