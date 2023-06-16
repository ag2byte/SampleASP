namespace RestTest.Service
{
    public interface IFruitService
    {

        List<Fruit> GetFruits(string fruitName, bool imported);
    }
}