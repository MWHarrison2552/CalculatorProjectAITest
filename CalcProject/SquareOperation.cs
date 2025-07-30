public class SquareOperation : IOperation
{
    public string Name => "Square";
    public double Execute(double a, double b) => a * a;
}
    // The second parameter 'b' is not used in this operation,
    // but it is included to maintain the interface consistency.
