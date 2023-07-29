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
			_lessonRepo= lessonRepo;

		}
        [HttpPost]
		public IActionResult Add(AddLessonVM vm)
		{
			try
			{
				
				_lessonRepo.Add(new Lesson()
				{
					Credit = vm.Credit,
					Name = vm.Name,
 
				});
				return Ok(200);
			}
			catch (Exception)
			{
				return BadRequest();
			}

		}
		[HttpPost]
		public IActionResult Update(UpdateLessonVM vm)
		{
			try
			{
				_lessonRepo.Update(new Lesson()
				{
					Credit = vm.Credit,
					Name = vm.Name,

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
				var rest = _lessonRepo.GetAll();
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
				var rest = _lessonRepo.Get(x => x.Id == id);
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
				var rest = _lessonRepo.Get(x => x.Id == id);
				_lessonRepo.Delete(rest);
				return Ok("Deleted Is Success");
			}
			catch (Exception)
			{
				return BadRequest();
			}

		}

	}
}
