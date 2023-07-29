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
		[HttpPost]
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
				return Ok(200);
			}
			catch (Exception)
			{
				return BadRequest();
			}

		}
		[HttpPost]
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
				return Ok(200);
			}
			catch (Exception)
			{
				return BadRequest();
			}

		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var rest = _notesRepo.GetAll();
				return Ok(rest);
			}
			catch (Exception)
			{
				return BadRequest();
			}

		}
		[HttpGet]
		public IActionResult GetAllStudent(long id)
		{
			try
			{
				var rest = _notesRepo.GetAll(x => x.StudentId == id);
				return Ok(rest);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
		[HttpGet]
		public IActionResult Get(long id)
		{
			try
			{
				var rest = _notesRepo.GetAll(x => x.Id == id);
				return Ok(rest);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
		[HttpPost]
		public IActionResult Delete(long id)
		{
			try
			{
				var rest = _notesRepo.Get(x => x.Id == id);
				_notesRepo.Delete(rest);
				return Ok("Deleted Is Success");
			}
			catch (Exception)
			{
				return BadRequest();
			}

		}
	}
}
