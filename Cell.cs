public class Cell
{
    public Inmate[] cellBeds;
    public bool HasToilet { get; set; }
    public int CellNr { get; }

    public Cell(int cellNr, int nrBeds, bool hasToilet)
    {
        this.HasToilet = hasToilet;
        cellBeds = new Inmate[nrBeds];
        this.CellNr = cellNr;

    }



}
