using System.Linq;

namespace AdventOfCode2022.ConsoleApp.Day3
{
    public sealed class Day3Tasks
    {
        public int GetTotalValueTask1()
        {
            List<Rucksack> rucksacks = GetRucksacks();

            int total = 0;

            foreach (var r in rucksacks)
            {
                var x = r.GetSharedItems();

                int subTotal = 0;
                foreach (var c in x)
                {
                    subTotal += AsciiHelper.GetPuzzleAsciiValue(c);
                }

                total += subTotal;
            }

            return total;
        }

        public int GetTotalValueTask2()
        {
            List<Rucksack> rucksacks = GetRucksacks();
            int totalItems = rucksacks.Count;
            const int itemsPerBatch = 3;
            int totalBatches = totalItems / itemsPerBatch;

            var groupedRucksacks = new List<List<Rucksack>>(totalBatches);

            int total = 0;
            for (int batchIndex = 0; batchIndex < totalBatches; batchIndex++)
            {
                IEnumerable<Rucksack> batchedRucksacks 
                    = rucksacks.Skip(batchIndex * itemsPerBatch).Take(itemsPerBatch);

                IEnumerable<List<char>> listOfLists = batchedRucksacks.Select(x => x.GetAll());

                var intersection = listOfLists
                        .Skip(1)
                        .Aggregate(
                            new HashSet<char>(listOfLists.First()),
                            (h, e) => { h.IntersectWith(e); return h; }
                        );

                foreach(var c in intersection)
                {
                    total += AsciiHelper.GetPuzzleAsciiValue(c);
                }
            }

            return total;
        }


        public List<Rucksack> GetRucksacks()
        {
            string[] inputs = GetInputDay3();

            var rucksacks = new List<Rucksack>();

            foreach (var bothCompartments in inputs)
            {
                var span = bothCompartments.AsSpan();

                int compartmentLength = span.Length;
                if (compartmentLength < 2)
                    continue;

                int itemsPerCompartment = compartmentLength / 2;

                var compartment1 = span.Slice(0, itemsPerCompartment);
                var compartment2 = span.Slice(itemsPerCompartment, itemsPerCompartment);

                var rucksack = new Rucksack(compartment1, compartment2);
                rucksacks.Add(rucksack);
            }

            return rucksacks;
        }

        private static string[] GetInputDay3()
        {
            return File.ReadAllLines("Day3/Day3Input.txt");
        }

    }
}
