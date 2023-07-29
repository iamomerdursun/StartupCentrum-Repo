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
                return BadRequest();
            }
        }

        [HttpPost("Update")]
        public IActionResult Update(UpdateNotesVM vm)
        {
            try
            {
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
                return BadRequest();
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _notesRepo.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllStudent")]
        public IActionResult GetAllStudent(long id)
        {
            try
            {
                var result = _notesRepo.GetAll(x => x.StudentId == id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Get")]
        public IActionResult Get(long id)
        {
            try
            {
                var result = _notesRepo.GetAll(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Delete")]
        public IActionResult Delete(long id)
        {
            try
            {
                var note = _notesRepo.Get(x => x.Id == id);
                if (note == null)
                {
                    return NotFound("Note not found");
                }

                _notesRepo.Delete(note);
                return Ok("Deleted successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
