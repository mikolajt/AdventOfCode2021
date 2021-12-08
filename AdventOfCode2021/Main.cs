using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    class Execute
    {
        private List<string> FileReader(string filename)
        {
            return new List<string>(File.ReadAllLines(filename));
        }

        static void Main(string[] args)
        {
            Execute execute = new Execute();
            Day1 day1 = new Day1();
            Day2 day2 = new Day2();
            Day3 day3 = new Day3();
            Day4 day4 = new Day4();
            Day5 day5 = new Day5();
            Day6 day6 = new Day6();
            Day7 day7 = new Day7();

            long result = 0;

            //List<int> measurements = day1.ParseMeasurmentsToInt(run.FileReader("input/Day1.txt"));
            //result = day1.SecondTask(measurements);

            //List<command> commands = day2.ParseCommands(execute.FileReader("input/Day2.txt"));
            //result = day2.SecondTask(commands);

            //List<string> report = execute.FileReader("input/Day3.txt");
            //result = day3.SecondTask(report);

            //List<string> data = execute.FileReader("input/Day4.txt");
            //List<string> numbers = new List<string>(data[0].Split(","));
            //List<Dictionary<string, bool>> boards = day4.GetBoards(data);
            //result = day4.SecondTask(numbers, boards);

            //List<Point> points = day5.DataToPoints(execute.FileReader("input/Day5.txt"));
            //result = day5.SecondTask(points);

            //List<int> fish = day6.DataToFish(execute.FileReader("input/Day6.txt")[0]);
            //result = day6.SecondTask(fish);

            List<int> crab = day7.DataToCrab(execute.FileReader("input/Day7.txt")[0]);
            result = day7.SecondTask(crab);

            Console.WriteLine(result);
        }
    }
}
