using Microsoft.AspNetCore.Mvc;
using POCDemoApp.API.Controller.Interfaces.Core;
using POCDemoApp.API.Controllers.Core;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POCDemoApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FnCaseNotesController : Controller<FnCaseNoteApiModel>, IController<FnCaseNoteApiModel>
	{
		private readonly IFnCaseNoteService _fnCaseNoteService;

		public FnCaseNotesController(IFnCaseNoteService service)
			: base(service)
		{
			_fnCaseNoteService = Service as IFnCaseNoteService;
		}

		#region Add methods
		[HttpPost]
		public new IActionResult Add([FromBody] FnCaseNoteApiModel caseNoteApiModel)
		{
			return base.Add(caseNoteApiModel);
		}
		#endregion

		#region Update methods
		[Route("[action]")]
		[HttpPut]
		public IActionResult UpdateTitle([FromBody] FnCaseNoteApiModel note)
		{
			try
			{
				_fnCaseNoteService.UpdateTitle(note);
			}
			catch (Exception)
			{
				return BadRequest();
			}

			return Ok();
		}
		#endregion

		#region Delete methods
		[HttpDelete]
		public new IActionResult Delete([FromBody] FnCaseNoteApiModel caseNoteApiModel)
		{
			return base.Delete(caseNoteApiModel);
		}
		#endregion

		#region Hide unimplemented methods
		[NonAction]
		public new Task<IActionResult> Get(long id)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new Task<IActionResult> GetAll()
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new Task<IActionResult> Find(Expression<Func<FnCaseNoteApiModel, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new IActionResult AddRange(IEnumerable<FnCaseNoteApiModel> entities)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new IActionResult Update(FnCaseNoteApiModel entity)
		{
			throw new NotImplementedException();
		}

		[NonAction]
		public new IActionResult DeleteRange(IEnumerable<FnCaseNoteApiModel> entities)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
