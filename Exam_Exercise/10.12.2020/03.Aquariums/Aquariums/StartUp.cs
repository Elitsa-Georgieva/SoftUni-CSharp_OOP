using System.Collections.Generic;

namespace Aquariums
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var aquarium = new Aquarium("Aqui", 10);
            var fish1 = new Fish("Dori");
            var fish2 = new Fish("Nemo");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Console.WriteLine(aquarium.Report());
        }


    }
}
