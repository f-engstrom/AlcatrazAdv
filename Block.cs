class Block
{
    public string BlockId { get; set; }
    public Cell[] cells;

    public Block(string blockId, int nrCells)
    {
        this.BlockId = blockId;
        cells = new Cell[nrCells];
    }



}
