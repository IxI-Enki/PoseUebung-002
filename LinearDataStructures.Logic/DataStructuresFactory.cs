namespace LinearDataStructures.Logic;

public static class DataStructuresFactory
{
  public static IStack<T> CreateStack<T>()
    => new Stack<T>();

  public static IQueue<T> CreateQueue<T>()
    => new Queue<T>();

  public static IUniversalQueue<T> CreateUniversalQueue<T>()
    => new UniversalQueue<T>();
}
