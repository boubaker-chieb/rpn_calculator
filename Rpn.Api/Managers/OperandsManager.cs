using System;
using Rpn.Api.Models;
using Rpn.Api.Extensions;
using Rpn.Api.Exceptions;

namespace Rpn.Api.Managers
{
    public class OperandsManager : IOperandsManager
    {
        /// <summary>
        /// List of available operand.
        /// </summary>
        private IList<Operand> operands = new List<Operand>
        {
            new Operand
            {
                Name= "Add",
                Symbole="+"
            },
            new Operand
            {
                Name= "Soustract",
                Symbole="-"
            },
            new Operand
            {
                Name= "Multiply",
                Symbole="*"
            },
            new Operand
            {
                Name= "Devide",
                Symbole="/"
            }
        };
        /// <summary>
        /// Stack manager
        /// </summary>
        private IStacksManager _stacksManager;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stacksManager"></param>
        public OperandsManager(IStacksManager stacksManager)
        {
            _stacksManager = stacksManager;
        }
        /// <summary>
        /// Return All operands
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Operand> GetAllOperands()
        {
            return operands;
        }
        /// <summary>
        /// Apply oprrand
        /// </summary>
        /// <param name="op"></param>
        /// <param name="stackId"></param>
        public void ApplyOprand(string op, Guid stackId)
        {
            var stack = _stacksManager.Stacks.Where(stk => stk.Id == stackId).FirstOrDefault();
            if (stack == null)
            {
                throw new StackNotFoundException();
            }
            stack.ApplyOperand(op);
        }
    }
}

