namespace Store.DataContext.Entities;

public interface IActionSignature
{
    /// <summary>Дата выполнения действия</summary>
    public DateTime DoneAt { get; set; }
    /// <summary>Идентификатор пользователя, выполнившего действие</summary>
    public Guid DoneById { get; set; }
    /// <summary>Пользователь, выполнивший действие</summary>
    public User DoneBy { get; set; }

}
