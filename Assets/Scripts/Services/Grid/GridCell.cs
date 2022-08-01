namespace Services.Grid
{
    public class GridCell
    {
        private readonly Grid _grid;
        private readonly GridPosition _gridPosition;

        public GridCell(Grid grid, GridPosition gridPosition)
        {
            _grid = grid;
            _gridPosition = gridPosition;
        }
    }
}
