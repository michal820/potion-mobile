using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//removed static
[Serializable]
public class GameData
{
    //removed ALL the statics  lol
    public int seedsLeft { get; set; }
    public const int maxFields = 10;
    public const int numOfPlotsPerField = 12;

    public Plot[,] plots;

    public List<ingredient> ingredients;
    public List<ingredient> flowerIngredients;
    public List<ingredient> cropIngredients;
    public List<ingredient> greenIngredients;
    public List<ingredient> bugIngredients;
    public List<ingredient> rockIngredients;
    public List<ingredient> organIngredients;
    public List<ingredient> specialIngredients;


    public List<ingredientSet> failedAttempts;
    public List<Potion> potions;
    public int hintsOwned;
    public int landOwned;
    public int toolsOwned;
    public List<Fertilizer> fertilizers;


    public GameData()
    {
        seedsLeft = 10;
        plots = new Plot[maxFields, numOfPlotsPerField];
        for (int i = 0; i < maxFields; i++)
        {
            for (int j = 0; j < numOfPlotsPerField; j++)
            {
                plots[i, j] = new Plot(); // Assuming Plot has a parameterless constructor
            }
        }

        ingredients = new List<ingredient>();
        initializeIngredients();
        //scaleRarity();
        initializeSpecificIngrLists();
      

        failedAttempts = new List<ingredientSet>();

        potions = new List<Potion>();
        initializePotions();

        fertilizers = new List<Fertilizer>();
        initializeFertilizers();
        hintsOwned = 0;
        landOwned = 0;
        toolsOwned = 0;

        //for debugging:
        potions[1].setAmountOwned(0);
        potions[3].setAmountOwned(0);
        potions[7].setAmountOwned(0);
        potions[8].setAmountOwned(0);
        potions[10].setAmountOwned(0);
    }


    private void initializeIngredients()
    {
        //name,  sprite,  type,  rarity, growtime
        ingredients.Add(new ingredient("lavender", "Ingredients_0", "flower", 7, 3));
        ingredients.Add(new ingredient("pink daisy", "Ingredients_1", "flower",7, 3));
        ingredients.Add(new ingredient("neon lotus", "Ingredients_2", "flower",6 ,3));
        ingredients.Add(new ingredient("sprout", "Ingredients_3", "green", 7, 3));
        ingredients.Add(new ingredient("clover", "Ingredients_4", "green",6, 3));
        ingredients.Add(new ingredient("sunflower", "Ingredients_5", "flower", 5, 3));
        ingredients.Add(new ingredient("finger", "Ingredients_6", "organ", 2, 3));
        ingredients.Add(new ingredient("tooth", "Ingredients_7", "organ", 2, 3));
        ingredients.Add(new ingredient("eye plant", "Ingredients_8", "organ", 1, 3));
        ingredients.Add(new ingredient("fireflower", "Ingredients_9", "special", 3, 3));
        ingredients.Add(new ingredient("tulip", "Ingredients_10", "flower", 5, 3));
        ingredients.Add(new ingredient("wheat", "Ingredients_11", "crop", 5, 3));
        ingredients.Add(new ingredient("mistletoe", "Ingredients_12", "flower", 3, 10));
        ingredients.Add(new ingredient("carrot", "Ingredients_13", "crop", 5, 10));
        ingredients.Add(new ingredient("potato", "Ingredients_14", "crop", 5, 10));
        ingredients.Add(new ingredient("ladybug", "Ingredients_15", "bug", 3, 10));
        ingredients.Add(new ingredient("bee", "Ingredients_16", "bug", 4, 10));
        ingredients.Add(new ingredient("fly", "Ingredients_17", "bug", 5, 10));
        ingredients.Add(new ingredient("coffee plant", "Ingredients_18", "special", 4, 10));
        ingredients.Add(new ingredient("tounge", "Ingredients_19", "organ", 2, 10));
        ingredients.Add(new ingredient("earth worm", "Ingredients_20", "bug", 6, 10));
        ingredients.Add(new ingredient("green lotus", "Ingredients_21", "flower", 6, 10));
        ingredients.Add(new ingredient("diamond", "Ingredients_22", "rock", 4, 10));
        ingredients.Add(new ingredient("round worm", "Ingredients_23", "bug", 4,  10));
        ingredients.Add(new ingredient("berries", "Ingredients_24", "crop", 6, 10));
        ingredients.Add(new ingredient("grass", "Ingredients_25", "green", 7, 10));
        ingredients.Add(new ingredient("basic rock", "Ingredients_26", "rock",  7, 10));
        ingredients.Add(new ingredient("centipede", "Ingredients_27", "bug",  4, 10));
        ingredients.Add(new ingredient("snail", "Ingredients_28", "bug", 3, 10));
        ingredients.Add(new ingredient("seashell", "Ingredients_29", "rock", 1, 10));
        ingredients.Add(new ingredient("fern", "Ingredients_30", "green", 4, 10));
        ingredients.Add(new ingredient("giant leafy", "Ingredients_31", "green", 4, 10));

    }

    private void initializeSpecificIngrLists()
    {
        flowerIngredients = new List<ingredient>();
        cropIngredients = new List<ingredient>();
        bugIngredients = new List<ingredient>();
        greenIngredients = new List<ingredient>();
        rockIngredients = new List<ingredient>();
        organIngredients = new List<ingredient>();
        specialIngredients = new List<ingredient>();


        foreach (ingredient i in ingredients)
        {
            switch (i.getType())
            {
                case ("flower"):
                    {
                        flowerIngredients.Add(i);
                        break;
                    }
                case ("crop"):
                    {
                        cropIngredients.Add(i);
                        break;
                    }
                case ("green"):
                    {
                        greenIngredients.Add(i);
                        break;
                    }
                case ("bug"):
                    {
                        bugIngredients.Add(i);
                        break;
                    }
                case ("rock"):
                    {
                        rockIngredients.Add(i);
                        break;
                    }
                case ("organ"):
                    {
                        organIngredients.Add(i);
                        break;
                    }
                case ("special"):
                    {
                        specialIngredients.Add(i);
                        break;
                    }
            }
        }
    }

    private void scaleRarity()
    {
        foreach (ingredient i in ingredients)
        {
            i.setRarity(i.getRarity() ^ 2);
        }
    }

    private void initializePotions()
    {
        ingredient[] recipe = new ingredient[3] {ingredients[3], ingredients[3], ingredients[3] };
        potions.Add(new Potion("Potions_0", recipe));
        recipe = new ingredient[3] { ingredients[0], ingredients[1], ingredients[2] };
        potions.Add(new Potion("Potions_1", recipe));
        recipe = new ingredient[3] { ingredients[16], ingredients[5], ingredients[21] };
        potions.Add(new Potion("Potions_2", recipe));
        recipe = new ingredient[3] { ingredients[30], ingredients[18], ingredients[31] };
        potions.Add(new Potion("Potions_3", recipe));
        recipe = new ingredient[3] { ingredients[29], ingredients[22], ingredients[0] };
        potions.Add(new Potion("Potions_4", recipe));
        recipe = new ingredient[3] { ingredients[9], ingredients[19], ingredients[6] };
        potions.Add(new Potion("Potions_5", recipe));
        recipe = new ingredient[3] { ingredients[12], ingredients[17], ingredients[26] };
        potions.Add(new Potion("Potions_6", recipe));
        recipe = new ingredient[3] { ingredients[22], ingredients[0], ingredients[27] };
        potions.Add(new Potion("Potions_7", recipe));
        recipe = new ingredient[3] { ingredients[23], ingredients[27], ingredients[20] };
        potions.Add(new Potion("Potions_8", recipe));
        recipe = new ingredient[3] { ingredients[1], ingredients[10], ingredients[1] };
        potions.Add(new Potion("Potions_9", recipe));
        recipe = new ingredient[3] { ingredients[14], ingredients[0], ingredients[11] };
        potions.Add(new Potion("Potions_10", recipe));
        recipe = new ingredient[3] { ingredients[7], ingredients[8], ingredients[11] };
        potions.Add(new Potion("Potions_11", recipe));
        recipe = new ingredient[3] { ingredients[3], ingredients[4], ingredients[25] };
        potions.Add(new Potion("Potions_12", recipe));
        recipe = new ingredient[3] { ingredients[28], ingredients[2], ingredients[26] };
        potions.Add(new Potion("Potions_13", recipe));
    }

    //FertilizerType type, string name, string description, int price, string spriteName, string colorOrText 
    private void initializeFertilizers()
    {
        fertilizers.Add(new Fertilizer(FertilizerType.RareRarity, "Rarity Fertilizer - Rare", "increases chance of growing a rare ingredient by 80%", 5, "RarityBag", "#B45E28" ));
        fertilizers.Add(new Fertilizer(FertilizerType.EpicRarity, "Rarity Fertilizer - Epic", "increases chance of growing an epic ingredient by 80%", 5, "RarityBag", "#839098"));
        fertilizers.Add(new Fertilizer(FertilizerType.LegendaryRarity, "Rarity Fertilizer - Legendary", "increases chance of growing a legendary ingredient by 80%", 5, "RarityBag", "#DDC65F"));

        fertilizers.Add(new Fertilizer(FertilizerType.TwoxSpeed,"Speed Fertilizer - 2x","your ingredients will  grow twice as fast",5, "SpeedBag", "2x"));
        fertilizers.Add(new Fertilizer(FertilizerType.FivexSpeed,"Speed Fertilizer - 5x", "your ingredients will  grow five times as fast", 5, "SpeedBag","5x"));
        fertilizers.Add(new Fertilizer(FertilizerType.TenxSpeed, "Speed Fertilizer - 10x", "your ingredients will grow ten times as fast", 5, "SpeedBag","10x"));

        fertilizers.Add(new Fertilizer(FertilizerType.FlowerType,"Species Fertilizer - Flowers","you are 80% more likely to grow a flower",5, "SpeciesBag", "#D175AA"));
        fertilizers.Add(new Fertilizer(FertilizerType.CropType, "Species Fertilizer - Crops", "you are 80% more likely to grow a crop", 5, "SpeciesBag", "#F8CC55"));
        fertilizers.Add(new Fertilizer(FertilizerType.GreenType, "Species Fertilizer - Greens", "you are 80% more likely to grow a green", 5, "SpeciesBag", "#80AB11"));
        fertilizers.Add(new Fertilizer(FertilizerType.BugType, "Species Fertilizer - Bugs", "you are 80% more likely to grow a bug", 5, "SpeciesBag", "#9D7BAB"));
        fertilizers.Add(new Fertilizer(FertilizerType.RockType, "Species Fertilizer - Rocks", "you are 80% more likely to grow a rock", 5, "SpeciesBag", "#7AA9CC"));
        fertilizers.Add(new Fertilizer(FertilizerType.OrganType, "Species Fertilizer - Organs", "you are 80% more likely to grow an organ", 5, "SpeciesBag", "#A63831"));
        fertilizers.Add(new Fertilizer(FertilizerType.SpecialType, "Species Fertilizer - Special", "you are 80% more likely to grow a special item", 5, "SpeciesBag", "#907B6A"));

    }
}
