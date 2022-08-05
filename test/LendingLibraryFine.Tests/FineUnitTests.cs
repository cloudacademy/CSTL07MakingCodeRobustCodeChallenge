using LendingLibrary;
using System;
using Xunit;

namespace LendingLibraryFineTests
{
    public class FineUnitTests
    {
        Library library;
        Member dracoWithFine;
        Member gretaNoFine;
        Member donaldWithFine;
        Member georgeNoFine;

        Book childBook;
        Book adultBook;

        public FineUnitTests()
        {
            library = new Library();
            dracoWithFine = library.Add(name: "Draco Malfoy", age: 15);
            dracoWithFine.Street = "Malfoy Manor";
            dracoWithFine.City = "Wiltshire";
            dracoWithFine.NewFine(6M);

            gretaNoFine = library.Add(name: "Pippi Longstocking", age: 15);
            gretaNoFine.Street = "Queen Street";
            gretaNoFine.City = "Stockholm";

            donaldWithFine = library.Add(name: "Donald Trump", age: 76);
            donaldWithFine.Street = "Hicksville";
            donaldWithFine.City = "Arizona";
            donaldWithFine.NewFine(30M);

            georgeNoFine = library.Add(name: "George Bailey", age: 76);
            georgeNoFine.Street = "320 Sycamore Street";
            georgeNoFine.City = "Bedford Falls";

            childBook = library.GetBook(101);
            adultBook = library.GetBook(100);
        }

        [Fact]
        public void Create()
        {
            Assert.Equal(4, library.NumberOfMembers);
            Assert.Equal(1, dracoWithFine.MembershipNumber);
            Assert.Equal(2, gretaNoFine.MembershipNumber);
            Assert.Equal(3, donaldWithFine.MembershipNumber);
            Assert.Equal(4, georgeNoFine.MembershipNumber);
        }

        [Fact]
        public void Child_Pays_Fine_From_Cash_Fund()
        {
            decimal payment = 7M;
            decimal expectedBalance = dracoWithFine.OutstandingFines - payment;
            dracoWithFine.PayFine(payment);
            Assert.Equal(expectedBalance, dracoWithFine.OutstandingFines); // negative if member is in credit
        }

        [Fact]
        public void Child_Incurs_Fine_That_Exceeds_Limit()
        {
            decimal fine = 17M;
            decimal expectedBalance = JuniorMember.OutstandingFineLimit;
            //Note: FineLimit is a static readonly property set to a default value of 15.00
            dracoWithFine.NewFine(fine); //child fine's are capped so only £15 needs to be paid
            Assert.Equal(expectedBalance, dracoWithFine.OutstandingFines); // negative if member is in credit
        }

        [Fact]
        public void Adult_Pays_Fine()
        {
            //Note: There is no fine limit for adults
            decimal payment = 17M;
            decimal expectedBalance = donaldWithFine.OutstandingFines - payment;
            donaldWithFine.PayFine(payment);
            Assert.Equal(expectedBalance, donaldWithFine.OutstandingFines); // negative if member is in credit
        }

        [Fact]
        public void Adult_Incurs_Fine_That_Exceeds_Child_Limit()
        {
            //Note: There is no fine limit for adults
            decimal fine = 17M;
            decimal expectedBalance = donaldWithFine.OutstandingFines + fine;
            donaldWithFine.NewFine(fine);
            Assert.Equal(expectedBalance, donaldWithFine.OutstandingFines); // negative if member is in credit
        }
    }
}
