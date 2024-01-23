namespace Homework.Models
{
    /// <summary>
    /// 寵物店
    /// </summary>
    public class Store
    {
        public Store()
        {
            Animals = new List<IAnimal>();
        }

        /// <summary>
        /// 販售寵物
        /// </summary>
        public List<IAnimal> Animals { set; get; }
    }
}
