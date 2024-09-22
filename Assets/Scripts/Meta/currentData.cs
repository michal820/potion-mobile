using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class currentData {
    public static int seedsLeft { get; set; }

    public static Plot[,] plots;

    public static List<ingredient> ingredients;
    public static List<ingredient> flowerIngredients;
    public static List<ingredient> cropIngredients;
    public static List<ingredient> greenIngredients;
    public static List<ingredient> bugIngredients;
    public static List<ingredient> rockIngredients;
    public static List<ingredient> organIngredients;
    public static List<ingredient> specialIngredients;

    public static List<ingredientSet> failedAttempts;

    public static List<Potion> potions;

    public static int hintsOwned;
    public static int landOwned;
    public static int toolsOwned;

    public static List<Fertilizer> fertilizers;
    
}
