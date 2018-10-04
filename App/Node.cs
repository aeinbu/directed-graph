namespace App
{
	public class Node
	{
		public const string StartIdentifier = "f0bc4882-738f-4a8a-8da8-48da2114bda6";
		public const string EndIdentifier = "8ba812a8-73ef-487a-ae34-c2eebe3258c0";

		public string Name { get; }
		public int TimeValue { get; }

		public int? EarliestStart { get; set; }
		public int? EarliestEnd => EarliestStart + TimeValue;
		public int? LatestStart => LatestEnd - TimeValue;
		public int? LatestEnd { get; set; }


		public Node(string name, int timeValue)
		{
			Name = name;
			TimeValue = timeValue;
		}

		public override string ToString()
		{
			return $"Node({Name}): es:{EarliestStart}, ef:{EarliestEnd}, ls:{LatestStart}, lf:{LatestEnd}";
		}
	}

}