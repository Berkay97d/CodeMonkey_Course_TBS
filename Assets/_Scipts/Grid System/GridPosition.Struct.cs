public struct GridPosition
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
        return "X: " + x + " Z: " + z;
    }
}