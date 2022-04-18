using System; // using System means that we can use classes from the System namespace.
//A blank line. C# ignores white space. However, multiple lines makes the code more readable.
namespace HelloWorld //namespace is used to organize your code, and it is a container for classes and other namespaces.
{ // The curly braces {} marks the beginning and the end of a block of code.
  class Program // class is a container for data and methods, which brings functionality to your program. Every line of code that runs in C# must be inside a class. In our example, we named the class Program.
  {
    static void Main(string[] args) // Another thing that always appear in a C# program, is the Main method. Any code inside its curly brackets {} will be executed. You don't have to understand the keywords before and after Main. You will get to know them bit by bit while reading this tutorial.
    {
      Console.WriteLine("Hello World!");    /* Another thing that always appear in a C# program, is the Main method. 
      Any code inside its curly brackets {} will be executed. You don't have to understand the keywords before and after Main. You will get to know them bit by bit while reading this tutorial.
      If you omit the using System line, you would have to write System.Console.WriteLine() to print/output text. */
    }
  }

  /*

   - Every C# statement ends with a semicolon ;
   - C# is case-sensitive: "MyClass" and "myclass" has different meaning.
   - Unlike Java, the name of the C# file does not have to match the class name, but they often do (for better organization). 
     When saving the file, save it using a proper name and add ".cs" to the end of the filename.
   - Single line comment and multiple line comment

  */
}