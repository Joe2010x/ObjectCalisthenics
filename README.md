# Salt Kata Series

## Kata 5 - Object Calisthenics

### A. Scenario

Being a software developer involves a lot of logical problem solving and being able to do that in a readable and well structured manner. You should also be able to test your logic to make sure it runs as expected even if you were to refactor your code or make additions to it.

> Calisthenics - exercises to achieve bodily fitness and grace of movement.

This your instructor me doing my body calisthenics

![Marcus ... in his dreams](https://30dayfitness.app/static/fbb138990d8874f11fc9d777635604ea/what-is-calisthenics.jpeg)

### B. What you will be working on

Today we will follow some very strict rules that will force us to write better OOP code. It will feel strange and hard in the beginning but be strict and use the rules as a tool for deeper understanding.

This kata will force you to follow many of the SOLID principles as you good. See if you can spot which principle you have used where. Reflect over how that principle helped you... or the opposite.

### C. Setup

Setup the kata as we have done with the other katas; a solution with two projects, one for test, one for production code.

### D. Lab instructions

#### TDD Rules

1. You can’t write production code without a failing test
1. You can’t have more than one failing test at a time
1. You can’t write a new test until your code is properly refactored

#### Object calisthenics rules

The instructions has been borrowed from [here](https://blog.avenuecode.com/object-calisthenics-principles-for-better-object-oriented-code), with this [introduction](https://williamdurand.fr/2013/06/03/object-calisthenics/):

> Object Calisthenics are programming exercises, formalized as a set of 9 rules invented by Jeff Bay in his book The ThoughtWorks Anthology. The word Object is related to Object Oriented Programming. The word Calisthenics is derived from greek, and means exercises under the context of gymnastics. By trying to follow these rules as much as possible, you will naturally change how you write code. It doesn’t mean you have to follow all these rules, all the time. Find your balance with these rules, use some of them only if you feel comfortable with t

Here are the rules:

1. Use only one level of indentation per method
1. Don’t use the else keyword
1. Wrap all primitives and strings
1. Use only one dot per line
1. Don’t abbreviate
1. Keep all entities small
1. Don’t use any classes with more than two instance variables
1. Use first-class collections
1. Don’t use any getters/setters/properties

#### The kata

Those are the rules - and the work can be any old kata, but we are going to do the Commodore 64 kata.

We are to develop an interpreter for (something similar to) Commodore 64 BASIC. Each story below is at least one test, but can be more than one.

- _Story:_ An empty program produces no output. Acceptance:

  ```text
  input:
  (empty)

  output:
  (empty)
  ```

- _Story:_ A bare “print” statement produces a single newline. Acceptance:

  ```text
  input:
  PRINT

  output:
  (a single newline)
  ```

- _Story:_ A “print” statement can have a constant string as an argument. The output is the constant string. Acceptance:

  ```text
  input:
  PRINT "Hello, World!"

  output:
  Hello, World!
  ```

- _Story:_ Two or more statements in a sequence are executed one after the other

  ```text
  input:
  PRINT "Hi"
  PRINT "There"
  PRINT "!"

  output:
  Hi
  There
  !
  ```

- _Story:_ The “print” statement can output number constants.

  ```text
  intput:
  PRINT 123

  output:
  123
  PRINT -3

  output:
  -3
  ```

- _Story:_ A single letter is a variable. The print statement can print its value. The default value for a is 0

  ```text
  input:
  PRINT A

  output:
  0
  ```

- _Story:_ An assignment statement binds a value to a variable.

  ```text
  input:
  A=12
  PRINT A

  output:
  12
  ```

- _Story:_ Two numeric constants can be added together.

  ```text
  input:
  PRINT 3 + 7

  output:
  10
  ```

- _Story:_ A numeric expression can have more than two terms.

  ```text
  input:
  PRINT 4 + 4 + 12
  output
  20
  ```

- _Story:_ A numeric expression can be built with variables and/or constants

  ```text
  input:
  A=2
  B=7
  PRINT A + 1
  PRINT A + B
  PRINT 99 + B

  output:
  3
  9
  106
  ```

- _Story:_ Two numeric expressions can be subtracted

  ```text
  input:
  PRINT 1 - 2

  output:
  -1
  ```

- _Story:_ Expressions can be parenthesized

  ```text
  input:
  PRINT 1 - (2 + 3)

  output:
  -4
  ```

### Tips

- Create a class called `Commodore64` with a method called `Interpret` that takes the input string and returns the output for each story above.

- Call the `Interpret` from the unit-tests.

- No need to add a console input feature for now, just get the functionality down.

- Good luck and have fun!
