namespace Project_practice.Classes.Iterator
{
    public class ConcreteIterator : Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current;

        public ConcreteIterator(Aggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        public object First()
        {
            return _aggregate[0];
        }
        public bool HasNext()
        {
            if (_aggregate[_current + 1] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object Next()
        {
            object ret = null;

            _current++;

            if (_current < _aggregate.Count)
            {
                ret = _aggregate[_current];
            }

            return ret;
        }

        public  object CurrentItem()
        {
            return _aggregate[_current];
        }

        public  bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}