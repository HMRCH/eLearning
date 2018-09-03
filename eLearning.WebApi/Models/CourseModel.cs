using System;

namespace eLearning.WebApi.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }
        public SubjectModel Subject { get; set; }
    }
}