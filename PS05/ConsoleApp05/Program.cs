using System;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

class Fraction
{
    int numerator;
    int denominator;

    public Fraction()
    {
        this.numerator = 0;
        this.denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        if (denominator != 0)
        {
            this.denominator = denominator;
        }
        else
        {
            this.denominator = 1;
            Console.WriteLine("Zła wartość mianownika - Mianownik został automatycznie ustawiony na 1");
        }

        if (numerator == 0)
        {
            this.denominator = 1;
        }

        if (denominator < 0)
        {
            this.denominator *= -1;
            this.numerator *= -1;
        }

        this.numerator = numerator;

        Simplify();
    }

    private int NWD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }

    public void Simplify()
    {
        int gcd = NWD(Math.Abs(numerator), Math.Abs(denominator));
        numerator /= gcd;
        denominator /= gcd;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        int mianownik = a.denominator * b.denominator;
        int licznik = a.numerator * b.denominator + b.numerator * a.denominator;

        return new Fraction(licznik, mianownik);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        int mianownik = a.denominator * b.denominator;
        int licznik = a.numerator * b.denominator - b.numerator * a.denominator;

        return new Fraction(licznik, mianownik);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        int mianownik = a.denominator * b.denominator;
        int licznik = a.numerator * b.numerator;

        return new Fraction(licznik, mianownik);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.numerator == 0)
        {
            Console.WriteLine("Próba dzielenia przez zero");
            return null;
        }
        int mianownik = a.denominator * b.numerator;
        int licznik = a.numerator * b.denominator;

        return new Fraction(licznik, mianownik);
    }

    public static bool operator ==(Fraction a, Fraction b)
    {
        return a.numerator * b.denominator == b.numerator * a.denominator;
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        return a.numerator * b.denominator != b.numerator * a.denominator;
    }

    public static bool operator <(Fraction a, Fraction b)
    {
        return a.numerator * b.denominator < b.numerator * a.denominator;
    }

    public static bool operator >(Fraction a, Fraction b)
    {
        return a.numerator * b.denominator > b.numerator * a.denominator;
    }

    public static bool operator <=(Fraction a, Fraction b)
    {
        return a.numerator * b.denominator <= b.numerator * a.denominator;
    }

    public static bool operator >=(Fraction a, Fraction b)
    {
        return a.numerator * b.denominator >= b.numerator * a.denominator;
    }

    public override string ToString()
    {
        int calaWartosc = this.numerator / this.denominator;
        int reszta = this.numerator % this.denominator;
        
        if (reszta == 0)
        {
            return calaWartosc.ToString();
        }
        else if (calaWartosc == 0)
        {
            return $"{reszta}/{this.denominator}";
        }
        else
        {
        return $"{calaWartosc} {Math.Abs(reszta)}/{this.denominator}";
        }
    }

    public static Fraction Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Wejście nie może być puste");
            return null;
        }

        int i = 0;
        while (i < input.Length && input[i] != '/')
        {
            i++;
        }

        if (i == 0 || i == input.Length - 1 || i == input.Length)
        {
            Console.WriteLine("Ułamek musi być w formacie Licznik/Mianownik");
            return null;
        }

        string licznikString = input.Substring(0, i);
        string mianownikString = input.Substring(i + 1);

        int.TryParse(licznikString, out int numerator);

        int.TryParse(mianownikString, out int denominator);

        return new Fraction(numerator, denominator);
    }

    public static implicit operator double(Fraction a)
    {
        return (double)a.numerator / (double)a.denominator;
    }



    // Fraction a, int b
    public static Fraction operator +(Fraction a, int b)
    {
        int mianownik = a.denominator * 1;
        int licznik = a.numerator * 1 + b * a.denominator;

        return new Fraction(licznik, mianownik);
    }

    public static Fraction operator -(Fraction a, int b)
    {
        int mianownik = a.denominator * 1;
        int licznik = a.numerator * 1 - b * a.denominator;

        return new Fraction(licznik, mianownik);
    }

    public static Fraction operator *(Fraction a, int b)
    {
        int mianownik = a.denominator * b;
        int licznik = a.numerator * 1;

        return new Fraction(licznik, mianownik);
    }

    public static Fraction operator /(Fraction a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Próba dzielenia przez zero");
            return null;
        }
        int mianownik = a.denominator * b;
        int licznik = a.numerator * 1;

        return new Fraction(licznik, mianownik);
    }

    public static bool operator ==(Fraction a, int b)
    {
        return a.numerator * 1 == b * a.denominator;
    }

    public static bool operator !=(Fraction a, int b)
    {
        return a.numerator * 1 != b * a.denominator;
    }

    public static bool operator <(Fraction a, int b)
    {
        return a.numerator * 1 < b * a.denominator;
    }

    public static bool operator >(Fraction a, int b)
    {
        return a.numerator * 1 > b * a.denominator;
    }

    public static bool operator <=(Fraction a, int b)
    {
        return a.numerator * 1 <= b * a.denominator;
    }

    public static bool operator >=(Fraction a, int b)
    {
        return a.numerator * 1 >= b * a.denominator;
    }



    // int a, Fraction b
    public static Fraction operator +(int a, Fraction b)
    {
        int mianownik = 1 * b.denominator;
        int licznik = a * b.denominator + b.numerator * 1;

        return new Fraction(licznik, mianownik);
    }

    public static Fraction operator -(int a, Fraction b)
    {
        int mianownik = 1 * b.denominator;
        int licznik = a * b.denominator + b.numerator * 1;

        return new Fraction(licznik, mianownik);
    }

    public static Fraction operator *(int a, Fraction b)
    {
        int mianownik = 1 * b.denominator;
        int licznik = a * b.numerator;

        return new Fraction(licznik, mianownik);
    }

    public static Fraction operator /(int a, Fraction b)
    {
        if (b.numerator == 0)
        {
            Console.WriteLine("Próba dzielenia przez zero");
            return null;
        }
        int mianownik = 1 * b.numerator;
        int licznik = a * b.denominator;

        return new Fraction(licznik, mianownik);
    }

    public static bool operator ==(int a, Fraction b)
    {
        return a * b.denominator == b.numerator * 1;
    }

    public static bool operator !=(int a, Fraction b)
    {
        return a * b.denominator != b.numerator * 1;
    }

    public static bool operator <(int a, Fraction b)
    {
        return a * b.denominator < b.numerator * 1;
    }

    public static bool operator >(int a, Fraction b)
    {
        return a * b.denominator > b.numerator * 1;
    }

    public static bool operator <=(int a, Fraction b)
    {
        return a * b.denominator <= b.numerator * 1;
    }

    public static bool operator >=(int a, Fraction b)
    {
        return a * b.denominator >= b.numerator * 1;
    }
}

class Program
{
    public static void Main()
    {
        Fraction a = new Fraction(1, 2);
        Fraction b = new Fraction(3, 4);

        Fraction sum = a + b;
        Console.WriteLine("Suma: " + sum);

        if (a >= b) Console.WriteLine($"{a} jest mniejsze niż {b}");

        Console.WriteLine(a + 2);
        Console.WriteLine(2 + a);

        //Console.Write("Podaj ułamek w formacie 'licznik/mianownik': ");
        //string input = Console.ReadLine();

        //Fraction fraction = Fraction.Parse(input);
        //Console.WriteLine($"Wprowadzony ułamek: {fraction}");

        double value = b; 
        Console.WriteLine($"Wartość ułamka w liczbach rzeczywistych: {value}");
    }
}