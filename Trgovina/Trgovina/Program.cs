// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

int state = 0;
var selectionMain = 0;
var selectionArticles = 0;
var selectionWorkers = 0;
var selectionReceipts = 0;
var selectionStatistics = 0;

do
{
    Console.WriteLine(
        "MENI:\n" +
        "1 - Artikli\n" +
        "2 - Radnici\n" +
        "3 - Računi\n" +
        "4 - Statistika\n" +
        "0 - Izlaz\n\n"
    );
    Console.WriteLine("Unesi odabir: ");
    selectionMain = int.Parse(Console.ReadLine());

    switch (selectionMain)
    {
        case 0:
            Console.WriteLine("Izlaz...");
            state = (int)ProgramState.TERMINATE;
            break;
        case 1:
            state = ArticlesMenu();
            break;
        case 2:
            state = WorkersMenu();
            break;
        case 3:
            state = ReceiptsMenu();
            break;
        case 4:
            state = StatisticsMenu();
            break;
        default:
            Console.WriteLine("Krivi unos pokušaj ponovo, pritisni neku tipku za nastavak...");
            char chr = Console.ReadKey().KeyChar;
            break;
    }
    Console.Clear();

} while(selectionMain < 0 || selectionMain > 4 || state == (int)ProgramState.CONTINUE);
int ArticlesMenu()
{
    do { 
        Console.WriteLine(
           "IZBORNIK - Artikli\n" +
           "1 - Unos artikla\n" +
           "2 - Brisanje artikla\n" +
           "3 - Uređivanje artikla\n" +
           "4 - Ispis\n" +
           "0 - <- NAZAD NA GLAVNI MENI\n"
        );
        Console.WriteLine("Unesi odabir: ");
        selectionArticles = int.Parse(Console.ReadLine());

        switch (selectionArticles)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                break;
            case 1:
                AddArticles();
                break;
            case 2:
                DeleteArticles();
                break;
            case 3:
                EditArticles();
                break;
            case 4:
                PrintArticles();
                break;
            default:
                Console.WriteLine("Krivi unos pokušaj ponovo, pritisni neku tipku za nastavak...");
                char chr = Console.ReadKey().KeyChar;
                break;
        }
        
    }while (selectionArticles < 0 || selectionArticles > 4);

    return (int)ProgramState.CONTINUE;
}

int WorkersMenu()
{
    do
    {
        Console.WriteLine(
           "IZBORNIK - Radnici\n" +
           "1 - Unos radnika\n" +
           "2 - Brisanje radnika\n" +
           "3 - Uređivanje radnika\n" +
           "4 - Ispis\n" +
           "0 - <- NAZAD NA GLAVNI MENI\n"
        );
        Console.WriteLine("Unesi odabir: ");
        selectionWorkers = int.Parse(Console.ReadLine());
        
        switch (selectionWorkers)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                break;
            case 1:
                AddWorkers();
                break;
            case 2:
                DeleteWorkers();
                break;
            case 3:
                EditWorkers();
                break;
            case 4:
                PrintWorkers();
                break;
            default:
                Console.WriteLine("Krivi unos pokušaj ponovo, pritisni neku tipku za nastavak...");
                char chr = Console.ReadKey().KeyChar;
                break;
        }
        
    } while (selectionWorkers < 0 || selectionWorkers > 4);
    return 0;
}
int ReceiptsMenu()
{
    do
    {
        Console.WriteLine(
           "IZBORNIK - Računi\n" +
           "1 - Unos računa\n" +
           "2 - Ispis\n" +
           "0 - <- NAZAD NA GLAVNI MENI\n"
        );
        Console.WriteLine("Unesi odabir: ");
        selectionReceipts = int.Parse(Console.ReadLine());

        switch (selectionReceipts)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                break;
            case 1:
                AddReceipt();
                break;
            case 2:
                PrintReceipt();
                break;
            default:
                Console.WriteLine("Krivi unos pokušaj ponovo, pritisni neku tipku za nastavak...");
                char chr = Console.ReadKey().KeyChar;
                break;
        }
        
    } while (selectionReceipts < 0 || selectionReceipts > 2);

    return (int)ProgramState.CONTINUE;
}
int StatisticsMenu()
{
    do
    {
        Console.WriteLine(
           "IZBORNIK - Računi\n" +
           "1 - Ukupan broj artikala\n" +
           "2 - Vrijednost neprodanih artikala\n" +
           "3 - Vrijednost prodanih artikala\n" +
           "4 - Stanje po mjesecima\n" +
           "0 - <- NAZAD NA GLAVNI MENI\n"
        );
        Console.WriteLine("Unesi odabir: ");
        selectionStatistics = int.Parse(Console.ReadLine());

        switch (selectionStatistics)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                break;
            case 1:
                TotalNumberOfArticles();
                break;
            case 2:
                ValueOfNonsoldArticles();
                break;
            case 3:
                ValueOfSoldArticles();
                break;
            case 4:
                StateByMonth();
                break;
            default:
                Console.WriteLine("Krivi unos pokušaj ponovo, pritisni neku tipku za nastavak...");
                char chr = Console.ReadKey().KeyChar;
                break;
        }
        
    } while (selectionStatistics < 0 || selectionStatistics > 4);

    return (int)ProgramState.CONTINUE;
}

void StateByMonth()
{
    Console.WriteLine("TODO\n");
}

void ValueOfSoldArticles()
{
    Console.WriteLine("TODO\n");
}

void ValueOfNonsoldArticles()
{
    Console.WriteLine("TODO\n");
}

void TotalNumberOfArticles()
{
    Console.WriteLine("TODO\n");
}

void PrintReceipt()
{
    Console.WriteLine("TODO\n");
}

void AddReceipt()
{
    Console.WriteLine("TODO\n");
}

void PrintWorkers()
{
    Console.WriteLine("TODO\n");
}

void EditWorkers()
{
    Console.WriteLine("TODO\n");
}

void DeleteWorkers()
{
    Console.WriteLine("TODO\n");
}

void AddWorkers()
{
    Console.WriteLine("TODO\n");
}

void PrintArticles()
{
    Console.WriteLine("TODO\n");
}

void EditArticles()
{
    Console.WriteLine("TODO\n");
}

void AddArticles()
{
    Console.WriteLine("TODO\n");
}

void DeleteArticles()
{
    Console.WriteLine("TODO\n");
}




public struct Artikl
{
    public string name;
    public int amount;
    public float price;
    public int numOfDaysTillExpiration;

}

public struct Radnik
{
    public string name;
    public string surname;
    public int age;
    public DateTime dateOfBirth;

}

public struct Racun
{
    public string ID;
    public DateTime dateAndTime;
    public float price;
    public Artikl[] articles;  
}

enum ProgramState
{
    CONTINUE,
    TERMINATE
};

