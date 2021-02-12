using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Tetris
{
    public class CoordinateCollection
    {
        private readonly List<Coordinate> _coordinates = new List<Coordinate>();

        /// <summary>
        /// Returns all currently-occupied coordinates.
        /// </summary>
        /// <returns></returns>
        public List<Coordinate> GetAll()
        {
            return _coordinates;
        }

        /// <summary>
        /// Returns all occupied coordinates in a given row.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public List<Coordinate> GetAllInRow(int row)
        {
            return _coordinates.Where(x => x.Row == row).ToList();
        }

        /// <summary>
        /// Adds a new coordinate
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void Add(int row, int column)
        {
            _coordinates.Add(new Coordinate(row, column));
        }

        /// <summary>
        /// Adds several new Coordinates and gives them each the specified CSS class.
        /// </summary>
        /// <param name="coords"></param>
        /// <param name="cssClass"></param>
        public void AddMany(List<Coordinate> coords, string cssClass)
        {
            foreach(var coord in coords)
            {
                _coordinates.Add(new Coordinate(coord.Row, coord.Column, cssClass));
            }
        }

        /// <summary>
        /// Returns true if the coordinate is occupied.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public bool Contains(int row, int column)
        {
            return _coordinates.Any(c => c.Row == row && c.Column == column);
        }

        /// <summary>
        /// Returns true if there are any occupied coordinates in the given column.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public bool HasColumn(int column)
        {
            return _coordinates.Any(c => c.Column == column);
        }

        /// <summary>
        /// Gets the lowest (lowest Row value) coordinate in the collection. 
        /// </summary>
        /// <returns></returns>
        public List<Coordinate> GetLowest()
        {
            List<Coordinate> coords = new List<Coordinate>();
            foreach(var coord in _coordinates)
            {
                if(!Contains(coord.Row - 1, coord.Column))
                {
                    coords.Add(coord);
                }
            }

            return coords;
        }

        /// <summary>
        /// Gets the rightmost (highest Column value) coordinate in the collection.
        /// </summary>
        /// <returns></returns>
        public List<Coordinate> GetRightmost()
        {
            List<Coordinate> coords = new List<Coordinate>();
            foreach (var coord in _coordinates)
            {
                if (!Contains(coord.Row, coord.Column + 1))
                {
                    coords.Add(coord);
                }
            }

            return coords;
        }

        /// <summary>
        /// Gets the leftmost (lowest Column value) coordinate in the collection.
        /// </summary>
        /// <returns></returns>
        public List<Coordinate> GetLeftmost()
        {
            List<Coordinate> coords = new List<Coordinate>();
            foreach (var coord in _coordinates)
            {
                if (!Contains(coord.Row, coord.Column - 1))
                {
                    coords.Add(coord);
                }
            }

            return coords;
        }

        /// <summary>
        /// Returns true if any coordinate in the collection is in the specified row.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool HasRow(int row)
        {
            return _coordinates.Any(c => c.Row == row);
        }

        /// <summary>
        /// Gets the CSS class of an individual coordinate.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public string GetCssClass(int row, int column)
        {
            var matching = _coordinates.FirstOrDefault(x => x.Row == row && x.Column == column);

            if (matching != null)
                return matching.CssClass;

            return "";
        }

        /// <summary>
        /// Sets the CSS class to each coordinate in an entire row.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cssClass"></param>
        public void SetCssClass(int row, string cssClass)
        {
            _coordinates.Where(x => x.Row == row).ToList().ForEach(x => x.CssClass = cssClass);
        }

        /// <summary>
        /// Moves all "higher" coordinates down to fill in the specified completed rows.
        /// </summary>
        /// <param name="rows"></param>
        public void CollapseRows(List<int> rows)
        {
            var selectedCoords = _coordinates.Where(x => rows.Contains(x.Row));

            List<Coordinate> toRemove = new List<Coordinate>();
            foreach (var coord in selectedCoords)
            {
                toRemove.Add(coord);
            }

            _coordinates.RemoveAll(x => toRemove.Contains(x));

            foreach (var coord in _coordinates)
            {
                int numberOfLessRows = rows.Where(x => x <= coord.Row).Count();
                coord.Row -= numberOfLessRows;
            }
        }
    }
}
