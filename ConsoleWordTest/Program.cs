// settings (should be added to a config file)
using ConsoleWordTest;

string path = @"D:\input.txt";
int lengthWordSolution = 6;
List<string> list = new();

// check if file excist, otherwise throw error (should catch it to and handle it)

if(!File.Exists(path))
{
    throw new IOException("File does not excist on path: " + path);
}
else
{

    // Open the file to read from and add them to the right list
    foreach(string line in File.ReadAllLines(path))
    {
        // adding them to the list
        list.Add(line);
    }
}


// class with methods for the words
CompleteWords completeWords = new CompleteWords(list, path, lengthWordSolution);

// should place a scanner or sort of to allow enter a command
//completeWords.printResults();

do
{
    try
    {
        Console.WriteLine("Type '1' as command to print the results of the test, '2' to close the program:");
        int input = int.Parse(Console.ReadLine());
        switch(input)
        {
            case 1:
                completeWords.printResults();
                break;
            case 2:
                Console.WriteLine("Closing the app");
                Environment.Exit(1);
                break;
        }
        completeWords.printResults();

    }
    catch(Exception)
    {

        throw;
    }
} while(true);






