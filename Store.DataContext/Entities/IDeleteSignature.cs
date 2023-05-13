namespace Store.DataContext.Entities;

public interface IDeleteSignature
{
    /// <summary>Флаг удаления</summary>
    public bool IsDeleted { get; set; }
    /// <summary>Дата удаления</summary>
    public DateTime? DeletedAt { get; set; }
    /// <summary>Идентификатор пользователя, удалившего сущность</summary>
    public Guid? DeletedById { get; set; }
    /// <summary>Пользователь, удаливший сущность</summary>
    public User? DeletedBy { get; set; }

}
