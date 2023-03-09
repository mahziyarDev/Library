namespace Library.Common.BaseModel;

public class BaseModel
{
    public Guid Id { get; set; }
    public DateTime CreateEntity { get; set; } = DateTime.Now;
    public DateTime UpdateEntity { get; set; }
}