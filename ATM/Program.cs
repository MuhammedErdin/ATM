using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class cardHolder
    {
        string cardNum;
        int password;
        string firstName;
        string lastName;
        double balance;

        public cardHolder(string cardNum,int password,string firstName,string lastName,double balance)
    {
        this.cardNum = cardNum;
        this.password = password;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPassword()
    {
        return password;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPassword(int newPassword)
    {
        password = newPassword;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void Options()
        {
            Console.WriteLine("Lütfen aşağıdaki seçeneklerden birini seçiniz...");
            Console.WriteLine("1-Para Yatırma");
            Console.WriteLine("2-Para Çekme");
            Console.WriteLine("3-Kalan Bakiye");
            Console.WriteLine("4-Çıkış");
        }

        void Deposit(cardHolder CurrentUser)
        {
            Console.WriteLine("Ne kadar para yatırmak istiyorsunuz? ");
            double deposit = double.Parse(Console.ReadLine());
            CurrentUser.setBalance(CurrentUser.getBalance() + deposit);
            Console.WriteLine("Para yatırdığınız için teşekkür ederiz. Yeni bakiyeniz: " +CurrentUser.getBalance());
        }

        void Withdraw(cardHolder CurrentUser)
        {
            Console.WriteLine("Ne kadar para çekmek istiyorsunuz: ");
            double withdraw = double.Parse(Console.ReadLine());
            //Kullanıcının yeterli parası olup olmadığını kontrol edin
            if (CurrentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Yetersiz Bakiye!");
            }
            else
            {
                CurrentUser.setBalance(CurrentUser.getBalance()-withdraw);
                Console.WriteLine("Para çektiğiniz için teşekkür ederiz");
            }
        }

        void balance(cardHolder CurrenUser)
        {
            Console.WriteLine("Mevcut Bakiye: " +CurrenUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1451634593840912", 1234, "Ahmet", "Kul", 150.59));
        cardHolders.Add(new cardHolder("9281376492833120", 4231, "Mehmet", "Aktaş", 1425.21));
        cardHolders.Add(new cardHolder("1873381247748129", 4561, "Mahmut", "Gül", 105.33));
        cardHolders.Add(new cardHolder("9381127393812128", 2742, "Zeynep", "Polat", 941.46));
        cardHolders.Add(new cardHolder("1873237811273391", 2541, "Melis", "Taştan", 41.25));

        Console.WriteLine("ATM'ye hoşgeldiniz");
        Console.WriteLine("Lütfen banka kartınızı takınız: ");
        String debitCardNum = " ";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Kart Tanınmadı.Lütfen tekrar deneyiniz"); }
            }
            catch{ Console.WriteLine("Kart Tanınmadı.Lütfen tekrar deneyiniz"); }
        }

        Console.WriteLine("Lütfen şifrenizi giriniz: ");
        int userPassword = 0;
        while (true)
        {
            try
            {
                userPassword =int.Parse(Console.ReadLine());
                if (currentUser.getPassword()==userPassword) { break; }
                else { Console.WriteLine("Yanlış giriş.Tekrar deneyiniz"); }
            }
            catch { Console.WriteLine("Yanlış giriş.Tekrar deneyiniz"); }
        }

        Console.WriteLine("Hoşgeldiniz " +currentUser.getFirstName());
        int option = 0;
        do
        {
            Options();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { Deposit(currentUser); }
            else if (option == 2) { Withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option !=4);
        Console.WriteLine("Teşekkür ederiz.İyi günler dileriz");
    }

}
