using BlazorGames.Models.GameOfLife.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BlazorGames.Models.GameOfLife
{
    public class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public bool RunSimulation { get; set; }
        public Theme Theme { get; set; }

        public Status[,] Grid { get; set; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Initialize();
        }

        public void Initialize()
        {
            Grid = new Status[Rows, Columns];
        }

        public void ChangeStatus(int row, int column)
        {
            Grid[row, column] = Grid[row, column] == Status.Dead ? Status.Alive : Status.Dead;
        }

        public void SetRandom()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    Grid[row, column] = (Status)RandomNumberGenerator.GetInt32(0, 2);
                }
            }
        }

        //Code for this method originally by Khalid Abuhakmeh.
        //https://khalidabuhakmeh.com/program-the-game-of-life-with-csharp-and-emojis
        public void CalculateNextGeneration()
        {
            var nextGeneration = new Status[Rows, Columns];

            // Loop through every cell 
            for (var row = 1; row < Rows - 1; row++)
            {
                for (var column = 1; column < Columns - 1; column++)
                {
                    // find your alive neighbors
                    var aliveNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            aliveNeighbors += Grid[row + i, column + j] == Status.Alive ? 1 : 0;
                        }
                    }

                    var currentCell = Grid[row, column];

                    // The cell needs to be subtracted 
                    // from its neighbors as it was  
                    // counted before 
                    aliveNeighbors -= currentCell == Status.Alive ? 1 : 0;

                    // Implementing the Rules of Life 

                    // Cell is lonely and dies 
                    if (currentCell == Status.Alive && aliveNeighbors < 2)
                    {
                        nextGeneration[row, column] = Status.Dead;
                    }

                    // Cell dies due to over population 
                    else if (currentCell == Status.Alive && aliveNeighbors > 3)
                    {
                        nextGeneration[row, column] = Status.Dead;
                    }

                    // A new cell is born 
                    else if (currentCell == Status.Dead && aliveNeighbors == 3)
                    {
                        nextGeneration[row, column] = Status.Alive;
                    }
                    // All other cells stay the same
                    else
                    {
                        nextGeneration[row, column] = currentCell;
                    }
                }
            }
            Grid = nextGeneration;
        }
    }
}
