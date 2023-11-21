// See https://aka.ms/new-console-template for more information
using System;

int selectionMain;
int stateMainMenu = (int)Loop.CONTINUE;

Dictionary<string, Article> articles = new (){

    {"mlijeko", new Article(20, 1.50f, 12, 10)},
    {"kruh",    new Article(5,  2.50f, 10, 20)},
    {"jogurt",  new Article(30, 1.99f, 0,  30)},
    {"sir",     new Article(24, 2.99f, 30, 15)}
};

Dictionary<string, DateTime> workers = new(){

    {"Ante Antic", new DateTime(2000, 08, 12)},
    {"Mate Matic", new DateTime(2001, 12, 20)},
    {"Sime Simic", new DateTime(1956, 11, 15)},
    {"Ivan Ivic",  new DateTime(1999, 10, 30)}
};

Dictionary<int, (DateTime dateTime, float totalPrice, Dictionary<string,(int amount,float price)> articles)> receipts =
new()
{
    {1, (dateTime: new DateTime(2023,10,31,12,5,0), 
         totalPrice: 7.5f, 
         articles: new (){ 
             { "mlijeko", (amount:3, price:1.5f) }, 
             { "sir", (amount:1, price:2.99f)} 
         })
    },
    {2, (dateTime: new DateTime(2023,11,10,16,25,0), 
         totalPrice: 9.0f, 
         articles: new (){ 
             { "kruh", (amount: 2, price: 2.50f) }, 
             { "jogurt", (amount: 2, price: 1.99f) } 
         }) 
    },
};

// ***************************** GLAVNI IZBORNIK ***************************
// *************************************************************************
do{
    Console.WriteLine(
        "GLAVNI IZBORNIK:\n" +
        "1 - Artikli\n" +
        "2 - Radnici\n" +
        "3 - Računi\n" +
        "4 - Statistika\n" +
        "0 - Izlaz\n\n"
    );
    Console.WriteLine("Unesi odabir: ");
    selectionMain = InputNumberFormat();
    Console.Clear();
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
            ReceiptsMenu(receipts);
            break;
        case 4:
            StatisticsMenu();
            break;
        default:
            Console.WriteLine("Greška, Pogrešan unos, pokusaj ponovo ");
            ContinueAndClearConsole();
            break;
    }
    Console.Clear();

} while(stateMainMenu == (int)Loop.CONTINUE || selectionMain < 0 || selectionMain > 4);


// ***************************** ARTIKLI ********************************
// **********************************************************************
void ArticlesMenu(Dictionary<string, Article> articles)
{
    int selectionArticles;
    int stateArticles = (int)Loop.CONTINUE;
    
    do
    { 
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
        Console.Clear();
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
// **********************************************************************
void WorkersMenu(Dictionary<string, DateTime> workers)
{
    int selectionWorkers;
    int stateWorkersMenu = (int)Loop.CONTINUE;
    do{
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
        Console.Clear();
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
// *********************************************************************
void ReceiptsMenu(Dictionary<int, (DateTime, float, Dictionary<string, (int,float)> articles)> receipts)
{
    int selectionReceipts;
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
        Console.Clear();
        switch (selectionReceipts)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                stateReceiptsMenu = (int)Loop.TERMINATE;
                break;
            case 1:
                AddReceipt(receipts);
                break;
            case 2:
                PrintReceipts(receipts);
                break;
            default:
                Console.WriteLine("Pogrešan unos pokušaj ");
                ContinueAndClearConsole();
                break;
        }
        
    } while (stateReceiptsMenu == (int)Loop.CONTINUE || selectionReceipts < 0 || selectionReceipts > 2);
}

// *********************** PODIZBORNIK STATISTIKA **************************
// *************************************************************************
void StatisticsMenu()
{
    int selectionStatistics;
    int stateStatisticsMenu = (int)Loop.CONTINUE;
    
    Console.WriteLine("Unesi sifru za pristup: ");
    string inputedPass = InputNonEmptyString();

    if (!CheckPassword(inputedPass)){
        Console.WriteLine("Neispravna lozinka, pristup odbijen!\n");
        ContinueAndClearConsole();
        return;
    }
    Console.Clear();
    Console.WriteLine("USPJEŠNA PRIJAVA!\n");

    do{
        Console.WriteLine(
           "IZBORNIK - Statistika\n" +
           "1 - Ukupan broj artikala\n" +
           "2 - Vrijednost neprodanih artikala\n" +
           "3 - Vrijednost prodanih artikala\n" +
           "4 - Stanje po mjesecima\n" +
           "0 - NAZAD NA GLAVNI MENI\n\n"
        );
        Console.WriteLine("Unesi odabir: ");
        selectionStatistics = InputNumberFormat();

        switch (selectionStatistics)
        {
            case 0:
                Console.WriteLine("Izlaz...");
                stateStatisticsMenu = (int)Loop.TERMINATE;
                break;
            case 1:
                TotalNumberOfArticles(articles);
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

bool CheckPassword(string inputedPass)
{
    string passwordDefault = "Stats123";
    return inputedPass == passwordDefault;
}


// ***************************** FUNKCIJE ZA ARTIKLE ******************************
// ********************************************************************************
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
            "exit - POVRATAK NA IZBORNIK ARTIKLI\n\n"
        );

        Console.WriteLine("Unesi jednu od ponuđenih opcija: ");
        option = Console.ReadLine()?.ToLower();
        Console.Clear();

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
                    articles.OrderByDescending(pair => pair.Value.soldAmount).First();

                Console.WriteLine("NAJVIŠE PRODAVANI ARTIKL:\n");
                PrintSingleArticle(mostSoldArticle);
                break;
            case "f":
                var leastSoldArticle =
                    articles.OrderBy(pair => pair.Value.soldAmount).First();

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

        if(option != "e" && option != "f" && statePrintOptions != (int)Loop.CONTINUE)
        {
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

    do{
        stateEditArticles = (int)Loop.TERMINATE;
        Console.WriteLine(
            "OPCIJE - UREĐIVANJA ARTIKALA\n" +
            "a - Jednog artikla\n" +
            "b - Dodavanje popusta/poskupljenje na sve proizvode\n" +
            "exit - POVRATAK NA IZBORNIK ARTIKLI\n\n"
        );
        Console.WriteLine("Unesi jednu od ponuđenih opcija: ");
        option = Console.ReadLine()?.ToLower();
        Console.Clear();
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
                int percentage;
                bool discount = true;
                Console.WriteLine(
                    "Unesi postotak (%) za poskupljenje/popust svih proizvoda\n" +
                    "(NPR. za poskupljenje: 15, a za popust: -15): "
                );
                percentage = InputNumberFormat();
                if (percentage > 0)
                    discount = false;
                Console.WriteLine($"Potvrdi {(discount ? "Popust": "Poskupljenje")} od {percentage}% ? (da/ne): ");
                stateEditArticles = ConfirmationDialogForDataChange();

                if(stateEditArticles == (int)Loop.CONTINUE){
                    Console.Clear();
                    continue;
                }

                float percentageDec = (float)percentage / 100;
                List<string> keys = new (articles.Keys);
                foreach(var key in keys)
                {
                    var article = articles[key];
                    article.price += percentageDec*article.price;
                    Console.WriteLine($"Nova cijena arikla {key} je {article.price}\n");
                    articles[key] = article;
                }
                PrintArticles(articles);
                Console.WriteLine("Uspiješno uređivanje cijena artikala\n");
                ContinueAndClearConsole();
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

        article = new Article(amount, price, daysTillExpiration, 0);
        PrintSingleArticle(new(name,article));
        Console.WriteLine("POTVRDI UNOS ARTIKLA (da - ZA POTVRDU, ne - PONOVNI UNOS):");
        stateAddArticles = ConfirmationDialogForDataChange();

        if (stateAddArticles != (int)Loop.CONTINUE){

            if (!articles.ContainsKey(name)){
                articles.Add(name, article);
                Console.WriteLine($"Artikl {name} je uspješno dodan!\n\n");
            }
            else {
                Console.WriteLine($"Greška: Artikl {name} vec postoji u bazi\n");
            }
        }

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
            "a - po imenu\n" +
            "b - kojima je istekao rok trajanja\n" +
            "exit - POVRATAK NA IZBORNIK ARTIKLI\n\n"
        );
        stateDeleteArticles = (int)Loop.TERMINATE;
        Console.WriteLine("Unesi jednu od ponuđenih opcija: ");
        option = Console.ReadLine()?.ToLower();
        Console.Clear();

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
                    PrintSingleArticle(new(articleName, articles[articleName]));
                    Console.WriteLine($"\nPotvrdi brisanje artikla {articleName} :\n (da - za nastavak, ne - novi unos)");
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
// *****************************************************************************
void PrintWorkers(Dictionary<string, DateTime> workers)
{
    int statePrintOptions;
    string option;

    do{
        statePrintOptions = (int)Loop.TERMINATE;

        Console.WriteLine(
            "OPCIJE - ISPIS RADNIKA\n" +
            "a - svih radnika\r\n" +
            "b - čiji je rođendan u tekućem mjesecu\n" +
            "exit - POVRATAK NA IZBORNIK ARTIKLI\n"
        );

        Console.WriteLine("Unesi jednu od ponuđenih opcija: ");
        option = Console.ReadLine().ToLower();

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
    bool success;

    do{
        Console.WriteLine("Unesi podatke za novog radnika:\n");
        Console.WriteLine("Ime i prezime: (format: Ime Prezime)");
        nameAndSurname = InputNonEmptyString();
        do{
            Console.WriteLine("Datum rođenja:\n");
            dateOfBirth = InputDateFormat();
            success = AgeOfWorker(dateOfBirth) > 18;
            if(!success)
                Console.WriteLine("Greska: Dob radnika mora bit minimalno 18 godina, pokušajte ponovo\n");
        } while (!success);
        
        PrintSingleWorker(new(nameAndSurname, dateOfBirth));
        Console.WriteLine("POTVRDI UNOS RADNIKA (da - ZA POTVRDU, ne - PONOVNI UNOS):");
        stateAddWorkers = ConfirmationDialogForDataChange();

        if (stateAddWorkers != (int)Loop.CONTINUE){

            if (!workers.ContainsKey(nameAndSurname)){
                workers.Add(nameAndSurname, dateOfBirth);
                Console.WriteLine($"Radnik {nameAndSurname} je uspješno dodan!\n");
            }else
                Console.WriteLine($"Greška: Radink {nameAndSurname} vec postoji u bazi\n");
        }

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
    int stateEditWorkers;
    string workerName;
    DateTime dateOfBirth;
    do{
        stateEditWorkers = (int)Loop.TERMINATE;

        Console.WriteLine("Unesi ime radnika kojeg želiš urediti: ");
        workerName = InputNonEmptyString();
        if (!workers.ContainsKey(workerName))
        {
            Console.WriteLine($"Artikl {workerName} ne postoji u bazi, pokušaj ponovno...\n");
            stateEditWorkers = (int)Loop.CONTINUE;
            continue;
        }
        
        PrintSingleWorker(new(workerName, workers[workerName]));

        Console.WriteLine("Uredi datum rođenja? (da/ne): ");
        if (ConfirmationDialog() == 0)
        {
            Console.WriteLine("Unesi novi datum rođenja: ");
            dateOfBirth = InputDateFormat();
           
            workers[workerName] = dateOfBirth;
            Console.WriteLine($"Artikl {workerName} uspiješno uređen\n");
        }
        PrintSingleWorker(new(workerName, workers[workerName]));

        Console.WriteLine(
            "Nastavi sa novim uređivanjem?\n" +
            "(da - ZA NASTAVAK, ne - POVRATAK NA IZBORNIK RADNICI): \n"
        );
        stateEditWorkers = ConfirmationDialog();
        Console.Clear();

    } while (stateEditWorkers == (int)Loop.CONTINUE);
}

void DeleteWorkers(Dictionary<string, DateTime> workers)
{
    int stateDeleteWorkers;
    string? option;

    do{
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
// ****************************************************************************

void PrintReceipts(Dictionary<int, (DateTime date, float totalPrice, Dictionary<string, (int, float)> articles)> receipts)
{
    int statePrintReceipts;
    int inputID;
    bool success;
    do{
        statePrintReceipts = (int)Loop.CONTINUE;
        Console.WriteLine(
            "ISPIS SVIH RAČUNA:\n" +
            "**********************************\n"
        );
        foreach (var (Key, Value) in receipts)
        {
            Console.WriteLine(
             $"RAČUN: ID - {Key}\n" +
             $"Datum izdavanja: {Value.date}\n" +
             $"UKUPNO: {Value.totalPrice:0.00} EUR\n" +
             "**********************************\n"
            );
        }

        Console.WriteLine(
            "nastavi dalje sa ispisom pojeding artikla?\n" +
            "(da - NASTAVAK ne - povratak na izbornik Računi):"
        );
        statePrintReceipts = ConfirmationDialog();
        if (statePrintReceipts == (int)Loop.TERMINATE)
        {
            Console.Clear();
            continue;
        }

        do{
            Console.WriteLine("Unesi ID računa za ispis: ");
            inputID = InputNumberFormat();
            success = receipts.ContainsKey(inputID);
            if (!success)
                Console.WriteLine($"Greška: Nepostoji Račun sa ID: {inputID}, pokušaj ponovo");

        } while (!success);
        PrintReceiptWithDetails(inputID, receipts[inputID]);
        ContinueAndClearConsole();

    } while (statePrintReceipts == (int)Loop.CONTINUE);
}

void PrintReceiptWithDetails(int receiptID, (DateTime date, float totalPrice, Dictionary<string,(int,float)>articles) receipt)
{
    Console.WriteLine(
        $"\nRAČUN: ID - {receiptID}\n" +
        $"**********************************\n" +
        $"Datum izdavanja: {receipt.date}\n"
    );
    PrintReceiptArticles(receipt.articles);
    Console.WriteLine(
        $"UKUPNO: {receipt.totalPrice:0.00} EUR\n" +
        "**********************************\n"
    );
}

void PrintReceiptArticles(Dictionary<string, (int amount,float price)> receiptArticles)
{
    Console.WriteLine("ARTIKLI:\n");
    foreach (var (Key, Value) in receiptArticles)
    {
        Console.WriteLine(
            $"\tIME: {Key}\n" +
            $"\tKOLIČINA: {Value.amount}\n" +
            $"\tCIJENA: {Value.amount*Value.price}:0.00 EUR\n"
        );
    }
}
void AddReceipt(Dictionary<int, (DateTime, float, Dictionary<string, (int,float)>)> receipts)
{
    int stateAddReceiptItems;
    int stateAddReceipts;
    string articleName;
    int amount; 
    float receiptTotalPrice = 0;
    int receiptID = receipts.Keys.Last() + 1;
    DateTime receiptDate = DateTime.Now;
    Dictionary<string, (int, float)> receiptArticles = new() { };

    do{
        PrintArticles(articles);
        stateAddReceipts = (int)Loop.CONTINUE;
        do{
            stateAddReceiptItems = (int)Loop.CONTINUE;
            Console.WriteLine("UNOS PROIZVODA I KOLIČINA:\n");
            Console.WriteLine("Unesi ime proizvoda: ");
            articleName = InputNonEmptyString().ToLower();
            if (!articles.ContainsKey(articleName))
            {
                Console.WriteLine($"Greška: Artikl {articleName} ne postoji u bazi, pokušaj ponovo\n");
                ContinueAndClearConsole();
                continue;
            }
            
            var article = articles[articleName];
            float articlePrice = article.price;

            do{
                Console.WriteLine("Unesi količinu proizvoda: ");
                amount = InputNumberFormat();
                if (amount > article.amount)
                    Console.WriteLine($"Greška: Ukupni broj artikala {articleName} u bazi je manji od {amount}, pokušaj ponovo\n");
            } while (amount > article.amount);

            Console.WriteLine($"Potvrdi unos artikla (da/ne): ");
            if (ConfirmationDialogForDataChange() == (int)Loop.CONTINUE)
                continue;

            Console.WriteLine(
                "nasatavi sa sljedećim unosom proizvoda?\n" +
                "(da - NASTAVAK, ne - ISPIS RAČUNA\n"
            );
            stateAddReceiptItems = ConfirmationDialog();
            Console.Clear();

            receiptArticles.Add(articleName, (amount, articlePrice));
            receiptTotalPrice += articlePrice * amount;
            article.amount -= amount;
            article.soldAmount += amount;

            if (article.amount <= 0)
                articles.Remove(articleName);
            else{
                articles[articleName] = article;
            }
                
        } while (stateAddReceiptItems == (int)Loop.CONTINUE);

        var receipt = (date: receiptDate, totalPrice: receiptTotalPrice, articles: receiptArticles);
        receipts.Add(receiptID, receipt);

        PrintReceiptWithDetails(receiptID, receipts[receiptID]);
        Console.WriteLine(
             "nasatavi sa kreiranjem sljedećeg računa?\n" +
             "(da - NASTAVAK, ne - povratak na meni RAČUNI\n"
        );
        stateAddReceipts = ConfirmationDialog();
        Console.Clear();
    } while (stateAddReceipts == (int)Loop.CONTINUE);
}

// *********************** FUNKCIJE ZA STATISTIKU *****************************
// ****************************************************************************
void StateByMonth()
{
    int loopState;
    Console.Clear();
    do
    {
        loopState = (int)Loop.CONTINUE;
        Console.WriteLine("Unesi godinu i mjesec za prikaz stanja:");
        int year = InputYear();
        int month = InputMonth();

        Console.WriteLine("Unesi iznos place za jednog radnika (EUR):");
        float monthlySalary = InputFloatFormat();
        float totalSalaries = monthlySalary * workers.Count;

        Console.WriteLine($"Unesi iznos najma (EUR):");
        float rent = InputFloatFormat();
        Console.WriteLine($"Unesi iznos ostalih troskova (EUR):");
        float restOfExpences = InputFloatFormat();
        Console.WriteLine("Potvrdi unos podataka? (da - ispis stanja, ne - ponovni unos)");

        if (ConfirmationDialog() != 0){
            Console.Clear();
            continue;
        }
            
        Console.WriteLine("************************************\n");
        float totalProfitByMonth = 0.0f;
        foreach (var (Key, Value) in receipts)
        {
            if (Value.dateTime.Month == month && Value.dateTime.Year == year)
                totalProfitByMonth += Value.totalPrice;
        }

        Console.WriteLine($"STANJE ZA {month}. {year}. :\n");
        Console.WriteLine($"Ukupna zarada u {month}. {year}. je: {totalProfitByMonth:0.00} EUR");
        Console.WriteLine($"Ukupni iznos plaća svih radnika: {totalSalaries:0.00} EUR");
        Console.WriteLine($"Ostali troškovi: {restOfExpences:0.00} EUR\n");

        float ROI = totalProfitByMonth * (1 / 3) - totalSalaries - restOfExpences;
        Console.WriteLine($"Povrat ulaganja za {month}. {year}: {ROI:0.00} EUR\n");
        if (ROI > 0)
            Console.WriteLine("ZARADA\n");
        else if (ROI < 0)
            Console.WriteLine("GUBITAK\n");

        Console.WriteLine(
              "nasatavi sa provjerom iduceg stanja?\n" +
              "(da - NASTAVAK, ne - povratak na meni STATISTIKA):\n"
        );
        loopState = ConfirmationDialog();
        Console.Clear();
    } while (loopState == (int)Loop.CONTINUE);
}

void ValueOfSoldArticles()
{
    float valueOfSoldArticles = 0.0f;
    foreach (var (Key, Value) in articles)
    {
        valueOfSoldArticles += Value.soldAmount*Value.price;
    }
    Console.WriteLine($"VRIJEDNOST SVIH PRODANIH ARTIKALA: {valueOfSoldArticles:0.00} EUR\n");
    ContinueAndClearConsole();
}

void ValueOfNonsoldArticles()
{
    float valueOfNonSoldArticles = 0.0f;
    foreach (var (Key, Value) in articles)
    {
        valueOfNonSoldArticles += Value.amount * Value.price;
    }
    Console.WriteLine($"VRIJEDNOST SVIH NEPRODANIH ARTIKALA: {valueOfNonSoldArticles:0.00} EUR\n");
    ContinueAndClearConsole();
}

void TotalNumberOfArticles(Dictionary<string, Article> articles)
{
    int totalAmount = 0;
    foreach(var article in articles)
    {
        totalAmount += article.Value.amount;
    }
    Console.WriteLine($"UKUPNI BROJ ARTIKALA U TRGOVINI: {totalAmount}\n");
    ContinueAndClearConsole();
}

// *********************** HELPER FUNKCIJE *************************
// *****************************************************************
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
        success = int.TryParse(Console.ReadLine(), out number) && number >=0;
       
        if (!success)
            Console.WriteLine("Greška: Neispravni format za cjeli pozitivni broj, pokušaj ponovo...");
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
            Console.WriteLine("Greška: Neispravni format za decinalni broj, pokušaj ponovo...");
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
            Console.WriteLine("Greška: string ne smije biti prazan, pokušajte ponovo...");
    } while (!success);
    return input;
}
DateTime InputDateFormat()
{
    int year, month, day;
    bool success;
    DateTime date;

    year = InputYear();
    month = InputMonth();

    do {
       Console.WriteLine("DAN (prihvatiljive vrijednosti: 01 - 30 ili 31): ");
       day = InputNumberFormat();
       success = DateTime.TryParse(year + "-" + month + "-" + day, out date);
       if (!success)
                Console.WriteLine($"Greška: {day}. nije prihvatljiva vrijednost za DAN, pokušaj ponovo\n");
    } while (!success);

    return date;
}

int InputYear()
{
    int maxYear = DateTime.Now.Year;
    int minYear = DateTime.Now.Year - 70;
    bool success;
    int year;

    do{
        Console.WriteLine($"GODINA (prihvatljive vrijednosti: {minYear}-{maxYear}): ");
        year = InputNumberFormat();
        success = (year >= minYear) && (year <= maxYear);
        if (!success)
            Console.WriteLine($"Greška: {year} nije prihvatljiva vrijednost za GODINU, pokušaj ponovo\n");
    } while (!success);
    return year;
}

int InputMonth()
{
    bool success;
    int month;
    do
    {
        Console.WriteLine("MJESEC (prihvatiljive vrijednosti: 01-12): ");
        month = InputNumberFormat();
        success = (month >= 1) && (month <= 12);
        if (!success)
            Console.WriteLine($"Greška: {month} nije prihvatljiva vrijednost za MJESEC, pokušaj ponovo\n");
    } while (!success);
    return month;
}

int AgeOfWorker(DateTime start)
{
    DateTime end = DateTime.Now;
    return (end.Year - start.Year - 1) +
        (((end.Month > start.Month) ||
         ((end.Month == start.Month) && 
          (end.Day >= start.Day))) ? 1 : 0);
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
        $"price: {value.price:0.00}\n" +
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
        $"Date of Birth: {dateOfBirth.ToShortDateString()}\n"
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
    public int soldAmount;
    public Article(int amout, float price, int numOfDaysTillExp, int soldAmount) : this()
    {
        this.amount = amout;
        this.price = price;
        this.numOfDaysTillExp = numOfDaysTillExp;
        this.soldAmount = soldAmount;
    }
}

enum Loop
{
    CONTINUE,
    TERMINATE
};

