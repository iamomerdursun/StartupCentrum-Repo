using Case.Model;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.StudentRepo;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Case.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StudentController : ControllerBase
	{
		private readonly IStudentRepository _studentRepository;
		public StudentController(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;

		}
		[HttpPost]
		public IActionResult Add(AddStudentVM vm)
		{
			try
			{
				int rate = 0;
				if (vm.Surname != null) rate += 20;
				if (vm.Name != null) rate += 20;
				if (vm.Phone != null) rate += 20;
				if (vm.Adress != null) rate += 20;
				if (vm.TC != null) rate += 20; 
				_studentRepository.Add(new Student()
				{

					Adress = vm.Adress,
					Name = vm.Name,
					Phone = vm.Phone,
					Surname = vm.Surname,
					TC = vm.TC,
					Rate= rate,
				});
				return Ok(200);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		
		}
		[HttpPost]
		public IActionResult Update(UpdateStudentVM vm)
		{
			try
			{
				int rate = 0;
				if (vm.Surname != null) rate += 20;
				if (vm.Name != null) rate += 20;
				if (vm.Phone != null) rate += 20;
				if (vm.Adress != null) rate += 20;
				if (vm.TC != null) rate += 20;
				_studentRepository.Update(new Student()
				{

					Adress = vm.Adress,
					Name = vm.Name,
					Phone = vm.Phone,
					Surname = vm.Surname,
					TC = vm.TC,
					Rate= rate,
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
				var rest = _studentRepository.GetAll().OrderByDescending(x=>x.Rate).ToList();
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
				var rest = _studentRepository.Get(x=>x.Id==id);
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
				var rest = _studentRepository.Get(x => x.Id == id);
				_studentRepository.Delete(rest);
				return Ok("Deleted Is Success");
			}
			catch (Exception)
			{
				return BadRequest();
			}

		}

		[HttpGet]
		public IActionResult ProfileFillRate(long id)
		{
			try
			{
				var rest = _studentRepository.Get(x => x.Id == id);
				var rate = rest.Rate;
				
				
				return Ok($"%{rate}");
			}
			catch (Exception)
			{
				return BadRequest();
			}

		}


	}
}
