using System;
using System.Collections.Generic;

[Serializable]
public class ingredientSet
{
    private ingredient first;
    private ingredient second;
    private ingredient third;
    private ingredient[] thisList;
    private List<Potion> patternMatchs;
    public ingredientSet(ingredient one, ingredient two, ingredient three)
    {
        first = one;
        second = two;
        third = three;
        thisList  = new ingredient[] { one, two, three};
        patternMatchs = findPatternMatches();
    }
    private List<Potion> findPatternMatches()
    {
        bool samePattern = true;
        List<Potion> potionsWithSamePattern = new List<Potion>();
        foreach (Potion p in currentData.potions)
        {
            for (int i = 0; i < 3; i++)
            {
                if (p.getRecipe()[i].getType() != thisList[i].getType())
                {
                    samePattern = false;
                    break;
                }
                if (i == 2 && samePattern)
                {
                    potionsWithSamePattern.Add(p);
                }
            }
            samePattern = true;
        }
        return potionsWithSamePattern;
    }
    public ingredient getFirst()
    {
        return first;
    }
    public ingredient getSecond()
    {
        return second;
    }
    public ingredient getThird()
    {
        return third;
    }
    public ingredient[] getThisList()
    {
        return thisList;
    }
    public List<Potion> getPotionPatternMatch()
    {
        return patternMatchs;
    }
}
