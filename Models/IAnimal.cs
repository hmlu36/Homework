namespace Homework.Models
{
    public interface IAnimal
    {
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

        public void Move() {
            Console.WriteLine($"{Name} moved {DistanceInMeters}");
        }
    }
}
