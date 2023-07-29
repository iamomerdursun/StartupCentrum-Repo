using Case.Model;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.NotesRepo;

namespace Case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesRepoController : ControllerBase
    {
        private readonly INotesRepo _notesRepo;

        public NotesRepoController(INotesRepo notesRepo)
        {
            _notesRepo = notesRepo;
        }

        [HttpPost("Add")]
        public IActionResult Add(AddNotesRepoVM vm)
        {
            try
            {
                // Gelen verileri kullanarak yeni bir not ekler.
                _notesRepo.Add(new Notes()
                {
                    Butt = vm.Butt,
                    Final = vm.Final,
                    LessonId = vm.LessonId,
                    Midterm = vm.Midterm,
                    StudentId = vm.StudentId,
                });
                return Ok("Added successfully");
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }

        [HttpPost("Update")]
        public IActionResult Update(UpdateNotesVM vm)
        {
            try
            {
                // Gelen verileri kullanarak bir not günceller.
                _notesRepo.Update(new Notes()
                {
                    Butt = vm.Butt,
                    Final = vm.Final,
                    LessonId = vm.LessonId,
                    Midterm = vm.Midterm,
                    StudentId = vm.StudentId,
                });
                return Ok("Updated successfully");
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                // Tüm notları getirir.
                var result = _notesRepo.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }

        [HttpGet("GetAllStudent")]
        public IActionResult GetAllStudent(long id)
        {
            try
            {
                // Belirli bir öğrencinin tüm notlarını getirir.
                var result = _notesRepo.GetAll(x => x.StudentId == id);
                return Ok(result);
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }

        [HttpGet("Get")]
        public IActionResult Get(long id)
        {
            try
            {
                // Belirli bir notu getirir.
                var result = _notesRepo.GetAll(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }

        [HttpPost("Delete")]
        public IActionResult Delete(long id)
        {
            try
            {
                // Belirli bir notu siler.
                var note = _notesRepo.Get(x => x.Id == id);
                if (note == null)
                {
                    // Not bulunamazsa 404 Not Found yanıtı döner.
                    return NotFound("Note not found");
                }

                _notesRepo.Delete(note);
                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                // Eğer bir hata oluşursa 400 Bad Request yanıtı döner.
                return BadRequest();
            }
        }
    }
}
