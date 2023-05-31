using Microsoft.EntityFrameworkCore;
using Store.DataContext.Entities;

namespace Store.DataContext.Context
{
    /// <summary>
    /// Интерфейс контекста базы данных магазина
    /// </summary>
    public interface IStoreDbContext
    {
        /// <summary>
        /// Коллекция продуктов в базе данных
        /// </summary>
        DbSet<Product> Products { get; set; }

        /// <summary>
        /// Коллекция пользователей в базе данных
        /// </summary>
        DbSet<User> Users { get; set; }

        /// <summary>
        /// Сохраняет все изменения, сделанные в этом контексте в базу данных
        /// </summary>
        /// <returns>Количество измененных записей</returns>
        int SaveChanges();

        /// <summary>
        /// Асинхронно сохраняет все изменения, сделанные в этом контексте в базу данных
        /// </summary>
        /// <returns>Количество измененных записей</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Возвращает пользователя по его имени
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <returns>Найденный пользователь или null</returns>
        User? GetUserByUsername(string username);
    }
}
