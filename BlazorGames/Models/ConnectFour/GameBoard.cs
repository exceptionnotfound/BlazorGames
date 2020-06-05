using BlazorGames.Models.ConnectFour.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.ConnectFour
{
    public class GameBoard
    {
        public GamePiece[,] Board { get; set; }

        public PieceColor CurrentTurn { get; set; } = PieceColor.Red;

        public WinningPlay WinningPlay { get; set; }


        public GameBoard()
        {
            Reset();
        }

        public void Reset()
        {
            Board = new GamePiece[7, 6];

            //Populate the Board with blank pieces
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    Board[i, j] = new GamePiece(PieceColor.Blank);
                }
            }

            CurrentTurn = PieceColor.Red;
            WinningPlay = null;
        }

        public void PieceClicked(int x, int y)
        {
            //If a winning play has already been made, don't do anything.
            if (WinningPlay != null) { return; }

            GamePiece clickedSpace = Board[x, y];

            //The piece must "fall" to the lowest unoccupied space in the clicked column
            if (clickedSpace.Color == PieceColor.Blank)
            {
                while (y < 5)
                {
                    GamePiece nextSpace = Board[x, y + 1];

                    y += 1;
                    if (nextSpace.Color == PieceColor.Blank)
                    {
                        clickedSpace = nextSpace;
                    }
                }
                clickedSpace.Color = CurrentTurn;

            }

            //After every move, check to see if that move was a winning move.
            WinningPlay = GetWinner();
            if (WinningPlay == null)
            {
                SwitchTurns();
            }
        }

        public void SwitchTurns()
        {
            CurrentTurn = CurrentTurn == PieceColor.Red ? PieceColor.Yellow : PieceColor.Red;
        }

        public bool IsGamePieceAWinningPiece(int i, int j)
        {
            return WinningPlay?.WinningMoves?.Contains($"{i},{j}") ?? false;
        }

        private WinningPlay GetWinner()
        {
            WinningPlay winningPlay = null;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    winningPlay = EvaluatePieceForWinner(i, j, EvaluationDirection.Up);
                    if (winningPlay != null) { return winningPlay; }

                    winningPlay = EvaluatePieceForWinner(i, j, EvaluationDirection.UpRight);
                    if (winningPlay != null) { return winningPlay; }

                    winningPlay = EvaluatePieceForWinner(i, j, EvaluationDirection.Right);
                    if (winningPlay != null) { return winningPlay; }

                    winningPlay = EvaluatePieceForWinner(i, j, EvaluationDirection.DownRight);
                    if (winningPlay != null) { return winningPlay; }
                }
            }

            return winningPlay;

        }
        private WinningPlay EvaluatePieceForWinner(int i, int j, EvaluationDirection dir)
        {
            GamePiece currentPiece = Board[i, j];
            if (currentPiece.Color == PieceColor.Blank)
            {
                return null;
            }

            int inARow = 1;
            int iNext = i;
            int jNext = j;

            var winningMoves = new List<string>();

            while (inARow < 4)
            {
                switch (dir)
                {
                    case EvaluationDirection.Up:
                        jNext = jNext - 1;
                        break;
                    case EvaluationDirection.UpRight:
                        iNext = iNext + 1;
                        jNext = jNext - 1;
                        break;
                    case EvaluationDirection.Right:
                        iNext = iNext + 1;
                        break;
                    case EvaluationDirection.DownRight:
                        iNext = iNext + 1;
                        jNext = jNext + 1;
                        break;
                }
                if (iNext < 0 || iNext >= 7 || jNext < 0 || jNext >= 6) { break; }
                if (Board[iNext, jNext].Color == currentPiece.Color)
                {
                    winningMoves.Add($"{iNext},{jNext}");
                    inARow++;
                }
                else
                {
                    return null;
                }
            }

            if (inARow >= 4)
            {
                winningMoves.Add($"{i},{j}");

                return new WinningPlay()
                {
                    WinningMoves = winningMoves,
                    WinningColor = currentPiece.Color,
                    WinningDirection = dir,
                };
            }

            return null;
        }
    }
}
