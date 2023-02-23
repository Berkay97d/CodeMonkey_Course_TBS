
public class Grid
{

    private GridSystem gridSystem;
    private GridPosition gridPosition;

    public Grid(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }
    
    public override string ToString()
    {
        return gridPosition.ToString();
    }
}
