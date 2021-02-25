using System.Collections.Generic;
using System.Linq;

namespace BlazorGames.Models.Tetris
{
    public class CellCollection
    {
        private readonly List<Cell> _cells = new List<Cell>();

        /// <summary>
        /// Returns all currently-occupied coordinates.
        /// </summary>
        /// <returns></returns>
        public List<Cell> GetAll()
        {
            return _cells;
        }

        /// <summary>
        /// Returns all occupied cell in a given row.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public List<Cell> GetAllInRow(int row)
        {
            return _cells.Where(x => x.Row == row).ToList();
        }

        /// <summary>
        /// Adds a new cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void Add(int row, int column)
        {
            _cells.Add(new Cell(row, column));
        }

        /// <summary>
        /// Adds several new Cells and gives them each the specified CSS class.
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="cssClass"></param>
        public void AddMany(List<Cell> cells, string cssClass)
        {
            foreach(var cell in cells)
            {
                _cells.Add(new Cell(cell.Row, cell.Column, cssClass));
            }
        }

        /// <summary>
        /// Returns true if the cell is occupied.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public bool Contains(int row, int column)
        {
            return _cells.Any(c => c.Row == row && c.Column == column);
        }

        /// <summary>
        /// Returns true if there are any occupied cells in the given column.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public bool HasColumn(int column)
        {
            return _cells.Any(c => c.Column == column);
        }

        /// <summary>
        /// Gets the lowest (lowest Row value) cell in the collection. 
        /// </summary>
        /// <returns></returns>
        public List<Cell> GetLowest()
        {
            List<Cell> cells = new List<Cell>();
            foreach(var cell in _cells)
            {
                if(!Contains(cell.Row - 1, cell.Column))
                {
                    cells.Add(cell);
                }
            }

            return cells;
        }

        /// <summary>
        /// Gets the rightmost (highest Column value) cell in the collection.
        /// </summary>
        /// <returns></returns>
        public List<Cell> GetRightmost()
        {
            List<Cell> cells = new List<Cell>();
            foreach (var cell in _cells)
            {
                if (!Contains(cell.Row, cell.Column + 1))
                {
                    cells.Add(cell);
                }
            }

            return cells;
        }

        /// <summary>
        /// Gets the leftmost (lowest Column value) cell in the collection.
        /// </summary>
        /// <returns></returns>
        public List<Cell> GetLeftmost()
        {
            List<Cell> cells = new List<Cell>();
            foreach (var cell in _cells)
            {
                if (!Contains(cell.Row, cell.Column - 1))
                {
                    cells.Add(cell);
                }
            }

            return cells;
        }

        /// <summary>
        /// Returns true if any cell in the collection is in the specified row.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool HasRow(int row)
        {
            return _cells.Any(c => c.Row == row);
        }

        /// <summary>
        /// Gets the CSS class of an individual cell.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public string GetCssClass(int row, int column)
        {
            var matching = _cells.FirstOrDefault(x => x.Row == row && x.Column == column);

            if (matching != null)
                return matching.CssClass;

            return "";
        }

        /// <summary>
        /// Sets the CSS class to each cell in an entire row.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cssClass"></param>
        public void SetCssClass(int row, string cssClass)
        {
            _cells.Where(x => x.Row == row).ToList().ForEach(x => x.CssClass = cssClass);
        }

        /// <summary>
        /// Moves all "higher" cells down to fill in the specified completed rows.
        /// </summary>
        /// <param name="rows"></param>
        public void CollapseRows(List<int> rows)
        {
            var selectedCells = _cells.Where(x => rows.Contains(x.Row));

            List<Cell> toRemove = new List<Cell>();
            foreach (var cell in selectedCells)
            {
                toRemove.Add(cell);
            }

            _cells.RemoveAll(x => toRemove.Contains(x));

            foreach (var cell in _cells)
            {
                int numberOfLessRows = rows.Where(x => x <= cell.Row).Count();
                cell.Row -= numberOfLessRows;
            }
        }
    }
}
