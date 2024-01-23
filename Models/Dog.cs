namespace Homework.Models
{
    /// <summary>
    /// 狗
    /// </summary>
    public class Dog : IAnimal
    {
        public Dog()
        {
            // 在建構子中設定初始值
            Name = "Dog";
            Price = 3000;
        }

        public string Name { get; set; }
        public int Price { get; set; }
        public int DistanceInMeters { get; set; }

    }
}
