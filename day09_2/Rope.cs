namespace day9_2
{
    public class Rope
    {
        public Rope(int startRow, int startCol)
        {
            Knots = new List<Knot>();
            Knots.Add(new Knot(0, startRow, startCol, "head")); // Head
            Knots.Add(new Knot(1, startRow, startCol, "tail"));
            Knots.Add(new Knot(2, startRow, startCol, "tail"));
            Knots.Add(new Knot(3, startRow, startCol, "tail"));
            Knots.Add(new Knot(4, startRow, startCol, "tail"));
            Knots.Add(new Knot(5, startRow, startCol, "tail"));
            Knots.Add(new Knot(6, startRow, startCol, "tail"));
            Knots.Add(new Knot(7, startRow, startCol, "tail"));
            Knots.Add(new Knot(8, startRow, startCol, "tail"));
            Knots.Add(new Knot(9, startRow, startCol, "last tail")); // Track this tail
        }

        public List<Knot> Knots { get; set; }
    }
}