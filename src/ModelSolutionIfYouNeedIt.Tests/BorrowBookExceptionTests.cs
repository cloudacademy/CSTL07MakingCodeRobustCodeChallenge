using LendingLibrary;
using System;
using Xunit;

namespace LendingLibraryBorrowBookExceptionTests
{
    public class BorrowBookExceptionTests
    {
        Library library;
        Member gretaNoFine;
        Member georgeNoFine;

        Book childBook;
        Book adultBook;

        public BorrowBookExceptionTests()
        {
            library = new Library();

            gretaNoFine = library.Add(name: "Pippi Longstocking", age: 15);
            gretaNoFine.Street = "Queen Street";
            gretaNoFine.City = "Stockholm";

            georgeNoFine = library.Add(name: "George Bailey", age: 76);
            georgeNoFine.Street = "320 Sycamore Street";
            georgeNoFine.City = "Bedford Falls";

            childBook = library.GetBook(101);
            adultBook = library.GetBook(100);
        }

        //If you are looking in here because you are struggling with the task then you will need
        //to uncomment the three [Fact] attributes that decorate the methods below
        //[Fact]
        public void Child_Borrows_Child_Book_OK()
        {
            // a junior member (under 16) can borrow only child category books
            Assert.Equal($"{childBook.Title} successfully borrowed by {gretaNoFine.Name}", gretaNoFine.Borrow(childBook));
        }

        //[Fact]
        public void Child_Attempts_To_Borrow_Adult_Book_Fails()
        {
            // a junior member (under 16) can borrow only child category books
            Exception ex = Assert.Throws<Exception>(() => gretaNoFine.Borrow(adultBook));

            Assert.Equal($"{adultBook.Title} is unsuitable for children. The request to borrow it has been rejected", ex.Message);
        }

        //[Fact]
        public void Adult_Can_Borrow_Any_Book()
        {
            // a junior member (under 16) can borrow only child category books
            Assert.Equal($"{childBook.Title} successfully borrowed by {georgeNoFine.Name}", georgeNoFine.Borrow(childBook));
            Assert.Equal($"{adultBook.Title} successfully borrowed by {georgeNoFine.Name}", georgeNoFine.Borrow(adultBook));

        }
    }
}
