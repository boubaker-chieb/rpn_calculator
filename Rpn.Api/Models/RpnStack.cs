namespace Rpn.Api.Models
{
    public class RpnStack : Stack<int>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
    }
}


