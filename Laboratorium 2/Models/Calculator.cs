namespace Laboratorium_2.Models
{
    public class Calculator
    {
        public Operators? Operator { get; set; }

        public double? X { get; set; }
        public double? Y { get; set; }

        public double Calculate() 
        {
            switch(Operator)
            {
                case Operators.Add: 
                    return (double)(X + Y);
                case Operators.Sub: 
                    return (double)(X - Y);
                case Operators.Mul: 
                    return (double)(X * Y);
                case Operators.Div: 
                    return (double)(X / Y);
                default: return double.NaN;
            }
        }
        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }
    }
}
