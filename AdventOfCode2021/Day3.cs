using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    public class Day3
    {
        public int FirstTask(List<string> report)
        {
            string gammaRate = "";
            string epsilonRate = "";

            for(int i = 0; i < report[0].Length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;

                foreach (string line in report)
                {
                    if (line[i] == '0') zeroCount++;
                    else oneCount++;
                }

                if(zeroCount > oneCount)
                {
                    gammaRate += '0';
                    epsilonRate += '1';
                }
                else
                {
                    gammaRate += '1';
                    epsilonRate += '0';
                }
            }

            return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);

        }

        public int SecondTask(List<string> report)
        {
            string oxygenGeneratorRating = LifeSupportRating(true, new List<string>(report));
            string Co2ScrubberRating = LifeSupportRating(false, new List<string>(report));

            return Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(Co2ScrubberRating, 2);
        }

        private string LifeSupportRating(bool isOxygen, List<string> report)
        {
            for (int i = 0; i < report[0].Length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;

                foreach (string line in report)
                {
                    if (line[i] == '0') zeroCount++;
                    else oneCount++;
                }

                if (isOxygen)
                {
                    if (zeroCount > oneCount)
                    {
                        for (int j = report.Count - 1; j >= 0; j--)
                        {
                            if (report[j][i] == '1') report.Remove(report[j]);
                        }
                    }
                    else if (zeroCount < oneCount)
                    {
                        for (int j = report.Count - 1; j >= 0; j--)
                        {
                            if (report[j][i] == '0') report.Remove(report[j]);
                        }
                    }
                    else
                    {
                        for (int j = report.Count - 1; j >= 0; j--)
                        {
                            if (report[j][i] == '0') report.Remove(report[j]);
                        }
                    }
                }
                else
                {
                    if (zeroCount > oneCount)
                    {
                        for (int j = report.Count - 1; j >= 0; j--)
                        {
                            if (report[j][i] == '0') report.Remove(report[j]);
                        }
                    }
                    else if (zeroCount < oneCount)
                    {
                        for (int j = report.Count - 1; j >= 0; j--)
                        {
                            if (report[j][i] == '1') report.Remove(report[j]);
                        }
                    }
                    else
                    {
                        for (int j = report.Count - 1; j >= 0; j--)
                        {
                            if (report[j][i] == '1') report.Remove(report[j]);
                        }
                    }
                }

                if (report.Count == 1)
                {
                    break;
                }
            }

            return report[0];
        }
    }
}
