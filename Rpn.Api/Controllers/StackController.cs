using System;
using Microsoft.AspNetCore.Mvc;
using Rpn.Api.Managers;
using Rpn.Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Rpn.Api.Controllers
{
	[ApiController]
	[Route("rpn/[controller]")]
	public class StackController
	{
		/// <summary>
		/// Stacks manager
		/// </summary>
		private readonly IStacksManager _stacksManager;
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="stacksManager"></param>
        public StackController(IStacksManager stacksManager)
		{
			_stacksManager = stacksManager;
		}
        /// <summary>
        /// Create new Stack.
        /// </summary>
        /// <param name="stackCreationModel"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new stack")]
        public IActionResult CreateStack([FromBody] StackCreationModel stackCreationModel)
		{
			Guid createdStackId = _stacksManager.AddStack(stackCreationModel.Name);
			return new OkObjectResult(createdStackId);
		}
		/// <summary>
		/// Get all stacks.
		/// </summary>
		/// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Summary = "List of the available stacks")]
        public IActionResult GetAllStacks()
		{
			var stacks = _stacksManager.GetAllStacks();
			return new OkObjectResult(stacks);
		}
		/// <summary>
		/// Delete a stack.
		/// </summary>
		/// <param name="stack_id"></param>
		/// <returns></returns>
        [HttpDelete("stack_id")]
        [SwaggerOperation(Summary = "Delete a stack")]
        public IActionResult DeleteStack(Guid stack_id)
        {
			var deletedStackId = _stacksManager.DeleteStack(stack_id);
            return new OkObjectResult(deletedStackId);
        }
		/// <summary>
		/// Push new value to a stack.
		/// </summary>
		/// <param name="stack_id"></param>
		/// <param name="value"></param>
		/// <returns></returns>
        [HttpPost("stack_id")]
        [SwaggerOperation(Summary = "Push a new value to a stack")]
        public IActionResult PushNewValue(Guid stack_id, [FromQuery] int value)
        {
             _stacksManager.PushNewValue(stack_id, value);
            return new OkResult();
        }
		/// <summary>
		/// Get a stack by id.
		/// </summary>
		/// <param name="stack_id"></param>
		/// <returns></returns>
        [HttpGet("stack_id")]
        [SwaggerOperation(Summary = "Get a stack")]
        public IActionResult GetStackById(Guid stack_id)
        {
            var stack = _stacksManager.GetStackById(stack_id);
            return new OkObjectResult(stack);
        }
    }
}

