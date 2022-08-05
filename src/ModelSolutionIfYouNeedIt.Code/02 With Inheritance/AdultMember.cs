using System;
using System.Collections.Generic;
using System.Text;

namespace LendingLibrary
{
    public class AdultMember : Member
    {
        public AdultMember(string name, int age, int membershipNumber) : base(name, age, membershipNumber)
        {
        }

        public void SetUpBankTransferLimit(decimal amount)
        {
            OutstandingFines += amount;
        }

        public override void PayFine(decimal fine)
        {
            //No FineLimit for adults
            OutstandingFines -= fine;
        }

        public override void NewFine(decimal fine) // Fine needs to be added to any existing fines
        {
            OutstandingFines += fine;
        }
    }
}
