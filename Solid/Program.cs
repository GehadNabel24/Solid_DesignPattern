using static Solid.LSP;
using static Solid.OCP;
using static Solid.SRP;

namespace Solid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee() { Name = "Ahmed", Salary = 15000, Department = "Web" };

            SalaryCalculator salaryCalculator = new SalaryCalculator();
            decimal yearlySalary = salaryCalculator.CalculateYearlySalary(employee.Salary);

            ReportGenerator reportGenerator = new ReportGenerator();
            reportGenerator.GenerateReport("Yearly", employee);

            EmailService emailService = new EmailService();
            emailService.SendNotification("manager@yahoo.com", "Report generated for employee: " + employee.Name);

            Console.WriteLine("-----------------------------------------------------------------");

            PaymentProcessor paymentProcessor = new PaymentProcessor();

            IPaymentType creditCardPayment = new CreditCardPayment();
            paymentProcessor.ProcessPayment(creditCardPayment, 200.0);

            Console.WriteLine("-----------------------------------------------------------------");

            SavingsAccount savingsAccount = new SavingsAccount() { InterestRate=0.05m};

            savingsAccount.Deposit(500);
            Console.WriteLine("Savings Account Balance after deposit: " + savingsAccount.Balance);

            savingsAccount.Withdraw(200);
            Console.WriteLine("Savings Account Balance after withdrawal: " + savingsAccount.Balance);
        }

    }
}
