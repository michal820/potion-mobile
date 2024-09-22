using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void Save()
    {
        GameData data  = saveGameLogic();
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(getPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static GameData Load()
    {
        Debug.Log(getPath());
        try
        {
            if (!File.Exists(getPath()))
            {
                //Debug.Log(getPath());
                GameData emptyData = new GameData();
                loadGameLogic(emptyData);
                Save();
                return emptyData;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(getPath(), FileMode.Open);
            GameData data = formatter.Deserialize(fs) as GameData;
            fs.Close();
            loadGameLogic(data);
            return data;
        }
        catch
        {
            GameData emptyData = new GameData();
            loadGameLogic(emptyData);
            Save();
            return emptyData;
        }

    }

    private static string getPath()
    {
        return Application.persistentDataPath + "/data.qnd";
    }


    private static GameData saveGameLogic()
    {
        GameData gameData = new GameData();

        gameData.seedsLeft = currentData.seedsLeft;
        gameData.plots = currentData.plots;

        gameData.ingredients = currentData.ingredients;
        gameData.flowerIngredients = currentData.flowerIngredients;
        gameData.cropIngredients = currentData.cropIngredients;
        gameData.bugIngredients = currentData.bugIngredients;
        gameData.greenIngredients = currentData.greenIngredients;
        gameData.rockIngredients = currentData.rockIngredients;
        gameData.specialIngredients = currentData.specialIngredients;
        gameData.organIngredients = currentData.organIngredients;

        gameData.failedAttempts = currentData.failedAttempts;
        gameData.potions = currentData.potions;

        gameData.hintsOwned = currentData.hintsOwned;
        gameData.landOwned = currentData.landOwned;
        gameData.toolsOwned = currentData.toolsOwned;
        gameData.fertilizers = currentData.fertilizers;

        return gameData;
    }
    private static void loadGameLogic(GameData gameData)
    {
        currentData.seedsLeft = gameData.seedsLeft;
        currentData.plots = gameData.plots;

        currentData.ingredients = gameData.ingredients;
        currentData.flowerIngredients = gameData.flowerIngredients;
        currentData.cropIngredients = gameData.cropIngredients;
        currentData.greenIngredients = gameData.greenIngredients;
        currentData.bugIngredients = gameData.bugIngredients;
        currentData.rockIngredients = gameData.rockIngredients;
        currentData.organIngredients = gameData.organIngredients;
        currentData.specialIngredients = gameData.specialIngredients;

        currentData.failedAttempts = gameData.failedAttempts;
        currentData.potions = gameData.potions;

        currentData.hintsOwned = gameData.hintsOwned;
        currentData.landOwned = gameData.landOwned;
        currentData.toolsOwned = gameData.toolsOwned;
        currentData.fertilizers = gameData.fertilizers;
    }


}
