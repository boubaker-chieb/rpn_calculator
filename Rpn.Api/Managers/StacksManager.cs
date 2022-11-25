using System;
using Rpn.Api.Exceptions;
using Rpn.Api.Extensions;
using Rpn.Api.Models;

namespace Rpn.Api.Managers
{
    public class StacksManager : IStacksManager
    {
        /// <summary>
        /// List of all RPN Stacks.
        /// </summary>
        public IList<RpnStack> Stacks { get; } = new List<RpnStack>();

        public StacksManager()
        {

        }
        /// <summary>
        /// Add new RPN Stack to the list.
        /// </summary>
        /// <param name="stackName"></param>
        /// <returns></returns>
        public Guid AddStack(string stackName)
        {
            var stackId = Guid.NewGuid();
            var newStack = new RpnStack
            {
                Id = stackId,
                Name = stackName
            };
            Stacks.Add(newStack);
            return stackId;
        }
        /// <summary>
        /// Delete a stack from the list.
        /// </summary>
        /// <param name="stackId"></param>
        /// <returns></returns>
        /// <exception cref="StackNotFoundException"></exception>
        public Guid DeleteStack(Guid stackId)
        {
            var stackToDelete = Stacks.Where(stack => stack.Id.Equals(stackId))
                .FirstOrDefault();

            if (stackToDelete == null)
            {
                throw new StackNotFoundException();
            }
            Stacks.Remove(stackToDelete);
            return stackId;
        }
        /// <summary>
        /// Push a new value to a stack in the list.
        /// </summary>
        /// <param name="stackId"></param>
        /// <param name="newValue"></param>
        public void PushNewValue(Guid stackId, int newValue)
        {
            Stacks.PushNewValueAt(stackId, newValue);
        }
        /// <summary>
        /// Get a stack by id.
        /// </summary>
        /// <param name="stackId"></param>
        /// <returns></returns>
        public RpnStackReadModel GetStackById(Guid stackId)
        {
            var stack = Stacks.Where(stack => stack.Id.Equals(stackId))
                .FirstOrDefault();
            if (stack==null)
            {
                throw new StackNotFoundException();
            }
            return stack.ConvertToReadModel();
        }
        /// <summary>
        /// Return All stacks
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RpnStackReadModel> GetAllStacks()
        {
            return Stacks.Select(stk=>stk.ConvertToReadModel());
        }
    }
}

