using LendingLibrary;
using System;
using Xunit;

namespace TestProject
{
    public class AdultAndJuniorClassInheritanceTests
    {
        Library library;
        Member greta;
        Member donald;

        public AdultAndJuniorClassInheritanceTests()
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
        public void AdultMember_Class_Test()
        {
            //Arrange
            AdultMember adultMember = new AdultMember("William Bragg", 64, 121212);
            Decimal expectedBalance = 2.00M;
            //Act
            adultMember.NewFine(12.00M);
            adultMember.PayFine(10.00M);
            //Assert
            Assert.Equal(expectedBalance, adultMember.OutstandingFines);
        }

        [Fact]
        public void AdultMember_With_A_Lot_Of_Outstanding_Fines_Test()
        {
            //Arrange
            AdultMember adultMember = new AdultMember("William Bragg", 64, 121212);
            Decimal expectedBalance = 100.00M;
            //Act
            for (int i = 0; i < 10; i++)
                adultMember.NewFine(10.00M);
            //Assert
            Assert.Equal(expectedBalance, adultMember.OutstandingFines);
        }

        [Fact]
        public void AdultMember_ALLOWED_To_Borrow_Child_And_Adult_Books_Test()
        {
            //Arrange
            AdultMember adultMember = new AdultMember("William Bragg", 64, 121212);

            //Act
            Book adultBook = library.GetBook(100); //Adult Book
            Book childBook = library.GetBook(101); //Childrens Book

            //Assert
            Assert.Equal($"{adultBook.Title} successfully borrowed by {adultMember.Name}", adultMember.Borrow(adultBook));
            Assert.Equal($"{childBook.Title} successfully borrowed by {adultMember.Name}", adultMember.Borrow(childBook));
        }

        [Fact]
        public void Child_Member_Class_Test()
        {
            //Arrange
            JuniorMember juniorMember = new JuniorMember("Kitty Kat", 12, 1234321);
            Decimal expectedBalance = 2.00M;
            //Act
            juniorMember.NewFine(12.00M);
            juniorMember.PayFine(10.00M);
            //Assert
            Assert.Equal(expectedBalance, juniorMember.OutstandingFines);
        }

        [Fact]
        public void Child_Member_With_A_Lot_Of_Unreturned_Books_Test()
        {
            //Arrange
            JuniorMember juniorMember = new JuniorMember("Kitty Kat", 12, 1234321);
            Decimal expectedBalance = 15.00M;
            //Act
            for (int i = 0; i < 10; i++)
                juniorMember.NewFine(10.00M);
            //Assert
            Assert.Equal(expectedBalance, juniorMember.OutstandingFines);
        }

        [Fact]
        public void Child_Member_ALLOWED_To_Borrow_Childrens_Book_Test()
        {
            //Arrange
            JuniorMember juniorMember = new JuniorMember("Kitty Kat", 12, 1234321);

            //Act
            Book childBook = library.GetBook(101); //Child Book


            //Assert
            Assert.Equal($"{childBook.Title} successfully borrowed by {juniorMember.Name}", juniorMember.Borrow(childBook));
        }

        [Fact]
        public void Child_Member_NOT_ALLOWED_To_Borrow_Adult_Book_Test()
        {
            //Arrange
            JuniorMember juniorMember = new JuniorMember("Kitty Kat", 12, 1234321);

            //Act
            Book adultBook = library.GetBook(100); //Adult Book

            //Assert
            Assert.Equal($"{adultBook.Title} is unsuitable for children. The request to borrow it has been rejected", juniorMember.Borrow(adultBook));
        }
    }
}
