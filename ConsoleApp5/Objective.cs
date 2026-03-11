namespace QuestProgressTracker
{

    public class Objective
    {
		public string Name { get; set; }
		public int RequiredAmount { get; set; }
		public int CurrentAmount { get; set; } = 0;
		public Objective(string name, int amount) {
			Name = name;
			RequiredAmount = amount;
		}
    }
}
