using Project_practice.Classes.Factory;

namespace Project_practice.Classes.Intermediate
{
    public class Connecter
    {
        public List<TextCard> tcards;
        public List<QuestionCard> qcards;
        public Connecter(List<TextCard> tcards, List<QuestionCard> qcards)
        {
            this.tcards = tcards;
            this.qcards = qcards;
        }
    }
}
