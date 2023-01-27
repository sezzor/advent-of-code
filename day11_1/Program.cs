using day11_1;

string[] inputLines = File.ReadAllText("input.txt").Split('\n');
int round = 1;

List<Monkey> monkeys = new List<Monkey>();
// Test data
monkeys.Add(new Monkey(0, new List<Item> { 79, 98 },
19, 23, 2, 3));
monkeys.Add(new Monkey(1, new List<Item> { 54, 65, 75, 74 },
6, 19, 2, 0));
monkeys.Add(new Monkey(2, new List<Item> { 79, 60, 97 },
-1, 13, 1, 3));
monkeys.Add(new Monkey(3, new List<Item> { 74 },
3, 17, 0, 1));