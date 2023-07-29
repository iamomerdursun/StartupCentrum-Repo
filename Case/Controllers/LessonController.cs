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
                // Gelen verileri kullanarak yeni bir ders ekler.
                _lessonRepo.Add(new Lesson()
                {
                    Credit = vm.Credit,
                    Name = vm.Name,
                });
                return Ok("Lesson added successfully");
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Update")] // Unique route for Update method
        public IActionResult Update(UpdateLessonVM vm)
        {
            try
            {
                // Gelen verileri kullanarak bir dersi günceller.
                _lessonRepo.Update(new Lesson()
                {
                    Credit = vm.Credit,
                    Name = vm.Name,
                });
                return Ok("Lesson updated successfully");
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAll")] // Unique route for GetAll method
        public IActionResult GetAll()
        {
            try
            {
                // Tüm dersleri getirir.
                var result = _lessonRepo.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Get")] // Unique route for Get method
        public IActionResult Get(long id)
        {
            try
            {
                // Belirli bir dersi getirir.
                var result = _lessonRepo.Get(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Delete")] // Unique route for Delete method
        public IActionResult Delete(long id)
        {
            try
            {
                // Belirli bir dersi siler.
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
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }
    }
}
