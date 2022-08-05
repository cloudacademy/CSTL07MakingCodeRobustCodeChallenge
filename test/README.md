# Making Code Robust Coding Challenge
In this challenge, there is no step-by-step guide and no hints. However, if you get really stuck, the full solution is located in the ```ModelSolutionIfYouNeedIt.Code``` project.

The challenge tasks you to restructure some code based around the library application you worked on in the previous challenge (in the Using Classes to Model Business Entities section). You may remember the app uses inheritance to cater for two kinds of library member, junior and adult. Junior members are under 16 years of age. Adult members are allowed to borrow any book from the library, whilst junior members can only borrow books from the Child category. In its current state, the LendingLibrary project has a base class called ‘Member’ that contains three abstract methods called ‘Borrow’, ‘PayFine’, and ‘NewFine’. The app also contains two specialised classes that inherit from Member called ‘AdultMember’ and ‘JuniorMember’, which implement the abstract methods of the base class.

The Visual Studio Code (VSC) solution has a console app project called ```LendingLibrary.UI``` and a unit test project called ```LendingLibrary.Tests```. Both projects contain similar logic that tests the ```LendingLibrary.Code``` project’s underlying functionality with four members called ‘gretaNoFine’ and ‘gretaWithFine’ (both junior members), and ‘donaldNoFine’ and ‘donaldWithFine’ (adult members).

# Task
Your job is to reengineer the logic so the Borrow method of the JuniorMember class raises an exception if the selected book is not suitable for children. You are also expected to add an XUnit test project to the solution and add a set of unit tests that ensure your enhancement works in all situations.

Note: The VSC solution already includes an XUnit test project, but this only includes tests for other features. None of them anticipate the throwing of exceptions.

1. Open the starter ```LendingLibrary.Code``` folder in the VSC environment. 

2. Locate the ```02 With Inheritance``` folder and open the JuniorMember class in the editor.

3. Take a look at the logic in the class’s Borrow method and alter it so that it throws an Exception with the following error message text if the book is not suitable for children:

```
"Bookname is unsuitable for children. The request to borrow it has been rejected".
```

__Note:__ Bookname should be replaced with the actual name of the book.

4. Add a XUnit test project to the solution and create a set of tests that ensures the code works as expected for adult only and child friendly books.
 

# To Run the Project
-  Select "Start Debugging" or "Run Without Debugging" from Visual Studio Code's "Run" menu or press F5 or Ctrl+F5
-  To interact with the console (and view the program's output) select the "Terminal" option from Visual Studio Code's View Menu (or press Ctrl+')  

# Execute Unit Tests
At any time you can invoke the unit tests that will be used to determine whether you have successfully completed the challenge by selecting the "Terminal" option from Visual Studio Code's View Menu (or pressing Ctrl+')) and running the following command:

```
dotnet test
```
If all the tests pass you will see a message (in green) that states <span style="color:green">"Passed!  - Failed:   0..."</span>. If any of the tests fail tou will see a message in red that states <span style="color:red">"Failed! - Failed:    n..."</span> where n indicates the number of tests that have failed. Note, initially there are two unit testing projects (```LendingLibraryFine.Tests``` and ```LendingLibraryMember.Tests```) one with 5 and the other with 15 unit tests which should all pass. When running the unit tests from within the terminal you may see a yellow message within the feedback that mentions the ```ModelSolutionIfYouNeedIt.Tests``` file which you can ignore.

<span style="color:red">__Note: It's not really possible to automatically test to see if there is a unit test that checks to see if an exception has been raised in the underlying code. So, when you click the "Submit Results" button in cloud academy it will __not__ check to ensure you completed step 4 above. However, it will check to ensure an exception is being raised at the appropriate time (as per step 3).__</span>  

# Model Solution (__but only if you need it__)
The code for a model solution can be found in the ```ModelSolutionIfYouNeedIt.Code``` and ```ModelSolutionIfYouNeedIt.Tests``` projects. 