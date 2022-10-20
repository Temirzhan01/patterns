using Project_practice.Classes.Strategy;

namespace Project_practice.Classes.Factory
{
    public class QuestionCCreator : Creator
    {
        public override Card FactoryMethod(IStrategy strategy, string a1, string a2, string a3, string a4, string key) 
        {
            return new QuestionCard(strategy, a1, a2, a3, a4, key);
        }
    }
}
