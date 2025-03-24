using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fundamentos_Entity_Framework_C_.Models;

//[Table("Homework")]
public class Homework
{
    //[Key]
    public Guid HomeworkId { get; set; }
    //[ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    //[Required]
    //[MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Category Category { get; set; }
    //[NotMapped]
    [JsonIgnore]
    public string Summary { get; set; }

}

public enum Priority
{
    Low,
    Medium, 
    High

}
