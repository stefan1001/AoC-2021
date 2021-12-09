using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Square
    {
        public Square(int number)
        {
            this.Number = number;
            this.Marked = false;
        }
        public int Number { get; set; }
        public bool Marked { get; set; }
    }
    public class Board
    {
        private Square[,] squares;
        public Board(string[] input)
        {
            squares = new Square[5,5];
            for(int row=0; row < 5; row++)
            {
                for(int col = 0; col < 5; col++)
                {
                    var number = int.Parse(input[row].Substring(col*3,2));
                    squares[row,col] = new Square(number);
                }
            }
        }
        public bool Mark(int number)
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j=0;j<5;j++)
                {
                    if (squares[i,j].Number == number)
                    {
                        squares[i,j].Marked=true;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CheckBingo()
        {
                bool rowBingo = true;
                bool colBingo = true;
            for(int row = 0; row < 5; row++)
            {
                rowBingo = true;
                for(int col=0;col<5;col++)
                {
                    
                    if (!squares[row,col].Marked)
                    {
                        rowBingo = false;
                        break;
                    }
                }
                    if (rowBingo)
                        break;
            }
             for(int col = 0; col < 5; col++)
            {
                colBingo = true;
                for(int row=0;row<5;row++)
                {
                    if (!squares[row,col].Marked)
                    {
                        colBingo = false;
                        break;
                    }
                }
                if (colBingo)
                break;
            }           
            return rowBingo || colBingo;
        }
        public int CalculateResult()
        {
            int sum = 0;
            for(int i = 0; i < 5; i++)
            {
                for(int j=0;j<5;j++)
                {
                    if (!squares[i,j].Marked)
                    {
                        sum += squares[i,j].Number;
                    }
                }
            }            
            return sum;
        }
}
    class Program
    {
        static void Main(string[] args)
        {
            var boards = new List<Board>();
            using(var reader = new StreamReader("/Users/stefano/Projects/AoC/Day4/input.txt"))
            {
                var draw = reader.ReadLine();
                var drawNumbers = draw.Split(',').Select(x => int.Parse(x));
                string[] line = new string[5];
                while(reader.ReadLine() != null)
                {
                    for(int row = 0; row < 5; row++)
                    {
                        line[row] = reader.ReadLine();
                    }
                    boards.Add(new Board(line));
                }
                foreach(var number in drawNumbers)
                {
                    var remaining = new List<Board>(boards);
                    foreach(var board in boards)
                    {
                        if (board.Mark(number))
                        {
                            if (board.CheckBingo())
                            {
                                remaining.Remove(board);
                                if (!remaining.Any())
                                {
                                    Console.WriteLine(board.CalculateResult()*number);
                                    return;
                                }
                            }
                        }
                    }
                    boards = remaining;
                }
            }           
        }
    }
}
