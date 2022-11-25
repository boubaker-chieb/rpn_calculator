using System;
using Rpn.Api.Exceptions;
using Rpn.Api.Models;

namespace Rpn.Api.Extensions
{
    public static class RpnStackListExtensions
    {
        /// <summary>
        /// Push a new value to a stack in a list of stacks.
        /// </summary>
        /// <param name="Stacks"></param>
        /// <param name="stackId"></param>
        /// <param name="newValue"></param>
        /// <exception cref="StackNotFoundException"></exception>
        public static void PushNewValueAt(this IList<RpnStack> Stacks, Guid stackId, int newValue)
        {
            var stack = Stacks.Where(stack => stack.Id.Equals(stackId))
                .FirstOrDefault();
            if (stack == null)
            {
                throw new StackNotFoundException();
            }
            stack.Push(newValue);
        }
        /// <summary>
        /// Connvert stack to readModel
        /// </summary>
        /// <param name="rpnStack"></param>
        /// <returns></returns>
        public static RpnStackReadModel ConvertToReadModel(this RpnStack rpnStack)
        {
            return new RpnStackReadModel
            {
                Id = rpnStack.Id,
                Name = rpnStack.Name,
                Data = rpnStack.ToArray()
            };
        }
        /// <summary>
        /// Apply oprator to the stack.
        /// </summary>
        /// <param name="rpnStack"></param>
        /// <param name="op"></param>
        public static void ApplyOperand(this RpnStack rpnStack, string op)
        {
            if (rpnStack != null && rpnStack.Count > 1)
            {
                var x = rpnStack.Pop();
                var y = rpnStack.Pop();
                rpnStack.Push(op.ApplyOperator(x, y));
            }
        }
    }
}

