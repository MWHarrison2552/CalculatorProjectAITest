public class Subtraction : IOperation
{
    public string Name => "Subtract";
    public double Execute(double a, double b) => a - b;
}
