using System;
using Microsoft.AspNetCore.Mvc;
using Rpn.Api.Managers;
using Swashbuckle.AspNetCore.Annotations;

namespace Rpn.Api.Controllers
{
    [ApiController]
    [Route("rpn/[controller]")]
    public class OperandController
	{
        /// <summary>
        /// op manager
        /// </summary>
		private readonly IOperandsManager _operandsManager;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="operandsManager"></param>
        public OperandController(IOperandsManager operandsManager)
		{
            _operandsManager = operandsManager;
        }
        /// <summary>
        /// Get all operands.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Summary = "List all the operands")]
        public IActionResult GetAllStacks()
        {
            var operands = _operandsManager.GetAllOperands();
            return new OkObjectResult(operands);
        }
        /// <summary>
        /// Apply operator to a stack.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="stack_id"></param>
        /// <returns></returns>
        [HttpPost("{op}/stack/{stack_id}")]
        [SwaggerOperation(Summary = "Apply an operand to a stack")]
        public IActionResult ApplyOprand(string op, Guid stack_id)
        {
            _operandsManager.ApplyOprand(op, stack_id);
            return new OkResult();
        }
    }
}

