namespace GameOfLife
{
    public class Board
    {
        public int Generation { get; set; }
        public int AliveCells { get; set; }
        public bool[,] Cells { get; set; }
    }
}
