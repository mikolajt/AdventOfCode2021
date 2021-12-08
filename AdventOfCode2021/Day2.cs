using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{

    public struct command
    {
        public string course;
        public int value;
    }
    public class Day2
    {
        public List<command> ParseCommands(List<string> input)
        {
            List<command> commands = new List<command>();

            foreach (string i in input)
            {
                command c;
                c.course = i.Split(' ')[0];
                c.value = Int32.Parse(i.Split(' ')[1]);
                commands.Add(c);
            }

            return commands;
        }

        public int FirstTask(List<command> commands)
        {
            int horizontal = 0;
            int depth = 0;

           foreach(command c in commands)
           {
                if(c.course == "forward")
               {
                   horizontal += c.value;
               }
               else if (c.course == "down")
               {
                   depth += c.value;
               }
               else if (c.course == "up")
               {
                   depth -= c.value;
               }
               else
               {
                   Console.WriteLine("Unexpected value");
               }
           }

            return horizontal * depth;
        }

        public int SecondTask(List<command> commands)
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (command c in commands)
            {
                if (c.course == "forward")
                {
                    horizontal += c.value;
                    depth += c.value * aim;
                }
                else if (c.course == "down")
                {
                    aim += c.value;
                }
                else if (c.course == "up")
                {
                    aim -= c.value;
                }
                else
                {
                    Console.WriteLine("Unexpected value");
                }
            }

            return horizontal * depth;
        }
    }
}
