using System;

namespace clipr.Sample
{
    public class FluentWithVerb
    {
        public class VerbTestOptions
        {
            public int NumCounters { get; set; }

            public VerbSubOptions AddInfo { get; set; }
        }

        public class VerbSubOptions
        {
            public string Filename { get; set; }
        }

        public static void Main(string[] args)
        {
            var opt = new VerbTestOptions();
            new CliParserBuilder<VerbTestOptions>()
                .HasNamedArgument(c => c.NumCounters)
                .WithShortName()
            .And
                .HasVerb("add", c => c.AddInfo,
                         new CliParserBuilder<VerbSubOptions>()
                             .HasPositionalArgument(c => c.Filename).And)
            .And.Parser
                .Parse(args, opt);

            Console.WriteLine("Number of counters: {0}", opt.NumCounters);  // 3
            Console.WriteLine("File name to add: {0}", opt.AddInfo.Filename);  // oranges.txt
        }
    }
}