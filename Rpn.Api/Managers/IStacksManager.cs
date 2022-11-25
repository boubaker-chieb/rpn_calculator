using System;
using Rpn.Api.Exceptions;
using Rpn.Api.Models;

namespace Rpn.Api.Managers
{
    public interface IStacksManager
    {
        IList<RpnStack> Stacks { get; }
        Guid AddStack(string stackName);

        Guid DeleteStack(Guid stackId);

        void PushNewValue(Guid stackId, int newValue);

        RpnStackReadModel GetStackById(Guid stackId);

        IEnumerable<RpnStackReadModel> GetAllStacks();
    }
}

