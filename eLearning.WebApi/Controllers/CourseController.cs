using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLearning.Data;
using eLearning.Domain;
using eLearning.WebApi.Factories;
using eLearning.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.WebApi.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IEFRepository _repo;

        public CourseController(IEFRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _repo.GetCourses(includeDetails: true)
                              .Select(p=> ModelFactory.Create(p));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _repo.GetCourse(id, includeDetails: true);
            if(result == null)
            {
                return NotFound($"Resourse with id {id} is not avaialable");
            }

            var model = ModelFactory.Create(result);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Create([FromBody]CourseCreateModel model)
        {
            if(ModelState.IsValid)
            {
                var course = new Course()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Duration = model.Duration,
                    Created = model.Created,
                    Price = model.Price,
                    Subject = _repo.GetSubject(model.SubjectId)
                };

                _repo.Add(course);
                if(_repo.SaveChanges())
                {
                    return Created($"/api/course/{course.CourseId}", 
                            ModelFactory.Create(course));
                }
                else
                {
                    return BadRequest("Error while saving to db");
                }
            }

            return BadRequest("Provide valid data to proceed");
        }

        [HttpPost("{id}")]
        public ActionResult Edit(int id, [FromBody]CourseEditModel model)
        {
            if(ModelState.IsValid)
            {
                var course = _repo.GetCourse(id);
                if(course == null)
                {
                    return NotFound($"Course with id {id} no more exists");
                }

                var subject = _repo.GetSubject(model.SubjectId);
                if(subject == null)
                {
                    return NotFound($"Subject with id {model.SubjectId} no more exists");
                }

                course.Title = model.Title;
                course.Description = model.Description;
                course.Price = model.Price;
                course.Duration = model.Duration;
                course.Created = model.Created;
                course.Subject = subject;

                _repo.Update(course);
                if(_repo.SaveChanges())
                {
                    return Ok("Data updated successfully");
                }
                else
                {
                    return BadRequest("Error saing changes to db");
                }
            }

            return BadRequest("Provide valid data to proceed");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var course = _repo.GetCourse(id);
            if(course == null)
            {
                return NotFound($"Course with id {id} no more exists");
            }

            _repo.Remove(course);
            if(!_repo.SaveChanges())
            {
                return BadRequest("Error saing changes to db");
            }

            return NoContent();
        }

    }
}