using System;
namespace Rpn.Api.Extensions
{
	public static class OperatorExtensions
	{
        public static int ApplyOperator(this string logic, int x, int y)
        {
            switch (logic)
            {
                case "+": return x + y;
                case "-": return x - y;
                case "*": return x * y;
                case "/":
                    if (y==0)
                    {
                        throw new DivideByZeroException();
                    }
                    return x / y;
                default: throw new Exception("invalid logic");
            }
        }
    }
}

