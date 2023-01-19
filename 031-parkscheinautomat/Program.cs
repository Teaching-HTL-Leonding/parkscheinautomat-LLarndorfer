double münzen = 0.00;
int minuten = 0;
int stunden = 0;
bool ParkDauer = false;

void PrintWelcome(){
    Console.WriteLine("Hallo");
    Console.WriteLine("Bitte Münzen einwerfen: 50 (Cents), 10 (Cents), 20 (Cents), 50 (Cents), 1 (Euro), 2 (Euro)");
    Console.WriteLine("Parkschein drucken mit d oder D");
}

void EnterCoins()
{
    bool isDone = false;

    do
    {
        Console.Write("Bitte werfen Sie eine Münze ein: ");
        string münzeinwurf = Console.ReadLine()!;

        if (münzeinwurf == "d" || münzeinwurf == "D"){
            if (münzen > 0.5){
                isDone = true;
            }
            else
            {
                Console.WriteLine("Mindesteinwurf 50 Cent");
            }
        }
        else
        {
            if (münzeinwurf == "5" || münzeinwurf == "10" || münzeinwurf == "20" || münzeinwurf == "50" || münzeinwurf == "1" || münzeinwurf == "2")
            {
                double münze = double.Parse(münzeinwurf);
                if(münze == 1)
                {
                    münzen += 1;
                    AddParkingTime(münze);
                } 
                else if(münze == 2) 
                {
                    münzen += 2;
                    AddParkingTime(münze);
                }
                else 
                {
                    AddParkingTime(münze);
                    münzen += münze / 100;
                }
                Console.WriteLine($"Ihre Parkzeit bisher: {stunden}:{minuten:00}");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe!");
            }
        }
    } while (!isDone || !ParkDauer);
}

void AddParkingTime(double coin){
    switch (coin)
    {
        case 1:
            stunden++;
            break;
        case 2:
            stunden += 2;
            break;
        case 5:
            minuten += 3;
            break;
        case 10:
            minuten += 6;
            break;
        case 20:
            minuten += 12;
            break;
        case 50:
            minuten += 30;
            break;
        default:
        break;
    }
    if(minuten >= 60) 
    {
        minuten -= 60;
        stunden++;
    }
    if(stunden > 1 && minuten > 30 || stunden > 1) {
        PrintParkingTime();
        ParkDauer = true;
    }
}

void PrintParkingTime()
{
    Console.WriteLine($"Your current parking time is {stunden}:{minuten:00}");
}

void PrintDonation()
{
    int euro = 0;
    double cents = 0;
    if(münzen >= 1.50)
    {
        münzen -= 1.50;
        do 
        {
            euro += 1;
            münzen -= 1;
        }while(münzen >= 1);
        cents = (münzen * 100);
    }
    Console.WriteLine($"Danke für Ihre Spende {euro} Euro {cents} cents");
    
}
PrintWelcome();
EnterCoins();
PrintParkingTime();
PrintDonation();
