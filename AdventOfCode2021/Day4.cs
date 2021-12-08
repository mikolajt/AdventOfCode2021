using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day4
    {
        public List<Dictionary<string, bool>> GetBoards(List<string> data)
        {
            List<Dictionary<string, bool>> boards = new List<Dictionary<string, bool>>();
            List<string> currentBoard = new List<string>();

            for (int i = 1; i < data.Count; i++)
            {
                if (data[i] == "")
                {
                    Dictionary<string, bool> currentBingoBoard = new Dictionary<string, bool>();
                    foreach(string number in currentBoard)
                    {
                        currentBingoBoard.Add(number, false);
                    }
                    boards.Add(currentBingoBoard);
                    currentBoard = new List<string>();
                    continue;
                }
                currentBoard.AddRange(data[i].Split(" ", StringSplitOptions.RemoveEmptyEntries));
            }
            Dictionary<string, bool> lastBingoBoard = new Dictionary<string, bool>();
            foreach (string number in currentBoard)
            {
                lastBingoBoard.Add(number, false);
            }
            boards.Add(lastBingoBoard);
            boards.RemoveAt(0);

            return boards;
        }

        public int FirstTask(List<string> numbers, List<Dictionary<string, bool>> boards)
        {
            foreach(string number in numbers)
            {
                for(int i = 0; i < boards.Count; i++)
                {
                    for(int j = 0; j < boards[i].Count; j++)
                    {
                        if (boards[i].ElementAt(j).Key == number) boards[i][boards[i].ElementAt(j).Key] = true;
                    }

                    if (CheckIfWinner(boards[i]))
                    {
                        return CalculateScore(boards[i], Int32.Parse(number));
                    }
                }
            }
            return -1;
        }

        public int SecondTask(List<string> numbers, List<Dictionary<string, bool>> boards)
        {
            foreach (string number in numbers)
            {
                for (int i = boards.Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < boards[i].Count; j++)
                    {
                        if (boards[i].ElementAt(j).Key == number) boards[i][boards[i].ElementAt(j).Key] = true;
                    }

                    if (CheckIfWinner(boards[i]))
                    {
                        if (boards.Count == 1)
                        {
                            return CalculateScore(boards[0], Int32.Parse(number));
                        }
                        boards.RemoveAt(i);
                    }
                }
            }
            return -1;
        }

        private bool CheckIfWinner(Dictionary<string, bool> board)
        {
            for (int i = 0; i < board.Count; i++) 
            {
                    if ((i + 1) % 5 == 0 && 
                        board.ElementAt(i).Value == true &&
                        board.ElementAt(i - 1).Value == true &&
                        board.ElementAt(i - 2).Value == true &&
                        board.ElementAt(i - 3).Value == true &&
                        board.ElementAt(i - 4).Value == true) return true;
                    else if (i < 5 &&
                        board.ElementAt(i).Value == true &&
                        board.ElementAt(i + 5).Value == true &&
                        board.ElementAt(i + 10).Value == true &&
                        board.ElementAt(i + 15).Value == true &&
                        board.ElementAt(i + 20).Value == true) return true;
            }
            return false;
        }

        private int CalculateScore(Dictionary<string, bool> board, int number)
        {
            int sum = 0;
            foreach (KeyValuePair<string, bool> value in board)
            {
                if (value.Value == false) sum += Int32.Parse(value.Key);
            }

            return sum * number;
        }
    }
}
