//using System;
//using System.Collections.Generic;

//namespace LendingLibrary
//{
//    public class Member
//    {
//        public string Name { get; }
//        public int MembershipNumber { get; }
//        public int Age { get; }

//        public string Street { get; set; }
//        public string City { get; set; }
//        // if outstanding fines is -'ve account is in credit
//        // if outstanding fines is +'ve there are still fines that need paying
//        public decimal OutstandingFines { get; private set; }

//        public static decimal ChildOutstandingFineLimit { get; private set; } = 15.00M;

//        public Member(string name, int age, int membershipNumber)
//        {
//            this.Name = name;
//            this.Age = age;
//            this.MembershipNumber = membershipNumber;
//        }

//        public bool Borrow(Book book)
//        {
//            if (Age >= 16)
//            {
//                return true;
//            }
//            else
//            {
//                return (book.Category == BookCategory.Children);
//            }
//        }

//        public void PayFine(decimal fine)
//        {
//            if (Age < 16)
//            {
//                if (fine > ChildOutstandingFineLimit)
//                    fine = ChildOutstandingFineLimit;
//            }
//            //No FineLimit for adults
//            OutstandingFines -= fine;

//        }

//        public void NewFine(decimal fine) // Fine needs to be added to any existing fines
//        {
//            if (Age < 16) //Maximum outstanding fine for children  which they should not exceed
//            {
//                if (ChildOutstandingFineLimit <= (fine + OutstandingFines))
//                {
//                    OutstandingFines = ChildOutstandingFineLimit;
//                    return;
//                }
//            }

//            OutstandingFines += fine;
//        }
//    }
//}