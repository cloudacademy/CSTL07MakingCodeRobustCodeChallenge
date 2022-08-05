using LendingLibrary;
using System;
using Xunit;

namespace TestProject
{
    public class MemberUnitTests
    {
        Library library;
        Member greta;
        Member donald;

        public MemberUnitTests()
        {
            library = new Library();
            greta = library.Add(name: "Greta Thunberg", age: 15);
            greta.Street = "Queen Street";
            greta.City = "Stockholm";
            greta.NewFine(6M);
            donald = library.Add(name: "Donald Trump", age: 73);
            donald.Street = "White House";
            donald.City = "Washington";
            donald.NewFine(30M);
        }

        [Fact]
        public void Create()
        {
            Assert.Equal(2, library.NumberOfMembers);
            Assert.Equal(1, greta.MembershipNumber);
            Assert.Equal(2, donald.MembershipNumber);
        }

        [Fact]
        public void Child_Borrows_Child_Book_OK()
        {
            // a junior member (under 16) can borrow only child category books
            Book childBook = library.GetBook(101);
            Assert.Equal($"{childBook.Title} successfully borrowed by {greta.Name}", greta.Borrow(childBook));
        }

        [Fact]
        public void Child_Borrows_Adult_Book_Fails()
        {
            // a junior member (under 16) can borrow only child category books
            Book adultBook = library.GetBook(100);
            Assert.Equal($"{adultBook.Title} is unsuitable for children. The request to borrow it has been rejected", greta.Borrow(adultBook));
        }

        [Fact]
        public void Adult_Can_Borrow_Any_Book()
        {
            // a junior member (under 16) can borrow only child category books
            Book adultBook = library.GetBook(100);
            Book childBook = library.GetBook(101);
            Assert.Equal($"{adultBook.Title} successfully borrowed by {donald.Name}", donald.Borrow(adultBook));
            Assert.Equal($"{childBook.Title} successfully borrowed by {donald.Name}", donald.Borrow(childBook));
        }

        [Fact]
        public void Child_Pays_Fine_From_Cash_Fund()
        {
            decimal payment = 7M; //Only owes £6.00 at this point so account will be £1.00 in credit
            decimal expectedBalance = greta.OutstandingFines - payment;
            greta.PayFine(payment);
            Assert.Equal(expectedBalance, greta.OutstandingFines); // negative if member is in credit
        }

        [Fact]
        public void Child_Incurs_Fine_That_Exceeds_limit()
        {
            decimal fine = 17M;
            decimal expectedBalance = JuniorMember.OutstandingFineLimit;
            //Note: FineLimit is a static readonly property set to a default value of 15.00
            greta.NewFine(fine); //child fine 's are capped so only £15 needs to be paid
            Assert.Equal(expectedBalance, greta.OutstandingFines); // negative if member is in credit
        }

        [Fact]
        public void Adult_Pays_Fine()
        {
            //Note: There is no fine limit for adults
            decimal payment = 17M;
            decimal expectedBalance = donald.OutstandingFines - payment;
            donald.PayFine(payment);
            Assert.Equal(expectedBalance, donald.OutstandingFines); // negative if member is in credit
        }

        [Fact]
        public void Adult_Incurs_Fine_That_Exceeds_limit()
        {
            //Note: There is no fine limit for adults
            decimal fine = 17M;
            decimal expectedBalance = donald.OutstandingFines + fine;
            donald.NewFine(fine);
            Assert.Equal(expectedBalance, donald.OutstandingFines); // negative if member is in credit
        }
    }
}
