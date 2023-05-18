
namespace Core.Factory
{
    public interface IFactoryItemWithParams<T>
    {
        void Initialize(T t);
    }
    
    public interface IFactoryItemWithParams<T, D>
    {
        void Initialize(T t, D d);
    }
    
    public class BasicFactory<T> : IFactory<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }
    
    public class BasicFactory<T, D> : IFactory<T> where T : IFactoryItemWithParams<D>, new()
    {
        private D d;
        
        public BasicFactory(D d)
        {
            this.d = d;
        }
        
        public T Create()
        {
            var item = new T();
            item.Initialize(d);
            return item;
        }
    }
    
    public class BasicFactory<T, D, G> : IFactory<T> where T : IFactoryItemWithParams<D, G>, new()
    {
        private D d;
        private G g;
        
        public BasicFactory(D d, G g)
        {
            this.d = d;
            this.g = g;
        }
        
        public T Create()
        {
            var item = new T();
            item.Initialize(d, g);
            return item;
        }
    }
}