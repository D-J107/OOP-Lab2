using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public sealed record Dimensions
{
    public Dimensions(int lenght, int width, int height)
    {
        if (lenght <= 0 || width <= 0 || height <= 0)
            throw new ArgumentException("Any dimension must be positive value!");
        Lenght = lenght;
        Width = width;
        Height = height;
    }

    public Dimensions()
    {
        Lenght = 0;
        Width = 0;
        Height = 0;
    }

    public int Lenght { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public static Dimensions Maximum(Dimensions[] dimensionsArray)
    {
        if (dimensionsArray == null) return new Dimensions();
        Dimensions maximum = dimensionsArray[0];
        foreach (Dimensions current in dimensionsArray)
        {
            maximum.Lenght = int.Max(current.Lenght, maximum.Lenght);
            maximum.Width = int.Max(current.Width, maximum.Width);
            maximum.Height = int.Max(current.Height, maximum.Height);
        }

        return maximum;
    }

    public bool LessInAllDirectionsThan(Dimensions other)
    {
        ArgumentNullException.ThrowIfNull(other);
        return Lenght < other.Lenght &&
               Width < other.Width &&
               Height < other.Height;
    }
}
