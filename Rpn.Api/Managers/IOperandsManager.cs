using System;
using Rpn.Api.Exceptions;
using Rpn.Api.Extensions;
using Rpn.Api.Models;

namespace Rpn.Api.Managers
{
	public interface IOperandsManager
	{
        public IEnumerable<Operand> GetAllOperands();
        public void ApplyOprand(string op, Guid stackId);
    }
}

