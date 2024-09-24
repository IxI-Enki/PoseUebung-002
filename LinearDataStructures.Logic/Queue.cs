using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Logic;

internal class Queue<T> : IQueue<T>
{
  #region FIELDS
  private Element<T>? _first = null;
  private Element<T>? _last = null;
  #endregion

  #region PROPERTIES
  public int Count
  {
    get
    {
      int result = 0;
      Element<T> run = _first;
      while (run != null)
      {
        result++;
        run = run.Next;
      }
      return result;
    }
  }
  #endregion

  public void Clear()
  {
    _first = null;
    _last = null;
  }

  public T Dequeue()
  {
    if (_first == null) throw new InvalidOperationException("Queue is empty");
  
    Element<T> removeElement = _first;
    _first = _first.Next!;

    if (_first == null) _last = null;

    return removeElement.Data!;
  }

  public void Enqueue(T item)
  {
    if (item == null) throw new ArgumentNullException("item");

    if (_first == null)
    {
      _first = new Element<T>(item , null);
      _last = _first;
    }
    else
    {
      Element<T> newElement = new(item , null);
      _last!.Next = newElement;
      _last = newElement;
    }
  }
}
