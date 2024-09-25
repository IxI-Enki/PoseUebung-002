# PoseUebung-002 -- Linear Data Structures
> ![image](https://github.com/user-attachments/assets/e4a2b0fb-c813-4a24-b81e-5cb32b37a75e)


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

# UniversalQueue:  <sub><sup> (*passed Unit-Tests:* ***18/20***) </sup></sub>

> FIELDS:
```c#
private readonly Queue<T> _queue;
private readonly Stack<T> _stack;
```

> PROPERTIES:
```c#
public bool IsEmpty => _queue.Count == 0 && _stack.Count == 0;
public int Count => _queue.Count + _stack.Count;
```

> METHODS:
```c#
public void Enqueue(T item) => _queue.Enqueue(item);
```

```c#
public void Push(T item) => _stack.Push(item);
```

```c#
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
```

```c#
public T Pop()
{
  if (IsEmpty) throw new InvalidOperationException("Cannot pop from an empty queue.");
  return _stack.Pop();
}
```

```c#
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
```

```c#
public void Clear()
{
  _queue.Clear();
  _stack.Clear();
}
```
<!-- ![Screenshot 2024-09-25 004603](https://github.com/user-attachments/assets/adca91d0-5145-4184-98a8-bbb75a633b2d) -->


