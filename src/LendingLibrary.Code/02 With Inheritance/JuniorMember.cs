using System;
using System.Collections.Generic;
using System.Text;

namespace LendingLibrary
{
    public class JuniorMember : Member
    {

        public static decimal OutstandingFineLimit { get; private set; } = 15.00M;

        public JuniorMember(string name, int age, int membershipNumber) : base(name, age, membershipNumber)
        {
        }

        public override string Borrow(Book book)
        {
            if (book.Category == BookCategory.Adult)
                return $"{book.Title} is unsuitable for children. The request to borrow it has been rejected";
            return base.Borrow(book);
        }

        public override void PayFine(decimal fine)
        {
            OutstandingFines -= fine;
        }

        public override void NewFine(decimal fine) // Fine needs to be added to any existing fines
        {
            if (OutstandingFineLimit <= (fine + OutstandingFines))
            {
                OutstandingFines = OutstandingFineLimit;
                return;
            }
            OutstandingFines += fine;
        }
    }
}
