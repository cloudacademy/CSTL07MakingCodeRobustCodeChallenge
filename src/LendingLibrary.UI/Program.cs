using LendingLibrary;
using System;

namespace LendingLibraryUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library;
            Member dracoWithFine;
            Member gretaNoFine;
            Member donaldWithFine;
            Member georgeNoFine;

            library = new Library();
            dracoWithFine = library.Add(name: "Draco Malfoy", age: 15);
            dracoWithFine.Street = "Malfoy Manor";
            dracoWithFine.City = "Wiltshire";
            dracoWithFine.NewFine(6M);

            gretaNoFine = library.Add(name: "Pippi Longstocking", age: 15);
            gretaNoFine.Street = "Queen Street";
            gretaNoFine.City = "Stockholm";

            donaldWithFine = library.Add(name: "Donald Trump with Fine", age: 76);
            donaldWithFine.Street = "Hicksville";
            donaldWithFine.City = "Arizona";
            donaldWithFine.NewFine(30M);

            georgeNoFine = library.Add(name: "George Bailey", age: 76);
            georgeNoFine.Street = "320 Sycamore Street";
            georgeNoFine.City = "Bedford Falls";

            Console.WriteLine($"library contains {library.NumberOfMembers} members");
            Console.WriteLine($"{dracoWithFine.Name}'s membership number is {dracoWithFine.MembershipNumber}");
            Console.WriteLine($"{gretaNoFine.Name}'s membership number is {gretaNoFine.MembershipNumber}");
            Console.WriteLine($"{donaldWithFine.Name}'s membership number is {donaldWithFine.MembershipNumber}");
            Console.WriteLine($"{georgeNoFine.Name}'s membership number is {georgeNoFine.MembershipNumber}");
 
            //Book Code 100: "Walls have ears", BookCategory.Adult
            //Book Code 101: "Noddy goes to Toytown", BookCategory.Children
            Book childBook = library.GetBook(101);
            Book adultBook = library.GetBook(100);

            // a junior member (under 16) can borrow only child category books
            string confirmMessage = gretaNoFine.Borrow(childBook);
            Console.WriteLine(confirmMessage);

            // a junior member (under 16) can borrow only child category books
            //NOTE: the following code will crash when code in JuniorMember class is altered to throw an Exception.
            confirmMessage = gretaNoFine.Borrow(adultBook);
            Console.WriteLine(confirmMessage);

            // an adult member (>= 16) can borrow child category books
            confirmMessage = georgeNoFine.Borrow(childBook);
            Console.WriteLine(confirmMessage);
            confirmMessage = georgeNoFine.Borrow(adultBook);
            Console.WriteLine(confirmMessage);

            // Child_Pays_Fine_From_Cash_Fund
            decimal payment = 7M;
            decimal expectedBalance = dracoWithFine.OutstandingFines - payment;
            Console.WriteLine($"{dracoWithFine.Name} currently owes {dracoWithFine.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
            dracoWithFine.PayFine(payment);
            Console.WriteLine($"After paying in {payment:C}, {dracoWithFine.Name} now owes {dracoWithFine.OutstandingFines:C} in outstanding fines"); // negative if member is in credit

            //Child_Incurs_Fine_That_Exceeds_limit
            //Note: FineLimit is a static readonly property set to a default value of 15.00
            decimal fine = 17M;
            expectedBalance = JuniorMember.OutstandingFineLimit; //Note: OutstandingFineLimit is a static readonly property set to a default value of 15.00

            Console.WriteLine($"{dracoWithFine.Name} currently owes {dracoWithFine.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
            dracoWithFine.NewFine(fine); //child fine 's are capped so only £15 needs to be paid
            Console.WriteLine($"After incurring a {fine:C} fine, {dracoWithFine.Name} now owes {dracoWithFine.OutstandingFines:C} in outstanding fines"); // negative if member is in credit

            //Adult_Pays_Fine
            //Note: There is no fine limit for adults
            payment = 17M;
            expectedBalance = donaldWithFine.OutstandingFines - payment;
            Console.WriteLine($"{donaldWithFine.Name} currently owes {donaldWithFine.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
            donaldWithFine.PayFine(payment);
            Console.WriteLine($"After paying in {payment:C}, {donaldWithFine.Name} now owes {donaldWithFine.OutstandingFines:C} in outstanding fines"); // negative if member is in credit

            //Adult_Incurs_Fine_That_Exceeds_limit
            //Note: There is no fine limit for adults
            fine = 17M;
            expectedBalance = donaldWithFine.OutstandingFines + fine;
            Console.WriteLine($"{donaldWithFine.Name} currently owes {donaldWithFine.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
            donaldWithFine.NewFine(fine);
            Console.WriteLine($"After incurring a {fine:C} fine, {donaldWithFine.Name} now owes {donaldWithFine.OutstandingFines:C} in outstanding fines"); // negative if member is in credit
        }
    }
}
