using Microsoft.AspNetCore.Mvc;
using POCDemoApp.API.Controller.Interfaces.Core;
using POCDemoApp.API.Controllers.Core;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POCDemoApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ForeignNationalsController : Controller<ForeignNationalApiModel>, IController<ForeignNationalApiModel>
	{
		private readonly IForeignNationalService _foreignNationalService;

		public ForeignNationalsController(IForeignNationalService service)
			: base(service)
		{
			_foreignNationalService = Service as IForeignNationalService;
		}

		#region Get methods
		[HttpGet("{id}")]
		public new async Task<IActionResult> Get(long id)
		{
			return await base.Get(id);
		}

		[Route("[action]/{id}")]
		[HttpGet]
		public async Task<IActionResult> GetCaseNotes(long id)
		{
			var caseNotes = await Task.FromResult(_foreignNationalService.GetCaseNotes(id));

			if (caseNotes == null || !caseNotes.Any())
				return NotFound();

			return Ok(caseNotes);
		}
		#endregion

		#region Hide unimplemented methods
		[NonAction]
		public new Task<IActionResult> GetAll()
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new Task<IActionResult> Find(Expression<Func<ForeignNationalApiModel, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new IActionResult Add(ForeignNationalApiModel caseNoteApiModel)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new IActionResult AddRange(IEnumerable<ForeignNationalApiModel> entities)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new IActionResult Update(ForeignNationalApiModel entity)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new IActionResult Delete(ForeignNationalApiModel caseNoteApiModel)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new IActionResult DeleteRange(IEnumerable<ForeignNationalApiModel> entities)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
