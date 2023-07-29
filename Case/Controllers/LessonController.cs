using Case.Model;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.LessonRepo;

namespace Case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepo _lessonRepo;

        public LessonController(ILessonRepo lessonRepo)
        {
            _lessonRepo = lessonRepo;
        }

        [HttpPost]
        [Route("Add")] // Unique route for Add method
        public IActionResult Add(AddLessonVM vm)
        {
            try
            {
                _lessonRepo.Add(new Lesson()
                {
                    Credit = vm.Credit,
                    Name = vm.Name,
                });
                return Ok("Lesson added successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Update")] // Unique route for Update method
        public IActionResult Update(UpdateLessonVM vm)
        {
            try
            {
                _lessonRepo.Update(new Lesson()
                {
                    Credit = vm.Credit,
                    Name = vm.Name,
                });
                return Ok("Lesson updated successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAll")] // Unique route for GetAll method
        public IActionResult GetAll()
        {
            try
            {
                var result = _lessonRepo.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Get")] // Unique route for Get method
        public IActionResult Get(long id)
        {
            try
            {
                var result = _lessonRepo.Get(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Delete")] // Unique route for Delete method
        public IActionResult Delete(long id)
        {
            try
            {
                var lesson = _lessonRepo.Get(x => x.Id == id);
                if (lesson == null)
                {
                    return NotFound("Lesson not found");
                }

                _lessonRepo.Delete(lesson);
                return Ok("Lesson deleted successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
