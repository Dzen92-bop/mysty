using System;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;

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
}

public class VirtualPayment
{
    public List<Payment> Payments { get; set; } = new List<Payment>();
}
public class Program
{
    public static void Main(string[] args)
    {
        
        VirtualPayment vPayment = new VirtualPayment();
        vPayment.Payments.Add(new Payment("pm1", "USD", 91.1 ));
        vPayment.Payments.Add(new Payment("pm2", "EUR", 96.1));
        vPayment.Payments.Add(new Payment("pm3", "RUB", 1));

        string filePath = "vpayment.json";
        string fileLoadPath = "inbase.json";

        SaveToFile(vPayment, filePath);

        VirtualPayment loadedvPayment = LoadFromFile(fileLoadPath);
        foreach (var member in loadedvPayment.Payments)
        {
            switch (member)
            {
                case Payment payment:
                    Console.WriteLine($"{payment.Code}, {payment.Currency}, {payment.Count}");
                    break;
            }
        }
        static void SaveToFile(VirtualPayment pra, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
            {
                new JsonStringEnumConverter()
            }
            };
            string json = JsonSerializer.Serialize(pra, options);
            File.WriteAllText(filePath, json);
        }

        static VirtualPayment LoadFromFile(string fileLoadPath)
        {
            string json = File.ReadAllText(fileLoadPath);
            return JsonSerializer.Deserialize<VirtualPayment>(json);
        }
    }
}