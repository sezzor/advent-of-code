namespace day9_2
{
    public class Knot
    {
        public Knot(int nr, int startRow, int startCol, string name)
        {
            Nr = nr;
            Name = name;
            Row = startRow;
            Col = startCol;
        }

        public int Nr { get; set; }
        public string Name { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}