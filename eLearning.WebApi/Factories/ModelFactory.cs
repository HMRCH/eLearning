using System;
using eLearning.Domain;
using eLearning.WebApi.Models;

namespace eLearning.WebApi.Factories
{
    public class ModelFactory
    {

        public static SubjectModel Create(Subject entity)
        {
            return new SubjectModel()
            {
                SubjectId = entity.SubjectId,
                Name = entity.Name,
                Code = entity.Code
            };
        }
        public static CourseModel Create(Course entity)
        {
            return new CourseModel()
            {
                CourseId = entity.CourseId,
                Title = entity.Title,
                Description = entity.Description,
                Created = entity.Created,
                IsFeatured = entity.IsFeatured,
                Price = entity.Price,
                Duration = entity.Duration,
                Subject = Create(entity.Subject)
            };
        }
    }
}