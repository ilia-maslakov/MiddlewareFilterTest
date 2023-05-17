using System.ComponentModel.DataAnnotations;

namespace Store.DataContext.Entities
{

    /// <summary>Таблица пользователей</summary>
    public class User
    {
        /// <summary>Идентификатор пользователя</summary>
        public Guid Id { get; set; }

        #pragma warning disable CS8618
        /// <summary>Имя</summary>
        public string Name { get; set; }

        /// <summary>Электро.почта</summary>
        [Required]
        public string Email { get; set; }

        /// <summary>Логин</summary>
        [Required]
        public string Login { get; set; }
        public string? Hash { get; set; }
        #pragma warning restore CS8618

        ///<summary>Роль</summary>
        public int Role { get; set; }
    }
}