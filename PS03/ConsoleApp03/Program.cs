using System;
class Person
{
    public string FirstName;
    public string LastName;
    public string JobTitle;
    public string Company;
    public string Email;
    public string PhoneNumber;

    public Person(string FirstName, string LastName, string JobTitle = "", string Company = "", string Email = "", string PhoneNumber = "")
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.JobTitle = JobTitle;
        this.Company = Company;
        this.Email = Email;
        this.PhoneNumber = PhoneNumber;
    }

    public void DisplayShortInfo()
    {
        if (!string.IsNullOrEmpty(JobTitle) && !string.IsNullOrEmpty(Company))
        {
            Console.WriteLine(FirstName + " " + LastName + " (" + JobTitle + " at " + Company + ") ");
        }
        else if (!string.IsNullOrEmpty(JobTitle))
        {
            Console.WriteLine(FirstName + " " + LastName + " (" + JobTitle + ") ");
        }
        else if (!string.IsNullOrEmpty(Company))
        {
            Console.WriteLine(FirstName + " " + LastName + " (" + Company + ") ");
        }
        else
        {
            Console.WriteLine(FirstName + " " + LastName);
        }
    }

    public void DisplayFullInfo()
    {
        int LiczbaMyslnikow =
        Math.Max(PhoneNumber.Length + 11,
        Math.Max(Email.Length + 7,
        Math.Max(Company.Length,
        Math.Max(JobTitle.Length, LastName.Length + FirstName.Length + 1))));
        //Console.WriteLine(LiczbaMyslnikow);

        string Myslniki = "";
        string Granica = "";
        for (int i = 0; i < LiczbaMyslnikow; i++)
        {
            Myslniki += "-";
            Granica += "=";
        }

        string SpacjaImie = "";
        int LiczbaSpacjiDlaImienia = LiczbaMyslnikow-(FirstName.Length+LastName.Length+1);
        //Console.WriteLine(LiczbaSpacjiDlaImienia);
        for (int i = 0; i < LiczbaSpacjiDlaImienia/2; i++)
        {
            SpacjaImie += " ";
        }

        string SpacjaStanowisko = "";
        int LiczbaSpacjiDlaStanowiska = LiczbaMyslnikow-JobTitle.Length;
        //Console.WriteLine(LiczbaSpacjiDlaStanowiska);
        for (int i = 0; i < LiczbaSpacjiDlaStanowiska/2; i++)
        {
            SpacjaStanowisko += " ";
        }

        string SpacjaFirma = "";
        int LiczbaSpacjiDlaFirmy = LiczbaMyslnikow-Company.Length;
        //Console.WriteLine(LiczbaSpacjiDlaFirmy);
        for (int i = 0; i < LiczbaSpacjiDlaFirmy/2; i++)
        {
            SpacjaFirma += " ";
        }
        Console.WriteLine(Granica);
        Console.WriteLine(SpacjaImie + FirstName + " " + LastName);

        if(!string.IsNullOrEmpty(JobTitle) && !string.IsNullOrEmpty(Company))
        {
            Console.WriteLine(Myslniki);
            Console.WriteLine(SpacjaStanowisko + JobTitle);
            Console.WriteLine(SpacjaFirma + Company);
        }
        else if(!string.IsNullOrEmpty(JobTitle))
        {
            Console.WriteLine(Myslniki);
            Console.WriteLine(SpacjaStanowisko + JobTitle);
        }
        else if(!string.IsNullOrEmpty(Company))
        {
            Console.WriteLine(Myslniki);
            Console.WriteLine(SpacjaFirma + Company);
        }

        if(!string.IsNullOrEmpty(Email) && Email.Contains("@") && !string.IsNullOrEmpty(PhoneNumber))
        {
            Console.WriteLine(Myslniki);
            Console.WriteLine("Email: "+Email);
            Console.WriteLine("Phone: "+PhoneNumber);
        }
        else if(!string.IsNullOrEmpty(Email) && Email.Contains("@"))
        {
            Console.WriteLine(Myslniki);
            Console.WriteLine("Email: "+Email);
        }
        else if(!string.IsNullOrEmpty(PhoneNumber))
        {
            Console.WriteLine(Myslniki);
            Console.WriteLine("Phone: "+PhoneNumber);
        }

        Console.WriteLine(Granica);
    }

    public string GetShortInfo()
    {
        string Wizytowka;
        if (!string.IsNullOrEmpty(JobTitle) && !string.IsNullOrEmpty(Company))
        {
            Wizytowka = FirstName + " " + LastName + " (" + JobTitle + " at " + Company + ") ";
        }
        else if (!string.IsNullOrEmpty(JobTitle))
        {
            Wizytowka = FirstName + " " + LastName + " (" + JobTitle + ") ";
        }
        else if (!string.IsNullOrEmpty(Company))
        {
            Wizytowka = FirstName + " " + LastName + " (" + Company + ") ";
        }
        else
        {
            Wizytowka = FirstName + " " + LastName;
        } 

        return Wizytowka; 
    }

    public string GetFullInfo()
    {
        string Wizytowka = "";

        int LiczbaMyslnikow =
        Math.Max(PhoneNumber.Length + 11,
        Math.Max(Email.Length + 7,
        Math.Max(Company.Length,
        Math.Max(JobTitle.Length, LastName.Length + FirstName.Length + 1))));
        //Console.WriteLine(LiczbaMyslnikow);

        string Myslniki = "";
        string Granica = "";
        for (int i = 0; i < LiczbaMyslnikow; i++)
        {
            Myslniki += "-";
            Granica += "=";
        }

        string SpacjaImie = "";
        int LiczbaSpacjiDlaImienia = LiczbaMyslnikow-(FirstName.Length+LastName.Length+1);
        //Console.WriteLine(LiczbaSpacjiDlaImienia);
        for (int i = 0; i < LiczbaSpacjiDlaImienia/2; i++)
        {
            SpacjaImie += " ";
        }

        string SpacjaStanowisko = "";
        int LiczbaSpacjiDlaStanowiska = LiczbaMyslnikow-JobTitle.Length;
        //Console.WriteLine(LiczbaSpacjiDlaStanowiska);
        for (int i = 0; i < LiczbaSpacjiDlaStanowiska/2; i++)
        {
            SpacjaStanowisko += " ";
        }

        string SpacjaFirma = "";
        int LiczbaSpacjiDlaFirmy = LiczbaMyslnikow-Company.Length;
        //Console.WriteLine(LiczbaSpacjiDlaFirmy);
        for (int i = 0; i < LiczbaSpacjiDlaFirmy/2; i++)
        {
            SpacjaFirma += " ";
        }

        Wizytowka += Granica + "\n";
        Wizytowka += SpacjaImie + FirstName + " " + LastName + "\n";

        if(!string.IsNullOrEmpty(JobTitle) && !string.IsNullOrEmpty(Company))
        {
            Wizytowka += Myslniki + "\n";
            Wizytowka += SpacjaStanowisko + JobTitle + "\n";
            Wizytowka += SpacjaFirma + Company + "\n";
        }
        else if(!string.IsNullOrEmpty(JobTitle))
        {
            Wizytowka += Myslniki + "\n";
            Wizytowka += SpacjaStanowisko + JobTitle + "\n";
        }
        else if(!string.IsNullOrEmpty(Company))
        {
            Wizytowka += Myslniki + "\n";
            Wizytowka += SpacjaFirma + Company + "\n";
        }

        if(!string.IsNullOrEmpty(Email) && Email.Contains("@") && !string.IsNullOrEmpty(PhoneNumber))
        {
            Wizytowka += Myslniki + "\n";
            Wizytowka += "Email: "+Email + "\n";
            Wizytowka += "Phone: "+PhoneNumber + "\n";
        }
        else if(!string.IsNullOrEmpty(Email) && Email.Contains("@"))
        {
            Wizytowka += Myslniki + "\n";
            Wizytowka += "Email: "+Email + "\n";
        }
        else if(!string.IsNullOrEmpty(PhoneNumber))
        {
            Wizytowka += Myslniki + "\n";
            Wizytowka += "Phone: "+PhoneNumber + "\n";
        }

        Wizytowka += Granica;

        return Wizytowka;
    }
}

class Program
{   
    public static void WczytywanieDanych()
    {
        Console.WriteLine("Podaj swoje dane:");
        
        string Imie;
        do
        {
            Console.Write("Imię: ");
            Imie = Console.ReadLine();
        }while (string.IsNullOrEmpty(Imie));

        string Nazwisko;
        do
        {
            Console.Write("Nazwisko: ");
            Nazwisko = Console.ReadLine();
        }while (string.IsNullOrEmpty(Nazwisko));

        Console.Write("Stanowisko (opcjonalne): ");
        string Stanowisko = Console.ReadLine();
        Console.Write("Firma (opcjonalne): ");
        string Firma = Console.ReadLine();
        Console.Write("E-mail (opcjonalne): ");
        string Mail = Console.ReadLine();
        Console.Write("Telefon (opcjonalne): ");
        string NumerTelefonu = Console.ReadLine();

        Person user = new Person(Imie, Nazwisko, Stanowisko, Firma, Mail, NumerTelefonu);
        
        user.DisplayShortInfo();
        user.DisplayFullInfo();
    }

    public static void WyswietlDane()
    {
        Person p1 = new Person("Kamil", "Tomczewski", "Junior Developer", "Meta", "kamil.tomczewski@meta.com", "111 222 333");
        p1.DisplayShortInfo();
        p1.DisplayFullInfo();
        Console.WriteLine("");

        Person p2 = new Person("Anna", "Kowalska", "Software Engineer", "Google", "anna.kowalska@google.com");
        p2.DisplayShortInfo();
        p2.DisplayFullInfo();
        Console.WriteLine("");

        Person p3 = new Person("Piotr", "Nowak", "Senior Developer", "Microsoft");
        p3.DisplayShortInfo();
        p3.DisplayFullInfo();
        Console.WriteLine("");

        Person p4 = new Person("Maria", "Wiśniewska", "Project Manager");
        p4.DisplayShortInfo();
        p4.DisplayFullInfo();
        Console.WriteLine("");

        Person p5 = new Person("Jan", "Kowalczyk");
        p5.DisplayShortInfo();
        p5.DisplayFullInfo();
        Console.WriteLine("");

        Person p6 = new Person("Katarzyna", "Zielińska", "", "Apple", "katarzyna.zielinska@apple.com", "666 777 888");
        p6.DisplayShortInfo();
        p6.DisplayFullInfo();
        Console.WriteLine("");

        Person p7 = new Person("Tomasz", "Lewandowski", "", "", "tomasz.lewandowski@amazon.com", "777 888 999");
        p7.DisplayShortInfo();
        p7.DisplayFullInfo();
        Console.WriteLine("");

        Person p8 = new Person("Agnieszka", "Szymczak", "", "", "", "888 999 000");
        p8.DisplayShortInfo();
        p8.DisplayFullInfo();
        Console.WriteLine("");

        Person p9 = new Person("Michał", "Wójcik", "", "", "", "");
        p9.DisplayShortInfo();
        p9.DisplayFullInfo();
        Console.WriteLine("");

        Person p10 = new Person("Ewa", "Nowicka", "", "Tesla", "ewa.nowicka@tesla.com", "101 202 303");
        p10.DisplayShortInfo();
        p10.DisplayFullInfo();
        Console.WriteLine("");

        Person p11 = new Person("Krzysztof", "Mazur", "System Analyst", "", "krzysztof.mazur@hp.com", "202 303 404");
        p11.DisplayShortInfo();
        p11.DisplayFullInfo();
        Console.WriteLine("");

        Person p12 = new Person("Monika", "Dąbrowska", "Database Administrator", "Cisco", "", "303 404 505");
        p12.DisplayShortInfo();
        p12.DisplayFullInfo();
        Console.WriteLine("");

        Person p13 = new Person("Łukasz", "Jabłoński", "Mobile Developer", "Samsung", "lukasz.jablonski@samsung.com", "");
        p13.DisplayShortInfo();
        p13.DisplayFullInfo();
        Console.WriteLine("");

        Person p14 = new Person("Barbara", "Kamińska", "Product Owner", "Intel", "barbara.kaminska@intel.com", "505 606 707");
        p14.DisplayShortInfo();
        p14.DisplayFullInfo();
        Console.WriteLine("");

        Person p15 = new Person("Paweł", "Piotrowski", "Full Stack Developer", "Adobe", "pawel.piotrowski@adobe.com", "606 707 808");
        p15.DisplayShortInfo();
        p15.DisplayFullInfo();
    }

    static void Main()
    {
        WyswietlDane();

        WczytywanieDanych();

        Person p1 = new Person("Miłosz", "Szymczuk", "Student", "Politechnika Białostocka", "milosz.szymczuk@pb.pl", "123 456 789");
        Console.WriteLine(p1.GetFullInfo());
    }
}
