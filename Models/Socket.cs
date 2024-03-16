using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public sealed record Socket
{
    public Socket(string name, Dimensions dimensions, int constactsAmount)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Socket must have a name!");
        if (constactsAmount <= 0) throw new ArgumentException("Socket must have at least one contact!");
        Name = name;
        Dimensions = dimensions;
        ContactsAmount = constactsAmount;
    }

    public string Name { get; }
    public Dimensions Dimensions { get; }
    public int ContactsAmount { get; }
}