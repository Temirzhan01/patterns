using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public class QuestionCCreator : Creator
    {
        public override Card FactoryMethod(IStrategy strategy) 
        {
            return new QuestionCard(strategy);
        }
    }
}
