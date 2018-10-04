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
			var edgesToFollowForwards = _edges.Where(edge => edge.From == Node.StartIdentifier);
			foreach (var edge in edgesToFollowForwards)
			{
				WalkToSetEarliest(_nodes[edge.To], 0);
			}

			var earliestEnd = GetEarliestEnd();
			var edgesToFollowBackwards = _edges.Where(edge => edge.To == Node.EndIdentifier);
			foreach(var edge in edgesToFollowBackwards)
			{
				WalkToSetLatest(_nodes[edge.From], earliestEnd);
			}
		}

		private void WalkToSetEarliest(Node currentNode, int earliestStart)
		{
			if (currentNode.EarliestStart.HasValue && currentNode.EarliestStart >= earliestStart)
			{
				return;
			}

			currentNode.EarliestStart = earliestStart;

			var edgesToFollow = _edges.Where(nextEdge => nextEdge.From == currentNode.Name);
			foreach (var edge in edgesToFollow)
			{
				WalkToSetEarliest(_nodes[edge.To], currentNode.EarliestEnd.Value);
			}
		}

		private void WalkToSetLatest(Node currentNode, int latestEnd)
		{
			if (currentNode.LatestEnd.HasValue && currentNode.LatestEnd <= latestEnd)	//TODO: ?
			{
				return;
			}

			currentNode.LatestEnd = latestEnd;	//TODO: ?

			var edgesToFollow = _edges.Where(nextEdge => nextEdge.To == currentNode.Name);	//TODO: ?
			foreach (var edge in edgesToFollow)
			{
				WalkToSetLatest(_nodes[edge.From], currentNode.LatestStart.Value);	//TODO: ?
			}
		}

	}
}