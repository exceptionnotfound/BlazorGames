using BlazorGames.Models.Minesweeper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.Minesweeper
{
    public class GameBoard
    {
        public int Width { get; set; } = 20;
        public int Height { get; set; } = 20;
        public int MineCount { get; set; } = 30;
        public List<Panel> Panels { get; set; }
        public GameStatus Status { get; set; }

        public double PercentMinesFlagged { get; set; }
        public double PercentPanelsRevealed { get; set; }

        public GameBoard()
        {
            Reset();
        }

        public void Reset()
        {
            Initialize(Width, Height, MineCount);
        }

        public int PanelsRemaining()
        {
            return Panels.Where(x => !x.IsRevealed).Count() - MineCount;
        }

        public void Initialize(int width, int height, int mines)
        {
            Width = width;
            Height = height;
            MineCount = mines;
            Panels = new List<Panel>();

            int id = 1;
            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    Panels.Add(new Panel(id, j, i));
                    id++;
                }
            }

            Status = GameStatus.AwaitingFirstMove;
        }

        public void MakeMove(int x, int y)
        {
            if (Status == GameStatus.AwaitingFirstMove)
            {
                FirstMove(x, y);
            }
            RevealPanel(x, y);
        }

        public List<Panel> GetNeighbors(int x, int y)
        {
            var nearbyPanels = Panels.Where(panel => panel.X >= (x - 1) && panel.X <= (x + 1)
                                                 && panel.Y >= (y - 1) && panel.Y <= (y + 1));
            var currentPanel = Panels.Where(panel => panel.X == x && panel.Y == y);
            return nearbyPanels.Except(currentPanel).ToList();
        }

        public void RevealPanel(int x, int y)
        {
            //Step 1: Find the Specified Panel
            var selectedPanel = Panels.First(panel => panel.X == x && panel.Y == y);
            selectedPanel.IsRevealed = true;
            selectedPanel.IsFlagged = false; //Revealed panels cannot be flagged

            //Step 2: If the panel is a mine, game over!
            if (selectedPanel.IsMine)
            {
                Status = GameStatus.Failed; //Game over!
                RevealAllMines();
            }

            //Step 3: If the panel is a zero, cascade reveal neighbors
            if (!selectedPanel.IsMine && selectedPanel.AdjacentMines == 0)
            {
                RevealZeros(x, y);
            }

            //Step 4: If this move caused the game to be complete, mark it as such
            if (!selectedPanel.IsMine)
            {
                CompletionCheck();
            }
        }

        public void FirstMove(int x, int y)
        {
            Random rand = new Random();
            //For any board, take the user's first revealed panel + any neighbors of that panel, and mark them as unavailable for mine placement.
            var neighbors = GetNeighbors(x, y); //Get all neighbors to specified depth
            neighbors.Add(GetPanel(x, y));

            //Select random panels from set which are not excluded
            var mineList = Panels.Except(neighbors).OrderBy(user => rand.Next());
            var mineSlots = mineList.Take(MineCount).ToList().Select(z => new { z.X, z.Y });

            //Place the mines
            foreach (var mineCoord in mineSlots)
            {
                Panels.Single(panel => panel.X == mineCoord.X && panel.Y == mineCoord.Y).IsMine = true;
            }

            //For every panel which is not a mine, determine and save the adjacent mines.
            foreach (var openPanel in Panels.Where(panel => !panel.IsMine))
            {
                var nearbyPanels = GetNeighbors(openPanel.X, openPanel.Y);
                openPanel.AdjacentMines = nearbyPanels.Count(z => z.IsMine);
            }

            Status = GameStatus.InProgress;
        }

        public void RevealZeros(int x, int y)
        {
            var neighborPanels = GetNeighbors(x, y).Where(panel => !panel.IsRevealed);
            foreach (var neighbor in neighborPanels)
            {
                neighbor.IsRevealed = true;
                if (neighbor.AdjacentMines == 0)
                {
                    RevealZeros(neighbor.X, neighbor.Y);
                }
            }
        }

        private void RevealAllMines()
        {
            foreach(var panel in Panels)
            {
                if(panel.IsMine)
                {
                    panel.IsRevealed = true;
                }
            }
        }

        private void CompletionCheck()
        {
            var hiddenPanels = Panels.Where(x => !x.IsRevealed).Select(x => x.ID);
            var minePanels = Panels.Where(x => x.IsMine).Select(x => x.ID);
            if (!hiddenPanels.Except(minePanels).Any())
            {
                Status = GameStatus.Completed; 
                RevealAllMines();
            }
        }

        public BoardStats GetStats()
        {
            BoardStats stats = new BoardStats();

            stats.Mines = Panels.Count(x => x.IsMine);
            stats.FlaggedMinePanels = Panels.Count(x => x.IsMine && x.IsFlagged);

            stats.PercentMinesFlagged = Math.Round((double)(stats.FlaggedMinePanels / stats.Mines) * 100, 2);

            stats.TotalPanels = Panels.Count;
            stats.PanelsRevealed = Panels.Count(x => x.IsFlagged || x.IsRevealed);

            stats.PercentPanelsRevealed = Math.Round((double)(stats.PanelsRevealed / stats.TotalPanels) * 100, 2);

            return stats;
        }

        public Panel GetPanel(int x, int y)
        {
            return Panels.First(z => z.X == x && z.Y == y);
        }

        public void FlagPanel(int x, int y)
        {
            var panel = Panels.Where(z => z.X == x && z.Y == y).First();
            if (!panel.IsRevealed)
            {
                panel.IsFlagged = true;
            }
        }
    }
}
