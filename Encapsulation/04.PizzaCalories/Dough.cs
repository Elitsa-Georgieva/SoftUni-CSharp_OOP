using System;

namespace _04.PizzaCalories
{
    public class Dough
    {
        //private const int MinWeight = 1;
        //private const int MaxWeight = 200;
        //private const string InvalidDoughEcxeptionMessage = "Invalid type of dough";

        //private string flourType;
        //private string bakingTechnique;
        //private int weight;

        //public Dough(string flourType, string bakingTechnique, int weight)
        //{
        //    this.FlourType = flourType;
        //    this.BakingTechnique = bakingTechnique;
        //    this.Weight = weight;
        //}

        //public string FlourType
        //{
        //    get => this.flourType;
        //    set
        //    {
        //        var valueAsLower = value.ToLower();

        //        if (valueAsLower != "white" && valueAsLower != "wholegrain")
        //        {
        //            throw new ArgumentException(InvalidDoughEcxeptionMessage);
        //        }

        //        this.flourType = value;
        //    }
            
        //}

        //public string BakingTechnique
        //{
        //    get => this.bakingTechnique;
        //    private set
        //    {
        //        var valueAsLower = value.ToLower();

        //        if (valueAsLower != "chewy" && valueAsLower != "crispy" && valueAsLower != "homemade")
        //        {
        //            throw new ArgumentException(InvalidDoughEcxeptionMessage);
        //        }

        //        this.bakingTechnique = value;
        //    }
        //}

        //public int Weight
        //{
        //    get => this.weight;
        //    private set
        //    {
        //        Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value,
        //            $"Dough weight should be in the range[{MinWeight}...{MaxWeight}].");

        //        this.weight = value;
        //    }
        //}


        //public double GetCalories()
        //{
        //    var flourTypeModifier = GetFlourModifier();
        //    var bakingTechniqueModifier = GetBackingTechniqueModifier();

        //    return this.weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        //}

        //private double GetBackingTechniqueModifier()
        //{
        //    var backingTechniqueLower = this.bakingTechnique.ToLower();
        //        //•	Crispy - 0.9;
        //        //•	Chewy - 1.1;
        //        //•	Homemade - 1.0;

        //        if (backingTechniqueLower == "crispy")
        //        {
        //            return 0.9;
        //        }

        //        if (backingTechniqueLower == "chewy")
        //        {
        //            return 1.1;
        //        }

        //        return 1.0;
        //}

        //private double GetFlourModifier()
        //{
        //    var flourTypeLower = this.FlourType.ToLower();
        //    if (flourTypeLower == "white")
        //    {
        //        return 1.5;
        //    }

        //    return 1;

        //}
    }
}
