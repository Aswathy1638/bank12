abstract class BankAccount
{
    public int AccountNumber
    { get;
      set;
    }
    public int Balance
    {
        get;
        set;
    }
    public abstract void Deposit(int amount);
    public abstract void Withdraw(int amount);

}
class SavingsAccount : BankAccount
{
    public int interestrate
    {
        get;
        set;
    }

    public override void Deposit(int amount)
    {
        Balance += amount + (amount * interestrate);
    }

    public override void Withdraw(int amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            throw new Exception("Insufficient funds");
        }
    }


}
class CheckingAccount : BankAccount
{
    public int overdraftlimit
    {
        get;
        set;
    }
    public override void Deposit(int amount)
    {
        Balance += amount;
    }
    public override void Withdraw(int amount)
    {
        if (Balance + overdraftlimit >= amount)
        {
            Balance -= amount;
        }
        else
        {
            throw new Exception("Insufficient funds");
        }
    }

}
class Program
{
    public static void Main(string[] args)
    {
        SavingsAccount savingsAccount = new SavingsAccount { AccountNumber = 11111, Balance = 120000, interestrate = 5 };
        CheckingAccount checkingAccount = new CheckingAccount { AccountNumber = 222222, Balance = 14000, overdraftlimit = 523 };
        Console.WriteLine($"Initial Savings Account Balance: {savingsAccount.Balance}");
        Console.WriteLine($"Initial Checking Account Balance: {checkingAccount.Balance}");
        savingsAccount.Deposit(500);
        checkingAccount.Deposit(1000);
        Console.WriteLine($"After Deposit - Savings Account Balance: {savingsAccount.Balance}");
        Console.WriteLine($"After Deposit - Checking Account Balance: {checkingAccount.Balance}");
        try
        {
            savingsAccount.Withdraw(2000);
            Console.WriteLine($"After Withdrawal - Savings Account Balance: {savingsAccount.Balance}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Savings Account Withdrawal Failed - {ex.Message}");
        }
        try
        {
            checkingAccount.Withdraw(3000);
            Console.WriteLine($"After Withdrawal - Checking Account Balance: {checkingAccount.Balance}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Checking Account Withdrawal Failed - {ex.Message}");
        }
        Console.ReadLine();
    }
}
 