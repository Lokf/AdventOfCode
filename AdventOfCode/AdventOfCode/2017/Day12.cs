using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2017
{
    public class Day12
    {
        public static int Task1(List<string> connections)
        {
            var nodes = ParseNodes(connections);

            return GetGroup(nodes, nodes[0]).Count;
        }

        public static int Task2(List<string> connections)
        {
            var seenNodes = new List<int>();
            var count = 0;

            var nodes = ParseNodes(connections);
            var nodesLeft = nodes.Select(x => x.Key).ToList();
                        
            while (nodesLeft.Any())
            {
                var group = GetGroup(nodes, nodes[nodesLeft[0]]);
                nodesLeft.RemoveAll(x => group.Contains(x));
                count++;
            }

            return count;
        }

        private static List<Node> ParseNodes(List<string> connections)
        {
            var nodes = Enumerable
                .Range(0, connections.Count)
                .Select(x => new Node(x))
                .ToDictionary(x => x.Key, x => x);

            foreach (var connection in connections)
            {
                var kalle = connection.Split(" <-> ");
                var key = int.Parse(kalle[0]);
                var neighbors = kalle[1].Split(", ").Select(x => int.Parse(x));
                var node = nodes[key];
                foreach (var neighbor in neighbors)
                {
                    node.Neighbors.Add(nodes[neighbor]);
                }
            }

            return nodes
                .Values
                .ToList();
        }

        private static HashSet<int> GetGroup(List<Node> nodes, Node start)
        {
            var seenNodes = new HashSet<int>
            {
                start.Key
            };

            var toSearchNodes = new Stack<Node>(start.Neighbors);

            while (toSearchNodes.Any())
            {
                var node = toSearchNodes.Pop();
                
                if (!seenNodes.Add(node.Key))
                {
                    continue;
                }

                foreach (var neighbor in node.Neighbors)
                {
                    toSearchNodes.Push(neighbor);
                }                
            }

            return seenNodes;
        }

        private class Node
        {
            public int Key { get; }
            public List<Node> Neighbors { get; } = new List<Node>();
            public Node(int key)
            {
                Key = key;
            }
        }
    }
}
