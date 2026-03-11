using QuestProgressTracker;

namespace TestProject
{
    public class QuestTests
    {
        [Fact]
        public void Quest_Is_Not_Completed_When_Objectives_Not_Finished()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            quest.ProgressObjective("Kill Goblins", 3);

            Assert.False(quest.IsCompleted);
        }

        [Fact]
        public void Quest_Is_Completed_When_All_Objectives_Are_Finished_And_Quest_Is_Turned_In()
        {
            var quest = new Quest("Goblin Slayer");
            quest.AddObjective("Kill Goblins", 5);

            quest.ProgressObjective("Kill Goblins", 5);
            quest.TurnIn();

            Assert.True(quest.IsCompleted);
        }

        [Fact]
		public void Quest_Is_Not_Completed_Until_Turned_In()
		{
			var quest = new Quest("Goblin Slayer");
			quest.AddObjective("Kill Goblins", 5);

			quest.ProgressObjective("Kill Goblins", 5);

			Assert.False(quest.IsCompleted);
		}
		[Fact]
		public void Progress_Throws_Exception_If_Too_Much()
		{
			var quest = new Quest("Goblin Slayer");
			quest.AddObjective("Kill Goblins", 5);

			Assert.Throws<InvalidOperationException>(() =>
			quest.ProgressObjective("Kill Goblins", 6));
		}
	}
}
