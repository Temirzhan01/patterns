using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public class QuestionCard :Card
    {
        IStrategy strategy;
        public QuestionCard(IStrategy strategy) : base(strategy)
        {
        }
    }
}
