using System;
using System.Threading;
using static System.Console;


public class Prison
{
    Block[] blocks = new Block[28];
    int blockCounter = 0;


    public void PrisonAdmin()
    {

        int menuChoice = 8;

        do
        {
            menuChoice = 0;
            Console.Clear();
            Console.WriteLine("1. Add block");
            Console.WriteLine("2. List blocks");
            Console.WriteLine("3. List cells");
            Console.WriteLine("4. Register inmate");
            Console.WriteLine("5. Release inmate");
            Console.WriteLine("6. Exit");



            ConsoleKeyInfo UserInput = Console.ReadKey();

            if (char.IsDigit(UserInput.KeyChar))
            {
                menuChoice = int.Parse(UserInput.KeyChar.ToString());

            }
            else
            {
                menuChoice = -1;
            }

            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    CreateBlock();
                    break;

                case 2:
                    Console.Clear();
                    PrintBlocks();
                    break;

                case 3:
                    Console.Clear();
                    PrintCells();
                    break;
                case 4:
                    Console.Clear();
                    RegisterInmate();
                    break;
                case 5:
                    Clear();
                    ReleaseInmate();
                    break;

            }


        } while (menuChoice != 6);
    }

    public void CreateBlock()
    {

        int cellCounter = 1;

        SetCursorPosition(5, 7);
        WriteLine("Block ID: ");
        SetCursorPosition(5, 9);
        WriteLine("Cells: ");
        SetCursorPosition("Block ID: ".Length + 4, 7);
        string blockId = ReadLine().ToUpper();
        SetCursorPosition("Cells: ".Length + 4, 9);
        int nrCells = int.Parse(ReadLine());



        bool blockExists = false;

        foreach (var block in blocks)
        {
            if (block == null)
            {
                continue;
            }

            if (block.BlockId == blockId)
            {
                Clear();
                WriteLine("Block Id already exists");
                blockExists = true;
                Thread.Sleep(1000);

            }



        }

        if (!blockExists)
        {

            blocks[blockCounter] = new Block(blockId, nrCells);


            for (int i = 0; i < blocks[blockCounter].cells.Length; i++)
            {
                Clear();
                SetCursorPosition(5, 5);
                WriteLine("Block: {0}", blocks[blockCounter].BlockId);
                SetCursorPosition(5, 7);
                WriteLine("Cell ID: {0}", cellCounter.ToString("00"));
                SetCursorPosition(5, 9);
                WriteLine("Number of beds: ");
                SetCursorPosition(5, 11);
                WriteLine("Has toilet: ");
                SetCursorPosition("Number of beds: ".Length + 4, 9);
                int nrBeds = int.Parse(ReadLine());
                SetCursorPosition("Has toilet YES/NO: ".Length + 4, 11);
                string strhasToilet = ReadLine();

                bool hasToilet = false;

                if (strhasToilet == "yes" || strhasToilet == "YES")
                {
                    hasToilet = true;
                }


                blocks[blockCounter].cells[i] = new Cell(cellNr: cellCounter, nrBeds: nrBeds, hasToilet: hasToilet);

                cellCounter++;

            }

            blockCounter++;

        }


    }

    public void PrintBlocks()
    {
        int freeBeds = 0;

        WriteLine("Block" + "Cells".PadLeft(25, ' ') + "Available beds".PadLeft(25, ' '));
        WriteLine(" ".PadLeft(55, '-'));


        foreach (var block in blocks)
        {
            if (block == null)
            {
                continue;
            }


            Write(block.BlockId + block.cells.Length.ToString().PadLeft(25, ' '));

            foreach (var cell in block.cells)
            {


                foreach (var prisoner in cell.cellBeds)
                {
                    if (prisoner == null)
                    {
                        freeBeds++;

                    }
                }





            }

            WriteLine(freeBeds.ToString().PadLeft(17, ' '));
            freeBeds = 0;

        }

        WriteLine("Press any key to continue");
        ReadKey();
    }

    public void PrintCells()
    {
        int freeBeds = 0;
        bool blockExists = false;
        int blockIndex = 0;
        int tempBlockIndex = 0;

        SetCursorPosition(5, 7);
        WriteLine("Block ID: ");
        SetCursorPosition("Block ID: ".Length + 4, 7);
        string blockId = ReadLine().ToUpper();
        Clear();

        foreach (var block in blocks)
        {
            if (block == null)
            {
                continue;
            }

            if (block.BlockId == blockId)
            {

                blockExists = true;
                blockIndex = tempBlockIndex;

            }
            tempBlockIndex++;

        }

        if (blockExists)
        {

            WriteLine(@"Cell ID" + "Available beds".PadLeft(45, ' '));
            WriteLine(" ".PadLeft(55, '-'));


            for (int i = 0; i < blocks[blockIndex].cells.Length; i++)
            {

                for (int j = 0; j < blocks[blockIndex].cells[i].cellBeds.Length; j++)
                {
                    if (blocks[blockIndex].cells[i].cellBeds[j] == null)
                    {
                        freeBeds++;

                    }

                }
                WriteLine(blocks[blockIndex].BlockId + blocks[blockIndex].cells[i].CellNr.ToString("00") + freeBeds.ToString().PadLeft(35, ' '));
                freeBeds = 0;


            }


        }
        else
        {
            WriteLine("No such block exists.");
        }

        WriteLine("Press any key to continue");
        ReadKey();

    }



    public void RegisterInmate()
    {
        bool inmateIdExists = false;
        bool freeBed = true;

        Clear();

        try
        {
            SetCursorPosition(5, 5);
            WriteLine("First name: ");
            SetCursorPosition(5, 7);
            WriteLine("Last name: ");
            SetCursorPosition(5, 9);
            WriteLine("Social security number: ");
            SetCursorPosition(5, 11);
            WriteLine("Inmate ID: ");
            SetCursorPosition(5, 13);
            WriteLine("cell ID: ");
            SetCursorPosition("First name: ".Length + 4, 5);
            string firstName = ReadLine();
            SetCursorPosition("Last name: ".Length + 4, 7);
            string lastName = ReadLine();
            SetCursorPosition("Social security number: ".Length + 4, 9);
            string socialSecurityNumber = ReadLine();
            SetCursorPosition("Inmate ID: ".Length + 4, 11);
            string inmateId = ReadLine();
            SetCursorPosition("Cell ID: ".Length + 4, 13);
            string cellId = ReadLine();





            foreach (var block in blocks)
            {

                if (block == null)
                {
                    continue;
                }

                foreach (var cell in block.cells)
                {
                    foreach (var inmate in cell.cellBeds)
                    {
                        if (inmate == null)
                        {
                            continue;
                        }
                        else if (inmate.InmateId == inmateId)
                        {
                            Clear();
                            inmateIdExists = true;
                            SetCursorPosition(5, 7);
                            WriteLine("Inmate ID already exits");
                            Thread.Sleep(1000);
                        }

                    }


                }

            }


            if (!inmateIdExists)
            {
                string blockId = cellId.Substring(0, 1).ToUpper();
                int cellNr = int.Parse(cellId.Substring(1, 1));

                int freeBeds = 0;
                bool blockExists = false;
                int blockIndex = 0;
                int tempBlockIndex = 0;
                bool cellExists = false;
                int cellIndex = 0;


                foreach (var block in blocks)
                {
                    if (block == null)
                    {
                        continue;
                    }

                    if (block.BlockId == blockId)
                    {

                        blockExists = true;
                        blockIndex = tempBlockIndex;

                    }
                    tempBlockIndex++;

                }

                if (blockExists)
                {


                    for (int i = 0; i < blocks[blockIndex].cells.Length; i++)
                    {

                        if (blocks[blockIndex].cells[i].CellNr == cellNr)
                        {
                            cellExists = true;
                            cellIndex = i;
                        }



                    }



                }

                if (cellExists)

                {
                    int inmateIndex = 0;
                    int tempInmateIndex = 0;

                    foreach (var inmate in blocks[blockIndex].cells[cellIndex].cellBeds)
                    {
                        if (inmate == null)
                        {
                            freeBed = true;
                            inmateIndex = tempInmateIndex;
                            break;
                        }
                        else
                        {
                            freeBed = false;
                        }
                        tempInmateIndex++;

                    }

                    if (freeBed)
                    {
                        Clear();
                        SetCursorPosition(5, 7);
                        WriteLine("Inmate sucessfully registerd");
                        blocks[blockIndex].cells[cellIndex].cellBeds[inmateIndex] = new Inmate(firstName: firstName, lastName: lastName, socialSecurityNumber: socialSecurityNumber, inmateId: inmateId);
                        Thread.Sleep(1000);

                    }
                    else if (!freeBed)
                    {
                        Clear();
                        SetCursorPosition(5, 7);
                        WriteLine("No free beds");
                        Thread.Sleep(1000);

                    }

                }
                else
                {
                    Clear();
                    SetCursorPosition(5, 7);
                    WriteLine("No such cell exists.");
                    Thread.Sleep(1000);
                }




            }

        }

        catch (Exception)
        {

            WriteLine("An error occured");
        }






    }



    public void ReleaseInmate()
    {
        bool inmateExists = false;
        string inmateID;

        try
        {
            SetCursorPosition(5, 7);
            WriteLine("Inmate ID: ");
            SetCursorPosition("Inmate ID: ".Length + 5, 7);

            inmateID = ReadLine();




            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] == null)
                {
                    continue;
                }

                for (int j = 0; j < blocks[i].cells.Length; j++)
                {

                    for (int k = 0; k < blocks[i].cells[j].cellBeds.Length; k++)
                    {

                        if (blocks[i].cells[j].cellBeds[k] == null)
                        {
                            continue;
                        }

                        if (blocks[i].cells[j].cellBeds[k].InmateId == inmateID)
                        {
                            Clear();
                            SetCursorPosition(5, 7);
                            WriteLine("Inmate Released");
                            SetCursorPosition(5, 9);
                            WriteLine(blocks[i].cells[j].cellBeds[k].ToString());
                            inmateExists = true;
                            blocks[i].cells[j].cellBeds[k] = null;
                        }

                    }
                }

            }

        }

        catch
        {
            WriteLine("Please enter a valid ID");

        }


        if (!inmateExists)
        {
            Clear();
            SetCursorPosition(5, 7);

            WriteLine("Inmate not found");
        }
        SetCursorPosition(5, 11);
        WriteLine("Press any key to continue");
        ReadKey();

    }

}








