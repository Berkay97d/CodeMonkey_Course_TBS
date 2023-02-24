﻿using System;

public struct GridPosition : IEquatable<GridPosition>
{
    public int x { get; set; }
    public int z { get; set; }

    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return "X: " + x + " " + " Z: " + z;
    }

    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }

    public bool Equals(GridPosition other)
    {
        return x == other.x && z == other.z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }
}