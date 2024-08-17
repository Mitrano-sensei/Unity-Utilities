using UnityEngine;

namespace Utilities
{
    public static class GridHelpers
    {
        public static Vector3Int WorldToCell(Vector3 worldPosition, Grid grid)
        {
            return grid.WorldToCell(worldPosition).WithZ(0);
        }

        public static Vector3 CellToWorld(Vector3Int cellPosition, Grid grid)
        {
            return grid.CellToWorld(cellPosition);
        }
        
        public static Vector3Int MousePositionToCell(Grid grid)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return WorldToCell(mousePosition, grid);
        }
        
        public static Vector3 MouseCellToWorld(Grid grid)
        {
            Vector3Int cellPosition = MousePositionToCell(grid);
            return CellToWorld(cellPosition, grid);
        }
        
    }
}