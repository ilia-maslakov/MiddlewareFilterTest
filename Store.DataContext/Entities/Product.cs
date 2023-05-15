namespace Store.DataContext.Entities
{
    /// <summary>Таблица товаров</summary>
    public class Product
    {
        /// <summary>Идентификатор товара</summary>
        public Guid Id { get; set; }

        /// <summary>Наименование товара</summary>
        public string Name { get; set; }

        /// <summary>Описание товара</summary>
        public string? Description { get; set; }

        /// <summary>Цена товара</summary>
        public decimal Price { get; set; }

        /// <summary>Количество</summary>
        public int Count { get; set; }
    }
}
