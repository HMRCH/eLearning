using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eLearning.Domain
{
    [Table("Subject")]
    public class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
