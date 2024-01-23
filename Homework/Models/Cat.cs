namespace Homework.Models
{
    /// <summary>
    /// 貓
    /// </summary>
    public class Cat : IAnimal
    {
        public Cat()
        {
            // 在建構子中設定初始值
            Name = "Cat";
            Price = 2000;
        }

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 移動速度
        /// </summary>
        public int DistanceInMeters { get; set; }
    }
}
