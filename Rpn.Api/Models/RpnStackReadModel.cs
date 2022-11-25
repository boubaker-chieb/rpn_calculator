using System;
namespace Rpn.Api.Models
{
	public class RpnStackReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<int> Data { get; set; }
    }
}

