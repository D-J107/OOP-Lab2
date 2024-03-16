using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Repository<T>
    where T : PcComponent
{
    private ICollection<T> _array;

    public Repository()
    {
        _array = new List<T>();
    }

    public IReadOnlyCollection<T> Components => (IReadOnlyCollection<T>)_array;
    public void Add(T component)
    {
        _array.Add(component);
    }

    public T? FindComponentByName(string name)
    {
        return _array.SingleOrDefault(current => name == current.Name);
    }
}