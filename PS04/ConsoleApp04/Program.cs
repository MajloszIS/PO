using System;

class CreditCard
{
    private string cardNumber;
    private string cardHolder;
    private double creditLimit;
    private double currentDebt;
    private int dailyTransactionlimit;
    private int transactionCount;

    public CreditCard(string cardHolder, double creditLimit, int dailyTransactionlimit)
    {
        Random rand = new Random();
        this.cardNumber = "";
        for (int i = 0; i < 19; i++)
        {
            if (i == 4 || i == 9 || i == 14)
            {
                cardNumber += " ";
            }
            else
            {
                cardNumber += rand.Next(0, 9).ToString();
            }
        }
        this.cardHolder = cardHolder;
        this.creditLimit = creditLimit;
        currentDebt = 0;
        this.dailyTransactionlimit = dailyTransactionlimit;
        transactionCount = 0;
    }
    public bool MakePurchase(decimal amount)
    {
        if (amount > 0 && amount <= (decimal)creditLimit && transactionCount <= dailyTransactionlimit)
        {
            creditLimit -= (double)amount;
            currentDebt += (double)amount;
            Console.WriteLine("Dokonano transakcji na kwote - " + amount);
            transactionCount++;
            return true;
        }
        else
        {
            Console.WriteLine("Transakcja się nie powiodła, sprawdź Saldo");
            transactionCount++;
            return false;
        }
    }

    public void MakePayment(decimal amount)
    {
        if (amount <= (decimal)currentDebt && amount > 0)
        {
            currentDebt -= (double)amount;
            creditLimit += (double)amount;
            Console.WriteLine("Dokonano płatności o wartości - " + amount);
        }
        else
        {
            Console.WriteLine("Akcja się nie powiodła");
        }
    }

    public void ResetDailyLimit()
    {
        DateTime godzina = DateTime.Now;
        if (godzina.Hour == 24)
        {
            transactionCount = 0;
        }
    }

    public string GetCardInfo()
    {
        string info = "";

        info = "\n================================\n" +
                "Numer karty: " + cardNumber + "\n" +
                cardHolder + "\n" +
                "Kredyt: " + creditLimit + "\n" +
                "Aktualne zadłużenie: " + currentDebt + "\n" +
                "Liczba transakcji: " + transactionCount +
                "\n================================\n";

        return info;
    }
}
class Program
{
    public static void Main()
    {
        CreditCard myCard = new CreditCard("Jan Kowalski", 5000, 5);

        Console.WriteLine(myCard.GetCardInfo()); // Wyświetla dane karty

        myCard.MakePurchase(1000); // Uda się

        myCard.MakePurchase(4500); // Nie uda się - przekracza limit
        myCard.MakePayment(500);   // Spłata 500 zł

        Console.WriteLine(myCard.GetCardInfo()); // Aktualne saldo i dług
    }
}
