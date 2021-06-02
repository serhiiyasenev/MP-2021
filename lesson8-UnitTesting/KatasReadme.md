## Recently Used List

Develop a recently-used-list class to hold strings
uniquely in Last-In-First-Out order.

- The most recently added item is first, the least
  recently added item is last.

- Items can be looked up by index, which counts from zero.

- Items in the list are unique, so duplicate insertions
  are moved rather than added.

- A recently-used-list is initially empty.

Optional extras:

- Null insertions (empty strings) are not allowed.

- A bounded capacity can be specified, so there is an upper
  limit to the number of items contained, with the least
  recently added items dropped on overflow.
	   
See [a video tutorial showing how to solve this kata in Python](http://medrela.com/rul-kata).
	 
More tests:
	
- While getting items by index, supplied index-value should be within the bounds of List [eg.
  if maximum item counts of list is 5 then supplied index is less than 4 as index starts from 0 (zero)]
- Negative index value not allowed [>0]
- Size limit is must if not supplied make 5 as default [0-4]
- List can be non-sizable means without upper limit list can be created [Hint-try property or constructor initializers]

## String Sum Kata 

* Write a simple String Sum utility with a function <em>string Sum(string num1, string num2)</em>, which can accept only natural numbers and will return their sum. Replace entered number with <em>0 (zero)</em> if entered number is not a natural number.
* Stat with a simplest test case with an empty string
* Create a simple method <em>string Sum(string num1, string num2)</em>
* Write a test to pass small numbers and refactor, if test passed
* try to write more code and refactor


## String Calculator Kata (via [Roy Osherove](http://osherove.com/tdd-kata-1/))

* Create a simple String calculator with a method int Add(string numbers). The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0). For example "" or "1" or "1,2"
	* Start with the simplest test case of an empty string and move to 1 and two numbers
	* Remember to solve things as simply as possible so that you force yourself to write tests you did
		  not think about
	* Remember to refactor after each passing test
* Allow the Add method to handle an unknown amount of numbers
* Allow the Add method to handle new lines between numbers (instead of commas).
	* the following input is ok:  "1\n2,3"  (will equal 6)
	* the following input is NOT ok:  "1,\n" (not need to prove it - just clarifying)
* Support different delimiters. To change a delimiter, the beginning of the string will contain a separate line that looks like this: `[delimiter]\n[numbers...]`, for example `;\n1;2` should return three where the default delimiter is `;` .
	* he first line is optional. all existing scenarios should still be supported
* Calling Add with a negative number will throw an exception "negatives not allowed" - and the negative that was passed.
	* if there are multiple negatives, show all of them in the exception message


### The Bowling Game Kata ([via Uncle Bob](http://butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata))
	- Create a new project or start in the existing project by adding Game.cs and TestGame.cs
	- Create two public methods methods [refer to the presentation file]
	- Create Test Methods for the above Methods
	- This is called a 'RED' Test as it is going to fail.
	- Rectified both test and class methods
	- Write new test
	- This is called a 'Green' Test as it is going to pass.
	- Rectified TestMethods to meet total 20 frames hit.
	- Rectified test to accept multiple frame and pins
	- Test 3 is a 'Red' test
	- Test 4 and 5 are 'Green'
	- All test passed
	- Still there is scope of refactoring

### The FizzBuzz Kata
	- Write a program that prints the numbers from 1 to 100. But for multiples of three print "Fizz"
	  instead of the number and for the multiples of five print "Buzz". For numbers which are multiples of both
	  three and five print "FizzBuzz".

### Including new implementation to The FizzBuzz Kata
	- Added a different implementation for FizzBuzz using Reactive extensions.
	- The changes are described at: http://blog.drorhelper.com/2015/02/fizzbuzz-tdd-kata-using-reactive.html
	- Pull Request by: https://github.com/dhelper (manually merged by @garora)
	  

#### Steps:

	Lets divide this into different steps so, we can easily write and test this.
	- Print numbers from 1 to 100
	- Print "Fizz" instead of number which is divisible by 3
	- Print "Buzz" instead of number which is divisible by 5
	- Print "FizzBuzz" instead of number which is divisible by both 3 and 5

#### Make more test for accept numbers and provide results
	- Create a method to accept single number
	- Create test to verify supplied number within the range 1 to 100
	- Create test to verify number and return result Fizz or Buzz or FizzBuzz per above criteria
