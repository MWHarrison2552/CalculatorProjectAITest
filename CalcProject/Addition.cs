public class Addition : IOperation
{
    public string Name => "Add";
    public double Execute(double a, double b) => a + b;
}