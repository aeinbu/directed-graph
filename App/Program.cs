﻿using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = GetGraph();
            graph.WalkToSetEarliestAndLatest();

            graph.Print();
        }

        private static Graph GetGraph()
		{
			var graph = new Graph(new[]{
				new Edge(Node.StartIdentifier, "A"),
				new Edge(Node.StartIdentifier, "B"),
				new Edge("A", "C"),
				new Edge("B", "C"),
				new Edge("B", "D"),
				new Edge("C", "E"),
				new Edge("C", "F"),
				new Edge("D", "F"),
				new Edge("F", "H"),
				new Edge("F", "G"),
				new Edge("E", "G"),
				new Edge("H", Node.EndIdentifier),
				new Edge("G", Node.EndIdentifier)
			}, new[]{
				new Node(Node.StartIdentifier, 0),
				new Node("A", 3),
				new Node("B", 5),
				new Node("C", 1),
				new Node("D", 2),
				new Node("E", 4),
				new Node("F", 8),
				new Node("G", 3),
				new Node("H", 1),
				new Node(Node.EndIdentifier, 0)
			});
			return graph;
		}
    }
}
