public class Multiplication : IOperation
{
    public string Name => "Multiply";
    public double Execute(double a, double b) => a * b;
}
