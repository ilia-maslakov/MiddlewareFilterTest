namespace Store.DataContext.Entities;

public interface IEntitySignature
{
    /// <summary>Дата создания</summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>Идентификатор пользователя, создавшего сущность</summary>
    public Guid CreatedById { get; set; }
    /// <summary>Пользователь, создавший сущность</summary>
    public User CreatedBy { get; set; }

    /// <summary>Дата изменения</summary>
    public DateTime? UpdatedAt { get; set; }
    /// <summary>Идентификатор пользователя, изменившего сущность</summary>
    public Guid? UpdatedById { get; set; }
    /// <summary>Пользователь, изменивший сущность</summary>
    public User? UpdatedBy { get; set; }

}
