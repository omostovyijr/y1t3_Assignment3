using Assignment_3;

bool isWorking = true;

while (isWorking)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Hello! This tool will help you to quickly find word in your .txt format dictionary.");
    Console.WriteLine("Please, enter destination to dictionary file:");
    string fileDestination = Console.ReadLine();
    var spinner = new Spinner(10, 10);
    spinner.Start();
    var dictionary = new StringsDictionary();
    foreach (var element in File.ReadAllLines(fileDestination))
    {
        string word = element.Split(new[] {';'}, StringSplitOptions.None)[0];
        string definition = null;
        bool contains = element.Contains("Defn: ");
        if (contains) definition = element.Split(new[] {"Defn: "}, StringSplitOptions.None)[1];
        if (contains != false)definition = element.Split(new[] {"; "}, StringSplitOptions.None)[1];
        dictionary.Add(word, definition);
    }
    spinner.Stop();
    
    Console.WriteLine("Now, please enter word to search:");
    string searchQuery = Console.ReadLine()?.ToUpper();
    Console.WriteLine(dictionary.Get(searchQuery));
    Console.WriteLine("Would you like to make one more search? Yes or No?");
    string oneMore = Console.ReadLine()?.ToUpper();
    if(oneMore == "No") isWorking = false;
}
