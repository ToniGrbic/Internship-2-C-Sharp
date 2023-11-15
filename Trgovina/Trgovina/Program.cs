// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

int selectionMain;
int selectionArticles;
int selectionWorkers;
int selectionReceipts;
int selectionStatistics;
int stateMainMenu = (int)Loop.CONTINUE;

Dictionary<string, Article> articles = new (){

    {"mlijeko", new Article(20, 1.50f, 0)},
    {"kruh",    new Article(34, 2.50f, 10)},
    {"jogurt",  new Article(30, 1.99f, 0)},
    {"sir",     new Article(24, 1.79f, 30)}
};

Dictionary<string, DateTime> workers = new(){

    {"Ante Antic", new DateTime(2000, 08, 12)},
    {"Mate Matic", new DateTime(2001, 12, 20)},
    {"Sime Simic", new DateTime(1998, 11, 15)},
    {"Ivan Ivic",  new DateTime(1999, 10, 30)}
};



// ********************* GLAVNI IZBORNIK ************************
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
            stateMainMenu = (int)Loop.TERMINATE;
            break;
        case 1:
            ArticlesMenu(articles);
            break;
        case 2:
            WorkersMenu(workers);
            break;
        case 3:
            ReceiptsMenu();
            break;
        case 4:
            StatisticsMenu();
            break;
        default:
            Console.WriteLine("Pogrešan unos pokušaj ponovo ");
            ContinueAndClearConsole();
            break;
    }
    Console.Clear();

} while(stateMainMenu == (int)Loop.CONTINUE || selectionMain < 0 || selectionMain > 4);


// *********************** PODIZBORNIK ARTIKLI **************************
void ArticlesMenu(Dictionary<string, Article> articles)
{
    int stateArticles = (int)Loop.CONTINUE;

    do { 
        Console.WriteLine(
           "IZBORNIK - Artikli\n" +
           "1 - Unos artikla\n" +
           "2 - Brisanje artikla\n" +
           "3 - Uređivanje artikla\n" +
           "4 - Ispis\n" +
           "0 - NAZAD NA GLAVNI MENI\n\n"
        );
        Console.WriteLine("Unesi odabir: ");
        selectionArticles = InputNumberFormat();
        
        switch (selectionArticles)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                stateArticles = (int)Loop.TERMINATE;
                break;
            case 1:
                AddArticles(articles);
                break;
            case 2:
                DeleteArticles(articles);
                break;
            case 3:
                EditArticles(articles);
                break;
            case 4:
                PrintArticlesOptions(articles);
                break;
            default:
                Console.WriteLine("Pogrešan unos pokušaj ponovo ");
                ContinueAndClearConsole();
                break;
        }
        
    }while (stateArticles == (int)Loop.CONTINUE || selectionArticles < 0 || selectionArticles > 4);

}

// *********************** PODIZBORNIK RADNICI **************************
void WorkersMenu(Dictionary<string, DateTime> workers)
{
    int stateWorkersMenu = (int)Loop.CONTINUE;
    do
    {
        Console.WriteLine(
           "IZBORNIK - Radnici\n" +
           "1 - Unos radnika\n" +
           "2 - Brisanje radnika\n" +
           "3 - Uređivanje radnika\n" +
           "4 - Ispis\n" +
           "0 - NAZAD NA GLAVNI MENI\n\n"
        );
        Console.WriteLine("Unesi odabir: ");
        selectionWorkers = InputNumberFormat();
        
        switch (selectionWorkers)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                stateWorkersMenu = (int)Loop.TERMINATE;
                break;
            case 1:
                AddWorkers(workers);
                break;
            case 2:
                DeleteWorkers(workers);
                break;
            case 3:
                EditWorkers(workers);
                break;
            case 4:
                PrintWorkers(workers);
                break;
            default:
                Console.WriteLine("Pogrešan unos pokušaj ponovo ");
                ContinueAndClearConsole();
                break;
        }
        
    } while (stateWorkersMenu == (int)Loop.CONTINUE || selectionWorkers < 0 || selectionWorkers > 4);
}

// *********************** PODIZBORNIK RAČUNI **************************
void ReceiptsMenu()
{
    int stateReceiptsMenu = (int)Loop.CONTINUE;
    do{
        Console.WriteLine(
           "IZBORNIK - Računi\n" +
           "1 - Unos računa\n" +
           "2 - Ispis\n" +
           "0 - NAZAD NA GLAVNI MENI\n\n"
        );
        Console.WriteLine("Unesi odabir: ");
        selectionReceipts = InputNumberFormat();

        switch (selectionReceipts)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                stateReceiptsMenu = (int)Loop.TERMINATE;
                break;
            case 1:
                AddReceipt();
                break;
            case 2:
                PrintReceipt();
                break;
            default:
                Console.WriteLine("Pogrešan unos pokušaj ");
                ContinueAndClearConsole();
                break;
        }
        
    } while (stateReceiptsMenu == (int)Loop.CONTINUE || selectionReceipts < 0 || selectionReceipts > 2);
}

// *********************** PODIZBORNIK STATISTIKA **************************
void StatisticsMenu()
{
    int stateStatisticsMenu = (int)Loop.CONTINUE;
    do
    {
        Console.WriteLine(
           "IZBORNIK - Statistika\n" +
           "1 - Ukupan broj artikala\n" +
           "2 - Vrijednost neprodanih artikala\n" +
           "3 - Vrijednost prodanih artikala\n" +
           "4 - Stanje po mjesecima\n" +
           "0 - NAZAD NA GLAVNI MENI\n"
        );
        Console.WriteLine("Unesi odabir: ");
        selectionStatistics = int.Parse(Console.ReadLine());

        switch (selectionStatistics)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                stateStatisticsMenu = (int)Loop.TERMINATE;
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
                Console.WriteLine("Pogrešan unos pokušaj ponovo");
                ContinueAndClearConsole();
                break;
        }
        
    } while (stateStatisticsMenu == (int)Loop.CONTINUE || selectionStatistics < 0 || selectionStatistics > 4);
}


// ************************** FUNKCIJE ZA ARTIKLE *********************************
void PrintArticlesOptions(Dictionary<string, Article> articles)
{
    int statePrintOptions;
    string option;
    IEnumerable<KeyValuePair<string, Article>> sortedArticlesList = null;
    Dictionary<string, Article> sortedArticles;

    do{
        statePrintOptions = (int)Loop.TERMINATE;

        Console.WriteLine(
            "OPCIJE - ISPIS ARTIKALA\n" +
            "a - sortirano po imenu\r\n" +
            "b - sortirano po datumu silazno\n" +
            "c - sortirano po datumu uzlazno\n" +
            "d - sortirano po količini\n" +
            "e - Najprodavaniji artikl\n" +
            "f - Najmanje prodavan artikl\n" +
            "exit - POVRATAK NA IZBORNIK ARTIKLI\n"
        );

        Console.WriteLine("Unesi jednu od ponuđenih opcija: ");
        option = Console.ReadLine()?.ToLower();

        switch (option)
        {
            case "a":
                sortedArticlesList = 
                    articles.OrderBy(pair => pair.Key);
                break;
            case "b":
                sortedArticlesList = 
                    articles.OrderByDescending(pair => pair.Value.numOfDaysTillExp);
                break;
            case "c":
                sortedArticlesList =
                    articles.OrderBy(pair => pair.Value.numOfDaysTillExp);
                break;
            case "d":
                sortedArticlesList =
                    articles.OrderByDescending(pair => pair.Value.amount);
                break;
            case "e":
                var mostSoldArticle = 
                    articles.OrderByDescending(pair => pair.Value.numOfDaysTillExp).First();

                Console.WriteLine("NAJVIŠE PRODAVANI ARTIKL:\n");
                PrintSingleArticle(mostSoldArticle);
                break;
            case "f":
                var leastSoldArticle =
                    articles.OrderBy(pair => pair.Value.numOfDaysTillExp).First();

                Console.WriteLine("NAJMANJE PRODAVANI ARTIKL:\n");
                PrintSingleArticle(leastSoldArticle);
                break;
            case "exit":
                statePrintOptions = (int)Loop.TERMINATE;
                Console.Clear();
                continue;
            default:
                Console.WriteLine("Pogrešan unos, pokušaj ponovo...");
                statePrintOptions = (int)Loop.CONTINUE;
                break;
        }

        if(option != "e" && option != "f" && statePrintOptions != (int)Loop.CONTINUE){
            sortedArticles = sortedArticlesList.ToDictionary(pair => pair.Key, pair => pair.Value);
            Console.WriteLine($"ARTIKLI SORTIRANI PREMA OPCIJI {option} :\n");
            PrintArticles(sortedArticles);
        }

        Console.WriteLine("Nastavi na opcije ispisa? (da - Za potvrdu, ne - Povratak na izbornik Artikli)\n");
        statePrintOptions = ConfirmationDialog();
        Console.Clear();

    } while (statePrintOptions == (int)Loop.CONTINUE);
}  


void EditArticles(Dictionary<string, Article> articles)
{ 
    int stateEditArticles;
    string option;
    string articleName;
    int newAmount;
    float newPrice;
    int newDaysTillExpiration;
    do
    {
        stateEditArticles = (int)Loop.TERMINATE;
        Console.WriteLine(
            "OPCIJE - UREĐIVANJA ARTIKALA\n" +
            "a - Jednog artikla\n" +
            "b - Dodavanje popusta/poskupljenje na sve proizvode\n" +
            "exit - POVRATAK NA IZBORNIK ARTIKLI\n"
        );
        Console.WriteLine("Unesi jednu od ponuđenih opcija: ");
        option = Console.ReadLine()?.ToLower();
        switch (option)
        {
            case "a":
                do{
                    stateEditArticles = (int)Loop.TERMINATE;
                    Console.WriteLine("Unesi ime artikla kojeg želiš urediti: ");
                    articleName = InputNonEmptyString();
                    if (!articles.ContainsKey(articleName)){
                        Console.WriteLine($"Artikl {articleName} ne postoji u bazi, pokušaj ponovno...\n");
                        stateEditArticles = (int)Loop.CONTINUE;
                        continue;
                    }
                    var articleToEdit = articles[articleName];
                    PrintSingleArticle(new(articleName, articleToEdit));
                   
                    Console.WriteLine("Uredi količinu? (da/ne): ");
                    if (ConfirmationDialog() == 0){
                        Console.WriteLine("Unesi novo ime\n");
                        newAmount = InputNumberFormat();
                        articleToEdit.amount = newAmount;
                    }
                    Console.WriteLine("Uredi cijenu? (da/ne): ");
                    if (ConfirmationDialog() == 0){
                        Console.WriteLine("Unesi novu cijenu (EUR)\n");
                        newPrice = InputFloatFormat();
                        articleToEdit.price = newPrice;
                    }
                    Console.WriteLine("Uredi rok trajanja (dani)? (da/ne): ");
                    if (ConfirmationDialog() == 0){
                        Console.WriteLine("Unesi novi rok trajanja (dani)\n");
                        newDaysTillExpiration = InputNumberFormat();
                        articleToEdit.numOfDaysTillExp = newDaysTillExpiration;
                    }
                    articles[articleName] = articleToEdit;
                    Console.WriteLine($"Artikl {articleName} uspiješno uređen\n");
                    PrintSingleArticle(new(articleName, articles[articleName]));
                    ContinueAndClearConsole();
                } while (stateEditArticles == (int)Loop.CONTINUE);
                break;
            case "b":
                //TODO
                break;
            case "exit":
                stateEditArticles = (int)Loop.TERMINATE;
                Console.Clear();
                continue;
            default:
                Console.WriteLine("Pogrešan unos, pokušaj ponovo...");
                stateEditArticles = (int)Loop.CONTINUE;
                break;
        }
        

    } while (stateEditArticles == (int)Loop.CONTINUE);
}

void AddArticles(Dictionary<string, Article> articles)
{
    int stateAddArticles;
    Article article;
    string name;
    int amount = 0;
    float price = 0;
    int daysTillExpiration = 0;
    
    do{
        Console.WriteLine("Unesi podatke za novi artikl:\n");

        Console.WriteLine("Ime: ");
        name = InputNonEmptyString();

        Console.WriteLine("Količina (format - cijeli broj): ");
        amount = InputNumberFormat();

        Console.WriteLine("Cijena (format - decimalni broj ex. 2.99): ");
        price = InputFloatFormat();

        Console.WriteLine("Rok Trajanja u danima (format - cijeli broj):");
        daysTillExpiration = InputNumberFormat();

        article = new Article(amount, price, daysTillExpiration);
        PrintSingleArticle(new(name,article));
        Console.WriteLine("POTVRDI UNOS ARTIKLA (da - ZA POTVRDU, ne - PONOVNI UNOS):");
        stateAddArticles = ConfirmationDialogForDataChange();

        if (stateAddArticles == (int)Loop.CONTINUE){
            Console.Clear();
            continue;
        }

        articles.Add(name, article);
        Console.WriteLine($"Artikl {name} je uspješno dodan!\n\n");
       
        Console.WriteLine(
            "Nastavi sa novim unosom artikla?\n" +
            "(da - ZA NASTAVAK, ne - POVRATAK NA IZBORNIK ARTILKI): \n"
        );
        stateAddArticles = ConfirmationDialog();
        Console.Clear();
    }while(stateAddArticles ==  (int)Loop.CONTINUE);
}

void DeleteArticles(Dictionary<string, Article> articles)
{
    int stateDeleteArticles;
    string? option;

    do{
        Console.WriteLine(
            "OPCIJE - BRISANJE ARTIKALA\n" +
            "a - po imenu\r\n" +
            "b - kojima je istekao rok trajanja\n" +
            "exit - POVRATAK NA IZBORNIK ARTIKLI"

        );
        stateDeleteArticles = (int)Loop.TERMINATE;
        Console.WriteLine("Unesi jednu od ponuđenih opcija: ");

        option = Console.ReadLine();
        switch (option)
        {
            case "a":
                string articleName;
                do{
                    stateDeleteArticles = (int)Loop.TERMINATE;
                    Console.WriteLine("Upiši ime artika koje želiš izbrisat: \n");
                    articleName = InputNonEmptyString();
                  
                    if (!articles.ContainsKey(articleName)){
                        Console.WriteLine("Taj artilk ne postoji u bazi, pokušaj ponovo...\n");
                        stateDeleteArticles = (int)Loop.CONTINUE;
                        continue;
                    }
                    Console.WriteLine($"Potvrdi brisanje artikla {articleName} :\n (da - za nastavak, ne - novi unos)");
                    stateDeleteArticles = ConfirmationDialogForDataChange();

                    if(stateDeleteArticles == (int)Loop.TERMINATE){
                        articles.Remove(articleName);
                        Console.WriteLine($"izbrisan artikl {articleName} - {articleName}\n");
                    }
                    
                } while (stateDeleteArticles == (int)Loop.CONTINUE);  
                break;
            case "b":
                Console.WriteLine(
                    "Potvrdi brisanje artikala kojma je istekao rok\n " +
                    "(da - za nastavak, ne - novi unos\n"
                );
                stateDeleteArticles = ConfirmationDialogForDataChange();
                if(stateDeleteArticles == (int)Loop.CONTINUE){
                    Console.Clear();
                    continue;
                }

                foreach (var item in articles)
                {
                    if(item.Value.numOfDaysTillExp <= 0) { 
                         articles.Remove(item.Key);
                         Console.WriteLine($"izbrisan artikl {item.Key}");
                    }
                }
                Console.WriteLine("Izbrisani svi artikli kojima je istekao rok trajanja\n");
                break;
            case "exit":
                stateDeleteArticles = (int)Loop.TERMINATE;
                Console.Clear();
                continue;
            default:
                Console.WriteLine("Pogrešan unos, pokušaj ponovo...");
                stateDeleteArticles = (int)Loop.CONTINUE;
                break;

        }
        Console.WriteLine("nastavi dalje sa brisanjem artikla?\n" +
            "(da - NASTAVAK ne - povratak na izbornik Artikli)\n"
        );
        stateDeleteArticles = ConfirmationDialog();
        Console.Clear();
    } while (stateDeleteArticles == (int)Loop.CONTINUE);
}

// *********************** FUNKCIJE ZA RADNIKE *********************************
void PrintWorkers(Dictionary<string, DateTime> workers)
{
    int statePrintOptions;
    string option;
    IEnumerable<KeyValuePair<string, DateTime>> sortedArticlesList = null;

    do
    {
        statePrintOptions = (int)Loop.TERMINATE;

        Console.WriteLine(
            "OPCIJE - ISPIS RADNIKA\n" +
            "a - svih radnika\r\n" +
            "b - čiji je rođendan u tekućem mjesecu\n" +
            "exit - POVRATAK NA IZBORNIK ARTIKLI\n"
        );

        Console.WriteLine("Unesi jednu od ponuđenih opcija: ");
        option = Console.ReadLine()?.ToLower();

        switch (option)
        {
            case "a":
                Console.WriteLine("ISPIS SVIH RADNIKA:\n");
                PrintAllWorkers(workers);
                break;
            case "b":
                int currentMonth = DateTime.Now.Month;
                Console.WriteLine($"ISPIS SVIH RADNIKA SA ROĐENDANOM U TEKUĆEM MJESECU ({currentMonth}. mjesec):\n");
                PrintWorkersWithBirthdayInCurrentMonth(workers);
                break;
            case "exit":
                statePrintOptions = (int)Loop.TERMINATE;
                Console.Clear();
                continue;
            default:
                Console.WriteLine("Pogrešan unos, pokušaj ponovo...");
                statePrintOptions = (int)Loop.CONTINUE;
                break;
        }

        Console.WriteLine(
            "Nastavi na opcije ispisa? " +
            "(da - Za potvrdu, ne - Povratak na izbornik Radnici)\n"
        );
        statePrintOptions = ConfirmationDialog();
        Console.Clear();

    } while (statePrintOptions == (int)Loop.CONTINUE);
}
void AddWorkers(Dictionary<string, DateTime> workers)
{
    int stateAddWorkers;
    string nameAndSurname;
    DateTime dateOfBirth;
    do{
      
        Console.WriteLine("Unesi podatke za novog radnika:\n");

        Console.WriteLine("Ime i prezime: (format: Ime Prezime)");
        nameAndSurname = InputNonEmptyString();


        Console.WriteLine("Datum rođenja:\n");
        dateOfBirth = InputDateFormat();

        
        PrintSingleWorker(new(nameAndSurname, dateOfBirth));
        Console.WriteLine("POTVRDI UNOS RADNIKA (da - ZA POTVRDU, ne - PONOVNI UNOS):");
        stateAddWorkers = ConfirmationDialogForDataChange();

        if (stateAddWorkers == (int)Loop.CONTINUE){
            Console.Clear();
            continue;
        }

        workers.Add(nameAndSurname, dateOfBirth);
        Console.WriteLine($"Radnik {nameAndSurname} je uspješno dodan!\n");

        Console.WriteLine(
            "Nastavi sa novim unosom Radnika?\n" +
            "(da - ZA NASTAVAK, ne - POVRATAK NA IZBORNIK RADNICI): \n"
        );
        stateAddWorkers = ConfirmationDialog();
        Console.Clear();
    } while (stateAddWorkers == (int)Loop.CONTINUE);
}



void EditWorkers(Dictionary<string, DateTime> workers)
{
    Console.WriteLine("TODO\n");
}

void DeleteWorkers(Dictionary<string, DateTime> workers)
{
    int stateDeleteWorkers;
    string? option;

    do
    {
        Console.WriteLine(
            "OPCIJE - BRISANJE RADNIKA\n" +
            "a - po imenu\r\n" +
            "b - svih koji imaju više od 65 godina\n" +
            "exit - POVRATAK NA IZBORNIK RADNICI\n"
        );
        stateDeleteWorkers = (int)Loop.TERMINATE;
        Console.WriteLine("Unesi jednu od ponuđenih opcija: ");

        option = Console.ReadLine()?.ToLower();
        switch (option)
        {
            case "a":
                string workerName;
                do
                {
                    stateDeleteWorkers = (int)Loop.TERMINATE;
                    Console.WriteLine(
                        "Upiši ime i prezime radnika kojeg želiš izbrisat \n" +
                        "(format: Ime Prezime): "
                    );
                    workerName = InputNonEmptyString();

                    if (!workers.ContainsKey(workerName))
                    {
                        Console.WriteLine("Taj radnik ne postoji u bazi, pokušaj ponovo...\n");
                        stateDeleteWorkers = (int)Loop.CONTINUE;
                        continue;
                    }
                    Console.WriteLine($"Potvrdi brisanje radnika {workerName} (da - za nastavak, ne - novi unos):");
                    stateDeleteWorkers = ConfirmationDialogForDataChange();

                    if (stateDeleteWorkers == (int)Loop.CONTINUE)
                        continue;

                    workers.Remove(workerName);
                    Console.WriteLine($"IZBRISAN RADNIK {workerName}\n");
       
                } while (stateDeleteWorkers == (int)Loop.CONTINUE);
                break;
            case "b":
                Console.WriteLine(
                    "Potvrdi brisanje radnika preko 65 godina\n " +
                    "(da - za nastavak, ne - novi unos): "
                );
                stateDeleteWorkers = ConfirmationDialogForDataChange();
                if (stateDeleteWorkers == (int)Loop.CONTINUE){
                    Console.Clear();
                    continue;
                }

                foreach (var worker in workers)
                {

                    if (AgeOfWorker(worker.Value) > 65)
                    {
                        workers.Remove(worker.Key);
                        Console.WriteLine($"izbrisan radnik {worker.Key}\n");
                    }
                }
                Console.WriteLine("Izbrisani svi radnici preko 65 godina\n");
                break;
            case "exit":
                stateDeleteWorkers = (int)Loop.TERMINATE;
                Console.Clear();
                continue;
            default:
                Console.WriteLine("Pogrešan unos, pokušaj ponovo...");
                stateDeleteWorkers = (int)Loop.CONTINUE;
                break;
        }
        Console.WriteLine(
            "nastavi dalje sa brisanjem artikla?\n" +
            "(da - NASTAVAK ne - povratak na izbornik Radnici"
        );
        stateDeleteWorkers = ConfirmationDialog();
        Console.Clear();
        
    } while (stateDeleteWorkers == (int)Loop.CONTINUE);
        
   
}
// *********************** FUNKCIJE ZA RAČUNE *********************************
void PrintReceipt()
{
    Console.WriteLine("TODO\n");
}

void AddReceipt()
{
    Console.WriteLine("TODO\n");
}

// *********************** FUNKCIJE ZA STATISTIKU *******************************
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

// *********************** HELPER FUNKCIJE *************************
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
    do{
        success = float.TryParse(Console.ReadLine(), out number);
        if (!success)
            Console.WriteLine("Neispravni format za decinalni broj, pokušaj ponovo...");
    } while (!success);
    return number;
}

string InputNonEmptyString()
{
    string input;
    bool success;
    do{
        input = Console.ReadLine();
        success = !string.IsNullOrEmpty(input);
        if (!success)
            Console.WriteLine("string ne smije biti prazan, pokušajte ponovo...");
    } while (!success);
    return input;
}
DateTime InputDateFormat()
{
    int year, month, day;
 
    Console.WriteLine("\tGodina: ");
    year = InputNumberFormat();
    Console.WriteLine("\tMjesec: ");
    month = InputNumberFormat();
    Console.WriteLine("\tDan: ");
    day = InputNumberFormat();

    DateTime date = new DateTime(year, month, day);
    return date;
}

int AgeOfWorker(DateTime start)
{
    DateTime end = DateTime.Now;
    return (end.Year - start.Year - 1) +
        (((end.Month > start.Month) ||
        ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
}
void PrintArticles(Dictionary<string, Article> articles)
{
    foreach (var article in articles)
    {
        PrintSingleArticle(article);
    }
}

void PrintSingleArticle(KeyValuePair<string, Article> article)
{
    var (key, value) = article;
    Console.WriteLine(
        $"ARTICLE {key} : \n" +
        $"amount: {value.amount}\n" +
        $"price: {value.price}\n" +
        $"days till expiration: {value.numOfDaysTillExp}\n\n"
    );
}

void PrintAllWorkers(Dictionary<string, DateTime> workers)
{
    foreach (var worker in workers)
    {
        PrintSingleWorker(worker);
    }
}

void PrintWorkersWithBirthdayInCurrentMonth(Dictionary<string, DateTime> workers)
{
    int currentMonth = DateTime.Now.Month;
    foreach (var worker in workers)
    {
        if (worker.Value.Month == currentMonth)
        {
            PrintSingleWorker(worker);
        }
        
    }
}

void PrintSingleWorker(KeyValuePair<string, DateTime> worker)
{
    var (name, dateOfBirth) = worker;
    Console.WriteLine(
        $"WORKER {name} : \n" +
        $"Date of Birth: {dateOfBirth}\n"
    );
}

int ConfirmationDialog()
{
    int state;
    var option = InputNonEmptyString();

    if (option.ToLower() == "da"){
        state = (int)Loop.CONTINUE;
    }
    else{
        state = (int)Loop.TERMINATE;
    }
    return state;
}

int ConfirmationDialogForDataChange()
{
    int state;
    var option = InputNonEmptyString();

    if (option.ToLower() == "da")
    {
        state = (int)Loop.TERMINATE;
    }
    else
    {
        state = (int)Loop.CONTINUE;
    }
    return state;
}


public struct Article
{
    public int amount;
    public float price;
    public int numOfDaysTillExp;
    public Article(int amout, float price, int numOfDaysTillExp) : this()
    {
        this.amount = amout;
        this.price = price;
        this.numOfDaysTillExp = numOfDaysTillExp;
    }
}
public struct Racun
{
    public DateTime dateAndTime;
    public float price;  
}

enum Loop
{
    CONTINUE,
    TERMINATE
};

