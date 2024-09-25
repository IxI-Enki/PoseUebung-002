# PoseUebung-002 -- Linear Data Structures


# - Queue:  <sub><sup> (*passed Unit-Tests:* ***20/20***) </sup></sub>
> FIELDS:
```c#
   private Element<T>? _first = null;
   private Element<T>? _last = null;
```

> PROPERTIES:
```c#
public int Count
{
  get
  {
    int result = 0;
    Element<T>? run = _first;
    while (run != null)
    {
      result++;
      run = run!.Next!;
    }
    return result;
  }
}
```

> METHODS:
```c#
  public void Clear()
  {
    _first = null;
    _last = null;
  }
```

```c#
  public T Dequeue()
  {
    if (_first == null) throw new InvalidOperationException("Cannot dequeue from an empty queue.");

    Element<T> removeElement = _first;
    _first = _first.Next!;

    if (_first == null) _last = null;

    return removeElement.Data!;
  }
```

```c#
  public void Enqueue(T item)
  {
    if (item == null) throw new ArgumentNullException("Cannot enqueue null to a queue.");

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
```

<!-- ![Screenshot 2024-09-25 002316](https://github.com/user-attachments/assets/93e312ec-7a29-42df-88e9-a4c11fc4c7ff) -->

---  
# - Stack:  <sub><sup> (*passed Unit-Tests:* ***20/20***) </sup></sub>
> FIELDS:
```c#
  private Element<T>? _head = null;
```

> PROPERTIES:
```c#
public bool IsEmpty => Count == 0;
public int Count
{
  get
  {
    int result = 0;
    Element<T>? run = _head;
    while (run != null)
    {
      result++;

      // run = run.Next != null ? run.Next : null;
      //   is the same as:
      run = run.Next ?? null;
    }
    return result;
  }
}
```

> METHODS:
```c#
  public void Clear() => _head = null;
```

```c#
  public T Peek()
  {
    if (IsEmpty) throw new InvalidOperationException("Cannot peek an empty stack.");
    return _head!.Data!;
  }
```

```c#

  public T Pop()
  {
    if (IsEmpty) throw new InvalidOperationException("Cannot pop from an empty stack.");

    T item = _head!.Data!;
    _head = _head.Next;
    return item;
  }
```

```c#

  public void Push(T? item)
  {
    var newElement = new Element<T>(item , _head);
    _head = newElement;
  }
```

<!-- ![Screenshot 2024-09-25 002015](https://github.com/user-attachments/assets/c1481045-7405-4510-a30e-2f059b5d8d8f) -->  

---  

### UniversalQueue:  18/20
<!-- ![Screenshot 2024-09-25 004603](https://github.com/user-attachments/assets/adca91d0-5145-4184-98a8-bbb75a633b2d) -->


