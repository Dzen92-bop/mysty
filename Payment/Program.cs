using System;

public class Tutorial
{
    public string Code { get;set;}
    public int Step { get; set; }
    public Tutorial(string code, int step)
    {
        Code = code;
        Step = step;
    }
    public virtual void InfoT()
    {
        Console.WriteLine($"Name: {Code}, Step: {Step}");
    }
}

public class Payment
{
    public string Code { get; set; }
    public string Currency { get; set; }
    public double Count { get; set; }
    public Payment(string code, string currency, double count)
    {
        Code = code;
        Currency = currency;
        Count = count;
    }
    public virtual void InfoP()
    {
        Console.WriteLine($"Name: {Code}, Currency: {Currency}, Count: {Count}");
    }
}

public class VirtualPayment
{
    public string Code { get; set; }
    public bool Valid { get; set; }

    private List<Payment> payments = new List<Payment>();
    public VirtualPayment(string code, bool valid)
    {
        Code = code;
        Valid = valid;
    }
    public void AddPayment(Payment payment)
    {
        payments.Add(payment);
        Console.WriteLine($"Валюта добавлена");
    }
    public virtual void InfoVP()
    {
        Console.WriteLine($"Name: {Code}, Valid: {Valid}");
    }

    public void DisplayAllPayments()
    {
        if (payments.Count == 0)
        {
            Console.WriteLine("-----");
            return;
        }

        Console.WriteLine("Список:");
        foreach (Payment payment in payments)
        {
            Console.WriteLine(payment);
        }
    }
}

public class Cheater
{
    public string Code { get; set; }
    public bool Banned { get; set; }
    public Cheater(string code, bool banned)
    {
        Code = code;
        Banned = banned;
    }
    public virtual void InfoC()
    {
        Console.WriteLine($"Name: {Code}, Banned: {Banned}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Tutorial tutu = new Tutorial("tr1", 1);
        VirtualPayment vPayment = new VirtualPayment("vp", true);
        vPayment.AddPayment(new Payment("pm1", "USD", 91.1));
        vPayment.AddPayment(new Payment("pm2", "EUR", 96.1));
        vPayment.AddPayment(new Payment("pm3", "RUB", 1));
        Cheater cheater = new Cheater("ct1", true);
        tutu.InfoT();
        cheater.InfoC();
        vPayment.DisplayAllPayments();
    }
}