using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2018
{
    public class Day04
    {
        public static int Task1(IEnumerable<string> logRecords)
        {
            var sleepingMinutesForGaurds = CalculateSleepingMinutes(logRecords);
            var bestGaurd = sleepingMinutesForGaurds
                .OrderByDescending(sleepingMinutes => sleepingMinutes.Value.Sum(minute => minute.Value))
                .First();

            var bestMinute = bestGaurd
                .Value
                .OrderByDescending(f => f.Value)
                .First()
                .Key;

            return bestGaurd.Key * bestMinute;
        }

        public static int Task2(IEnumerable<string> logRecords)
        {
            var sleepingMinutesForGaurds = CalculateSleepingMinutes(logRecords);
            var bestGaurd = sleepingMinutesForGaurds
                .Select(sleepingMinutes => new
                {
                    Gaurd = sleepingMinutes.Key,
                    Minute = sleepingMinutes.Value.OrderByDescending(minute => minute.Value).First().Key,
                    Count = sleepingMinutes.Value.OrderByDescending(minute => minute.Value).First().Value,
                })
                .OrderByDescending(gaurd => gaurd.Count)
                .First();

            return bestGaurd.Gaurd * bestGaurd.Minute;
        }

        private static Dictionary<int, Dictionary<int, int>> CalculateSleepingMinutes(IEnumerable<string> logRecords)
        {
            var records = logRecords
                .Select(ParseLogRecord)
                .OrderBy(record => record.timestamp);

            var sleepingMinutesForGaurds = new Dictionary<int, Dictionary<int, int>>();

            var currentGaurd = 0;
            var fallingAsleepAt = 0;

            foreach (var (timestamp, note) in records)
            {
                switch (note)
                {
                    case "falls asleep":
                        fallingAsleepAt = timestamp.Minute;
                        break;
                    case "wakes up":
                        if (!sleepingMinutesForGaurds.TryGetValue(currentGaurd, out var sleepingMinutes))
                        {
                            sleepingMinutes = new Dictionary<int, int>();
                            sleepingMinutesForGaurds.Add(currentGaurd, sleepingMinutes);
                        }

                        for (int i = fallingAsleepAt; i < timestamp.Minute; i++)
                        {
                            sleepingMinutes.TryAdd(i, 0);
                            sleepingMinutes[i]++;
                        }
                        break;
                    default:
                        currentGaurd = Gaurd(note);
                        break;
                }
            }

            return sleepingMinutesForGaurds;
        }

        private static (DateTime timestamp, string note) ParseLogRecord(string logRecord)
        {
            var timestamp = DateTime.ParseExact(logRecord.Substring(1, 16), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            var note = logRecord.Substring(19);

            return (timestamp, note);
        }

        private static int Gaurd(string note)
        {
            const string pattern = @"#(?'id'\d+)";
            var regex = new Regex(pattern);

            return int.Parse(
                regex
                    .Match(note)
                    .Groups["id"]
                    .Value);
        }
    }
}
