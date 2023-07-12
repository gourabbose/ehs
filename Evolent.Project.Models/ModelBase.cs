using System;
using System.ComponentModel.DataAnnotations;

namespace Evolent.Project.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; set; } = default!;
        public DateTime CreatedOn { get; set; } = default!;
        public DateTime UpdatedOn { get; set; } = default!;
    }
}
