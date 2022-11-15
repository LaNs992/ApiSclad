namespace ApiSclad.Models
{
    public class ScaldStaticModel
    {
        /// <summary>
        /// Общее кол-во товаров на складе
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Общая стоимость товаров на складе с НДС
        /// </summary>
        public decimal PriceWithNDS { get; set; }
        /// <summary>
        /// Общая стоимость товаров на складе без НДС
        /// </summary>
        public decimal PriceWithoutNDS { get; set; }
    }
}
