using System;

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
				new Edge(Node.StartIdentifier, "t1"),
				new Edge(Node.StartIdentifier, "t2"),
				new Edge("t1", "t3"),
				new Edge("t2", "t3"),
				new Edge("t2", "t4"),
				new Edge("t3", "t5"),
				new Edge("t3", "t6"),
				new Edge("t4", "t6"),
				new Edge("t5", "t7"),
				new Edge("t6", "t7"),
				new Edge("t6", "t8"),
				new Edge("t7", Node.EndIdentifier),
				new Edge("t8", Node.EndIdentifier)
			}, new[]{
				new Node(Node.StartIdentifier, 0),
				new Node("t1", 3),
				new Node("t2", 5),
				new Node("t3", 1),
				new Node("t4", 2),
				new Node("t5", 4),
				new Node("t6", 8),
				new Node("t7", 3),
				new Node("t8", 1),
				new Node(Node.EndIdentifier, 0)
			});
			return graph;
		}
    }
}
