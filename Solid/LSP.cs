using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    internal class LSP
    {
        public abstract class AccountBase
        {
            public decimal Balance { get; protected set; }

            public abstract void Deposit(decimal amount);
            public abstract void Withdraw(decimal amount);
        }

        public class Account : AccountBase
        {
            public override void Deposit(decimal amount)
            {
                Balance += amount;
            }

            public override void Withdraw(decimal amount)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                }
                else
                {
                    throw new InvalidOperationException("Insufficient balance.");
                }
            }
        }

        public class SavingsAccount : AccountBase
        {
            public decimal InterestRate { get; set; }

            public override void Deposit(decimal amount)
            {
                Balance += amount;
            }

            public override void Withdraw(decimal amount)
            {
                decimal totalAmount = amount + InterestRate;
                if (Balance >= totalAmount)
                {
                    Balance -= totalAmount;
                }
                else
                {
                    throw new InvalidOperationException("Insufficient balance.");
                }
            }
        }

    }
}
