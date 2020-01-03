using System;

namespace TheHuman
{
    public class Program
    {
        public static void Main(string[] args)
            => new HumanClient().InitializeAsync().GetAwaiter().GetResult();
    }
}
