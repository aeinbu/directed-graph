using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
	public class Graph
	{
		private IEnumerable<Edge> _edges;
		private IDictionary<string, Node> _nodes;

		public Graph(IEnumerable<Edge> edges, IEnumerable<Node> nodes)
		{
			_edges = edges;
			_nodes = nodes.ToDictionary(node => node.Name);
		}

		public Node GetNode(string name) => _nodes[name];

		internal void Print()
		{
			foreach (var node in _nodes.Values)
			{
				Console.WriteLine(node);
			}
		}

		public int GetEarliestEnd()
		{
			return _nodes[Node.EndIdentifier].EarliestEnd.Value;
		}

		public void WalkToSetEarliestAndLatest()
		{
			var edgesToFollowForwards = _edges.Where(edge => edge.Left == Node.StartIdentifier);
			foreach (var edge in edgesToFollowForwards)
			{
				WalkToSetEarliest(_nodes[edge.Right], 0);
			}

			var earliestEnd = GetEarliestEnd();
			var edgesToFollowBackwards = _edges.Where(edge => edge.Right == Node.EndIdentifier);
			foreach (var edge in edgesToFollowBackwards)
			{
				WalkToSetLatest(_nodes[edge.Left], earliestEnd);
			}
		}

		private void WalkToSetEarliest(Node currentNode, int earliestStart)
		{
			if (currentNode.EarliestStart.HasValue && currentNode.EarliestStart >= earliestStart)
			{
				return;
			}

			currentNode.EarliestStart = earliestStart;

			var edgesToFollow = _edges.Where(nextEdge => nextEdge.Left == currentNode.Name);
			foreach (var edge in edgesToFollow)
			{
				//TODO: add circular detection
				WalkToSetEarliest(_nodes[edge.Right], currentNode.EarliestEnd.Value);
			}
		}

		private void WalkToSetLatest(Node currentNode, int latestEnd)
		{
			if (currentNode.LatestEnd.HasValue && currentNode.LatestEnd <= latestEnd)   //TODO: 3x?
			{
				return;
			}

			currentNode.LatestEnd = latestEnd;  //TODO: 2x?

			var edgesToFollow = _edges.Where(nextEdge => nextEdge.Right == currentNode.Name);  //TODO: 1x?
			foreach (var edge in edgesToFollow)
			{
				//TODO: add circular detection
				WalkToSetLatest(_nodes[edge.Left], currentNode.LatestStart.Value);  //TODO: 3x?
			}
		}

	}
}