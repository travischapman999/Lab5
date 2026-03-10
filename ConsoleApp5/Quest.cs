using Microsoft.VisualBasic;

namespace QuestProgressTracker
{
	public class Quest
	{
		private string QuestName;

		public Quest(string questName)
		{
			QuestName = questName;
		}

		public bool IsCompleted { get; set; }
		public Collection objectives { get; set; } = new Collection();

		public void AddObjective(string name, int requiredAmount)
		{
			objectives.Add(new Objective(name, requiredAmount), name);
		}

		public Objective GetObjective(string name)
		{
			return (Objective)objectives[name];
		}

		public void ProgressObjective(string name, int amount)
		{
			Objective objective = (Objective)objectives[name];
			objective.CurrentAmount += amount;
			objective.MaxAmount();
			ObjectivesDone();
		}
		public void ObjectivesDone()
		{
			bool done = false;
			foreach (object objective in objectives)
			{
				if (((Objective)objective).CurrentAmount == ((Objective)objective).RequiredAmount)
				{
					done = true;
				}
				else
				{
					done = false;
					break;
				}
			}
			IsCompleted = done;
		}
	}
}
