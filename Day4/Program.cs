// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var lines = File.ReadAllLines("input");
int containedSets =0;
int overlaps = 0;
foreach (var line in lines){
    var pairs = line.Split(",");
    IEnumerable<string[]> ranges = new List<string[]>();
    ranges = pairs.Select(pairs => pairs.Split("-"));
    if (FullyContained(ranges)) Console.WriteLine("Fully contained");
    else Console.WriteLine("Not contained");
    if (Overlap(ranges)) Console.WriteLine("Overlap");
}

bool FullyContained(IEnumerable<string[]> ranges){
    var numbers1 = ranges.First().Select(n => Int32.Parse(n)).ToArray();
    var range1 = Enumerable.Range(numbers1[0],numbers1[1]+1-numbers1[0]);
    Console.WriteLine(string.Join(" ",numbers1.Select(n=>n.ToString())));
    var numbers2 = ranges.Last().Select(n => Int32.Parse(n)).ToArray();
    var range2 = Enumerable.Range(numbers2[0],numbers2[1]+1-numbers2[0]);
    Console.WriteLine(string.Join(" ",numbers2.Select(n=>n.ToString())));
    HashSet<int> set1 = new HashSet<int>(range1);
    HashSet<int> set2 = new HashSet<int>(range2);
    var fullyContained = set1.IsSubsetOf(set2) | set2.IsSubsetOf(set1);
    if (fullyContained) containedSets += 1;
    return fullyContained;
}

bool Overlap(IEnumerable<string[]> ranges) {
    var numbers1 = ranges.First().Select(n => Int32.Parse(n)).ToArray();
    var range1 = Enumerable.Range(numbers1[0],numbers1[1]+1-numbers1[0]);
    Console.WriteLine(string.Join(" ",numbers1.Select(n=>n.ToString())));
    var numbers2 = ranges.Last().Select(n => Int32.Parse(n)).ToArray();
    var range2 = Enumerable.Range(numbers2[0],numbers2[1]+1-numbers2[0]);
    Console.WriteLine(string.Join(" ",numbers2.Select(n=>n.ToString())));
    HashSet<int> set1 = new HashSet<int>(range1);
    HashSet<int> set2 = new HashSet<int>(range2);
    var overlap = set1.Intersect(set2).Any();
    if (overlap) overlaps += 1;
    return overlap;
}
Console.WriteLine(containedSets);
Console.WriteLine(overlaps);