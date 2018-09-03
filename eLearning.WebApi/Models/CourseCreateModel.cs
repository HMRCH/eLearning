using System;

namespace eLearning.WebApi.Models
{
    public class CourseCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }
        public int SubjectId { get; set; }
    }
}