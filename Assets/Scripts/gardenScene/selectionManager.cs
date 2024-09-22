using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectionManager : MonoBehaviour
{
    public static GameObject toolSelectedObj;
    public static int toolSelectedInt;

    public GameObject tool1;
    public GameObject tool2;
    public GameObject tool3;
    private List<GameObject> tools;

    public static GameObject fertilizerSelectedObj;
    public static Fertilizer fertilizerSelected;
    private static List<GameObject> fertilizers;

    public static GameObject landSelectedObj;
    public static int landSelectedInt;

    public GameObject land1;
    public GameObject land2;
    public GameObject land3;
    private List<GameObject> lands;

    public Sprite landSelectOutline;
    public Sprite nothing;

    // Land listeners
    public GameObject seeds;
    public GameObject ferts;

    private void Awake()
    {
        fertilizers = new List<GameObject>();
        landSelectedInt = 1;
    }
    private void Start()
    {
        toolSelectedObj = null;
        fertilizerSelectedObj = null;
        fertilizerSelected = null;

        tools = new List<GameObject>();
        tools.Add(tool1);
        tools.Add(tool2);
        tools.Add(tool3);
        foreach (GameObject tool in tools)
        {
            deselectTool(tool);
        }

        lands = new List<GameObject>();
        lands.Add(land1);
        lands.Add(land2);
        lands.Add(land3);
        foreach(GameObject land in lands)
        {
            deselectLand(land);
        }
        //landSelectOutline = landSelectOutlineObj.GetComponent<Image>();
        landSelectedObj = land1;
        selectLand(land1,1);

    }
    public void selectTool(GameObject whichTool, int toolIndex)
    {
        deselectTool(toolSelectedObj);
        toolSelectedObj = whichTool;
        toolSelectedInt = toolIndex;
        //turn on the circle thing  that  shows its  selected
        whichTool.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
        //turn off  the circle thing for the other  tools
        //foreach (GameObject tool in tools)
        //{
        //    if (tool != whichTool)
        //        tool.SetActive(false);
        //}
    }
    public void deselectTool(GameObject whichTool)
    {
        if (whichTool != null)
        {
            whichTool.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
        }
        toolSelectedObj = null;
        toolSelectedInt = 0;
    }

    public void addFertilizer(GameObject f)
    {
        fertilizers.Add(f);
    }
    public void selectFertilizer(GameObject f)
    {
        if (fertilizerSelectedObj != null)
            fertilizerSelectedObj.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
        fertilizerSelectedObj = f;
        fertilizerSelectedObj.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);

        fertilizerSelected = f.GetComponent<fertilizerAttribute>().fert;

    }
    public void deselcectFertilizer(GameObject f)
    {
        f.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
        fertilizerSelectedObj = null;
        fertilizerSelected = null;
    }

    //due to layering issues in the hierarchy this needs to look different from deselectTool
    private void deselectLand(GameObject whichLand)
    {
        whichLand.GetComponent<Image>().enabled = false;
    }
    public void selectLand(GameObject whichLand, int landIndex)
    {
        deselectLand(landSelectedObj);
        whichLand.GetComponent<Image>().enabled = true;
        //whichLand.GetComponent<Image>().color = landSelectOutline.color;
        landSelectedObj = whichLand;
        landSelectedInt = landIndex;

        //notify listeners
        foreach (Transform childSeed in seeds.GetComponent<Transform>())
        {
            childSeed.GetComponent<seeds>().Start();
        }
        foreach (Transform childFert in ferts.GetComponent<Transform>())
        {
            childFert.GetComponent<fertilizerDrop>().refresh();
        }

    }
}
