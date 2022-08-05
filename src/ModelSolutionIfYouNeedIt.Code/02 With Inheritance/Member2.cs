using System;
using System.Collections.Generic;

namespace LendingLibrary
{
    public abstract class Member
    {
        public string Name { get; }
        public int MembershipNumber { get; }
        public int Age { get; }

        public string Street { get; set; }
        public string City { get; set; }
        // if outstanding fines is -'ve account is in credit
        // if outstanding fines is +'ve there are still fines that need paying
        public decimal OutstandingFines { get; protected set; }

        public Member(string name, int age, int membershipNumber)
        {
            this.Name = name;
            this.Age = age;
            this.MembershipNumber = membershipNumber;
        }

        public virtual string Borrow(Book book)
        {
            //Code that updates database with details that member has borrowed book would go here
            return $"{book.Title} successfully borrowed by {this.Name}";
        }
        public abstract void PayFine(decimal fine);
        public abstract void NewFine(decimal fine);
    }
}