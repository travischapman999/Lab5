using Microsoft.VisualBasic;

namespace QuestProgressTracker
{
	public class Quest
	{
		private string QuestName;
		public bool IsCompleted { get; private set; }
		public bool ObjectivesCompleted { get; private set; }
		public Collection objectives { get; private set; } = new Collection();
		public Quest(string questName)
		{
			QuestName = questName;
		}

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
			ObjectivesCompleted = done;
		}
		public void TurnIn()
		{
			if (ObjectivesCompleted)
			{
				IsCompleted = true;
			}
			else
			{
				Console.WriteLine("The objectives are not completed.");
			}
		}
	}
}
