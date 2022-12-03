// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var lowercaseLetters = Enumerable.Range('a','z').Select(c => (char)c).ToList();
var uppercaseLetters = Enumerable.Range('A','Z').Select(c => (char)c).ToList();
IDictionary<char, int> priorities = new Dictionary<char, int>();
int priority=1;
int sum = 0;
var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
foreach (var letter in letters) {
    priorities[letter] = priority++;
}
var input = File.ReadAllLines("input");

(string,string) Splitter(string input)
{
    int halfLength = input.Length /2;
    return (input[..halfLength],input[halfLength..]);
}
IEnumerable<char> Intersection ((string,string) sets)
{
    return sets.Item1.ToArray().Intersect(sets.Item2.ToArray());
}
IEnumerable<char> Intersection2 (string[] sets)
{
    return sets[0].ToArray().Intersect(sets[1].ToArray().Intersect(sets[2].ToArray()));
}
foreach (var line in input){
    var split = Splitter(line);
    Console.WriteLine(split);
    var intersection = Intersection(split);
    Console.WriteLine(new string(intersection.ToArray()));
    priority = intersection.Sum(a => priorities[a]);
    Console.WriteLine(priority);
    sum += intersection.Sum(a => priorities[a]);
}
Console.WriteLine(sum);
sum=0;
var chunked = input.Chunk(3);
foreach (var chunk in chunked){
    var intersection=Intersection2(chunk.ToArray());
    Console.WriteLine(string.Join("",intersection));
    sum += intersection.Sum(a => priorities[a]);
}
Console.WriteLine(sum);
