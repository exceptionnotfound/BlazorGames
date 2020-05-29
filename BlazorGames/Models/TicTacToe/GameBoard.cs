using BlazorGames.Models.TicTacToe.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGames.Models.TicTacToe
{
    public class GameBoard
    {
        public GamePiece[,] Board { get; set; }

        public PieceStyle CurrentTurn = PieceStyle.X;

        public bool GameComplete => GetWinner() != null || IsADraw();


        public GameBoard()
        {
            Reset();
        }

        public void Reset()
        {
            Board = new GamePiece[3, 3];

            //Populate the Board with blank pieces
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Board[i, j] = new GamePiece();
                }
            }
        }

        //Given the coordinates of the space that was clicked...
        public void PieceClicked(int x, int y)
        {
            //If the game is complete, do nothing
            if (GameComplete) { return; }

            //If the space is not already claimed...
            GamePiece clickedSpace = Board[x, y];
            if (clickedSpace.Style == PieceStyle.Blank)
            {
                //Set the marker to the current turn marker (X or O), then make it the other player's turn
                clickedSpace.Style = CurrentTurn;
                SwitchTurns();
            }
        }

        private void SwitchTurns()
        {
            //This is equivalent to: if currently X's turn, 
            // make it O's turn, and vice-versa
            CurrentTurn = CurrentTurn == PieceStyle.X ? PieceStyle.O : PieceStyle.X;
        }

        public bool IsADraw()
        {
            int pieceBlankCount = 0;

            //Count all the blank spaces. If the count is 0, this is a draw.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pieceBlankCount = this.Board[i, j].Style == PieceStyle.Blank
                                        ? pieceBlankCount + 1
                                        : pieceBlankCount;
                }
            }

            return pieceBlankCount == 0;
        }

        public WinningPlay GetWinner()
        {
            WinningPlay winningPlay = null;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    foreach (EvaluationDirection evalDirection in (EvaluationDirection[])Enum.GetValues(typeof(EvaluationDirection)))
                    {
                        winningPlay = EvaluatePieceForWinner(i, j, evalDirection);
                        if (winningPlay != null) { return winningPlay; }
                    }
                }
            }

            return winningPlay;

        }

        private WinningPlay EvaluatePieceForWinner(int i, int j, EvaluationDirection dir)
        {
            GamePiece currentPiece = Board[i, j];
            if (currentPiece.Style == PieceStyle.Blank)
            {
                return null;
            }

            int inARow = 1;
            int iNext = i;
            int jNext = j;

            var winningMoves = new List<string>();

            while (inARow < 3)
            {
                switch (dir)
                {
                    case EvaluationDirection.Up:
                        jNext -= 1;
                        break;
                    case EvaluationDirection.UpRight:
                        iNext += 1;
                        jNext -= 1;
                        break;
                    case EvaluationDirection.Right:
                        iNext += 1;
                        break;
                    case EvaluationDirection.DownRight:
                        iNext += 1;
                        jNext += 1;
                        break;
                }
                if (iNext < 0 || iNext >= 3 || jNext < 0 || jNext >= 3) { break; }
                if (Board[iNext, jNext].Style == currentPiece.Style)
                {
                    winningMoves.Add($"{iNext},{jNext}");
                    inARow++;
                }
                else
                {
                    return null;
                }
            }

            if (inARow >= 3)
            {
                winningMoves.Add($"{i},{j}");

                return new WinningPlay()
                {
                    WinningMoves = winningMoves,
                    WinningStyle = currentPiece.Style,
                    WinningDirection = dir,
                };
            }

            return null;
        }

        public string GetGameCompleteMessage()
        {
            var winningPlay = GetWinner();
            return winningPlay != null ? $"{winningPlay.WinningStyle} Wins!" : "Draw!";
        }

        public bool IsGamePieceAWinningPiece(int i, int j)
        {
            var winningPlay = GetWinner();
            return winningPlay?.WinningMoves?.Contains($"{i},{j}") ?? false;
        }
    }
}
