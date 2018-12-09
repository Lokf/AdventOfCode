using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018
{
    public class Day08
    {
        public static int Task1(IEnumerable<int> tree)
        {
            var enumerator = tree.GetEnumerator();
            enumerator.MoveNext();
            return ParseNode(enumerator);
        }

        private static int ParseNode(IEnumerator<int> source)
        {
            var numberOfChildNodes = source.Current;
            source.MoveNext();
            var numberOfMetaEntries = source.Current;
            source.MoveNext();

            var metaEntriesSum = Enumerable
                .Range(0, numberOfChildNodes)
                .Sum(_ => ParseNode(source));

            foreach (var index in Enumerable.Range(0, numberOfMetaEntries))
            {
                metaEntriesSum += source.Current;
                source.MoveNext();
            }

            return metaEntriesSum;
        }

        public static int Task2(IEnumerable<int> tree)
        {
            var enumerator = tree.GetEnumerator();
            enumerator.MoveNext();
            return ParseNode2(enumerator);
        }

        private static int ParseNode2(IEnumerator<int> source)
        {
            var numberOfChildNodes = source.Current;
            source.MoveNext();
            var numberOfMetaEntries = source.Current;
            source.MoveNext();

            var childValues = Enumerable
                .Range(0, numberOfChildNodes)
                .Select(_ => ParseNode2(source))
                .ToArray();

            if (numberOfChildNodes == 0)
            {
                var metaEntriesSum = 0;
                foreach (var index in Enumerable.Range(0, numberOfMetaEntries))
                {
                    metaEntriesSum += source.Current;
                    source.MoveNext();
                }

                return metaEntriesSum;
            }

            var value = 0;
            foreach (var index in Enumerable.Range(0, numberOfMetaEntries))
            {
                var metaEntry = source.Current;
                source.MoveNext();

                if (metaEntry <= childValues.Length && metaEntry > 0)
                {
                    value += childValues[metaEntry - 1];
                }
            }

            return value;
        }
    }
}
