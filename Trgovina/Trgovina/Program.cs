// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

int stateMainMenu = (int)ProgramState.CONTINUE;
int selectionMain;
int selectionArticles;
int selectionWorkers;
int selectionReceipts;
int selectionStatistics;

Dictionary<int, Article> articles = new (){

    {1, new Article("mlijeko", 20, 1.50f, 0) },
    {2, new Article("kruh", 34, 2.50f, 10) },
    {3, new Article("jogurt", 30, 1.99f, 0) },
    {4, new Article("sir", 24, 1.79f, 30) }
};

do{
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
            stateMainMenu = (int)ProgramState.TERMINATE;
            break;
        case 1:
            ArticlesMenu(articles);
            break;
        case 2:
            WorkersMenu();
            break;
        case 3:
            ReceiptsMenu();
            break;
        case 4:
            StatisticsMenu();
            break;
        default:
            Console.WriteLine("Pogrešan unos pokušaj ponovo, pritisni neku tipku za nastavak...");
            char c = Console.ReadKey().KeyChar;
            break;
    }
    Console.Clear();

} while(stateMainMenu == (int)ProgramState.CONTINUE || selectionMain < 0 || selectionMain > 4);


void ArticlesMenu(Dictionary<int, Article> articles)
{
    int stateArticles = (int)ProgramState.CONTINUE;

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
                stateArticles = (int)ProgramState.TERMINATE;
                break;
            case 1:
                AddArticles(articles);
                break;
            case 2:
                DeleteArticles(articles);
                break;
            case 3:
                EditArticles();
                break;
            case 4:
                PrintArticlesOptions(articles);
                break;
            default:
                Console.WriteLine("Pogrešan unos pokušaj ponovo, pritisni neku tipku za nastavak...");
                char c = Console.ReadKey().KeyChar;
                break;
        }
        
    }while (stateArticles == (int)ProgramState.CONTINUE || selectionArticles < 0 || selectionArticles > 4);

}
void WorkersMenu()
{
    int stateWorkersMenu = (int)ProgramState.CONTINUE;
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
                stateWorkersMenu = (int)ProgramState.TERMINATE;
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
                Console.WriteLine("Pogrešan unos pokušaj ponovo, pritisni neku tipku za nastavak...");
                char c = Console.ReadKey().KeyChar;
                break;
        }
        
    } while (stateWorkersMenu == (int)ProgramState.CONTINUE || selectionWorkers < 0 || selectionWorkers > 4);
}
void ReceiptsMenu()
{
    int stateReceiptsMenu = (int)ProgramState.CONTINUE;
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
                stateReceiptsMenu = (int)ProgramState.TERMINATE;
                break;
            case 1:
                AddReceipt();
                break;
            case 2:
                PrintReceipt();
                break;
            default:
                Console.WriteLine("Pogrešan unos pokušaj ponovo, pritisni neku tipku za nastavak...");
                char c = Console.ReadKey().KeyChar;
                break;
        }
        
    } while (stateReceiptsMenu == (int)ProgramState.CONTINUE || selectionReceipts < 0 || selectionReceipts > 2);
}
void StatisticsMenu()
{
    int stateStatisticsMenu = (int)ProgramState.CONTINUE;
    do
    {
        Console.WriteLine(
           "IZBORNIK - Statistika\n" +
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
                stateStatisticsMenu = (int)ProgramState.TERMINATE;
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
                Console.WriteLine("Pogrešan unos pokušaj ponovo, pritisni neku tipku za nastavak...");
                char chr = Console.ReadKey().KeyChar;
                break;
        }
        
    } while (stateStatisticsMenu == (int)ProgramState.CONTINUE || selectionStatistics < 0 || selectionStatistics > 4);
}
void PrintArticlesOptions(Dictionary<int, Article> articles)
{
    int statePrintSubmenu;
    string option;
    Console.WriteLine(
        "OPCIJE - ISPIS ARTIKALA\n" +
        "a - sortirano po imenu\r\n" +
        "b - sortirano po datumu silazno\n" +
        "c - sortirano po datumu uzlazno\n" +
        "d - sortirano po količini\n" +
        "e - Najprodavaniji artikl\r\n" +
        "f - Najmanje prodavan artikl\r\n"
    );

    do{
        statePrintSubmenu = (int)ProgramState.TERMINATE;

        Console.WriteLine("Unesi jednu od ponuđenih opcija");
        option = Console.ReadLine();

        switch (option)
        {
            case "a":
                PrintArticles(articles);
                break;
            case "b":
                Console.WriteLine("Todo");
                break;
            case "c":
                Console.WriteLine("Todo");
                break;
            case "d":
                Console.WriteLine("Todo");
                break;
            case "e":
                Console.WriteLine("Todo");
                break;
            case "f":
                Console.WriteLine("Todo");
                break;
            default:
                Console.WriteLine("Pogrešan unos, pokušaj ponovo...");
                statePrintSubmenu = (int)ProgramState.CONTINUE;
                break;
        }
        ContinueAndClearConsole();

    } while (statePrintSubmenu == (int)ProgramState.CONTINUE);
}  


void EditArticles()
{
    Console.WriteLine("TODO\n");
}

void AddArticles(Dictionary<int, Article> articles)
{
    int stateAddArticles;
    string option;
    
    Article article;
    int key;
    string? name;
    int amount = 0;
    float price = 0;
    int daysTillExpiration = 0;
    
    do{
        Console.WriteLine("Unesi podatke za novi artikl:\n");

        Console.WriteLine("Ime: ");
        name = InputNonEmptyString();

        Console.WriteLine("Količina (format - cijeli broj): ");
        amount = InputNumberFormat();

        Console.WriteLine("Cijena (format - decimalni broj ex. 20.0): ");
        price = InputFloatFormat();

        Console.WriteLine("Rok Trajanja u danima (format - cijeli broj):");
        daysTillExpiration = InputNumberFormat();

        article = new Article(name, amount, price, daysTillExpiration);
        key = articles.Keys.Last() + 1;
        articles.Add(key, article);
        Console.WriteLine($"Artikl {article.name} je uspješno dodan!\n\n");
       
        Console.WriteLine("Nastavi sa novim unosom artikla? (Za nastavak unesi - DA )\n");
        option = InputNonEmptyString();
        if(option.ToLower() == "da"){
            stateAddArticles = (int)ProgramState.CONTINUE;
        }else{
            stateAddArticles = (int)ProgramState.TERMINATE;
        }
        Console.Clear();
    }while(stateAddArticles ==  (int)ProgramState.CONTINUE);

}

void DeleteArticles(Dictionary<int, Article> articles)
{
    int stateDeleteArticles;
    string? option;

    do{
        stateDeleteArticles = (int)ProgramState.TERMINATE;
        Console.WriteLine("Unesi jednu od ponuđenih opcija");
        option = Console.ReadLine();
        switch (option)
        {
            case "a":
                string? articleName;
                Console.WriteLine("Upiši ime artika koje želiš izbrisat: \n");
                articleName = Console.ReadLine();

                var itemToDel = articles.First(
                    kvp => kvp.Value.name == articleName
                );
                articles.Remove(itemToDel.Key);
                Console.WriteLine($"izbrisan artikl {itemToDel.Key} - {articleName}\n");
                break;
            case "b":
                foreach (var item in articles.Where(kvp => kvp.Value.numOfDaysTillExp <= 0))
                {
                    articles.Remove(item.Key);
                    Console.WriteLine($"izbrisan artikl {item.Key}");
                }
                Console.WriteLine("Izbrisani svi artikli kojima je istekao rok trajanja\n");
                break;
            default:
                Console.WriteLine("Pogrešan unos, pokušaj ponovo...");
                stateDeleteArticles = (int)ProgramState.CONTINUE;
                break;

        }
    } while (stateDeleteArticles == (int)ProgramState.CONTINUE);
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

// ************* HELPER FUNCTIONS *****************
void ContinueAndClearConsole()
{
    Console.WriteLine("pritisni neku tipku za nastavak...");
    char chr = Console.ReadKey().KeyChar;
    Console.Clear();
}

int InputNumberFormat()
{
    int number = 0;
    bool success;
    do{
        success = int.TryParse(Console.ReadLine(), out number);
        if (!success)
            Console.WriteLine("Neispravni format za cjeli broj, pokušaj ponovo...");
    } while (!success);
    return number;
}

float InputFloatFormat()
{
    float number = 0.0f;
    bool success;
    do
    {
        success = float.TryParse(Console.ReadLine(), out number);
        if (!success)
            Console.WriteLine("Neispravni format za decinalni broj, pokušaj ponovo...");
    } while (!success);
    return number;
}

string InputNonEmptyString()
{
    string? input;
    bool success;
    do
    {
        input = Console.ReadLine();
        success = !string.IsNullOrEmpty(input);
        if (!success)
            Console.WriteLine("string ne smije biti prazan, pokušajte ponovo...");
    } while (!success);
    return input;
}
void PrintArticles(Dictionary<int, Article> articles)
{
    foreach (var (key, value) in articles)
    {
        Console.WriteLine($"ARTICLE {key}. : \n" +
            $"name: {value.name}\n" +
            $"amount: {value.amount}\n" +
            $"price: {value.price}\n" +
            $"days till expiration: {value.numOfDaysTillExp}\n\n"
        );
    }
}

public struct Article
{
    public string name;
    public int amount;
    public float price;
    public int numOfDaysTillExp;
    public Article(string name, int amout, float price, int numOfDaysTillExp) : this()
    {
        this.name = name;
        this.amount = amout;
        this.price = price;
        this.numOfDaysTillExp = numOfDaysTillExp;
    }
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
    public DateTime dateAndTime;
    public float price;
    public Article[] articles;  
}

enum ProgramState
{
    CONTINUE,
    TERMINATE
};

