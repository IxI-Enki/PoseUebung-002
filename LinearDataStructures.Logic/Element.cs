using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.Logic;

internal class Element<T>(T? data , Element<T>? next)
{
  public T? Data { get; set; } = data;
  public Element<T>? Next { get; set; } = next;
}
