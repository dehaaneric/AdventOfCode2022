namespace AdventOfCode2022.ConsoleApp.Day3
{
    public sealed class Rucksack
    {
        public Rucksack(ReadOnlySpan<char> compartment1, ReadOnlySpan<char> compartment2)
        {
            Compartment1 = compartment1.ToArray();
            Compartment2 = compartment2.ToArray();
        }
        public List<char> GetAll()
        {
            var list = new List<char>(Compartment1.Length + Compartment2.Length);
            
            list.AddRange(Compartment1);
            list.AddRange(Compartment2);

            return list;
        }

        public char[] Compartment1 { get; }
        public char[] Compartment2 { get; }

        public List<char> GetSharedItems()
        {
            var same = Compartment1.Intersect(Compartment2);
            return same.ToList();
        }
    }
}
