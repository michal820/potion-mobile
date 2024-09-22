using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fertilizerDrop : MonoBehaviour
{
    public int fertID;
    private SpriteRenderer srend;
    private Plot plot;
    // Start is called before the first frame update
    void Start()
    {
        srend = gameObject.GetComponent<SpriteRenderer>();
        refresh();
    }

    public void refresh()
    {
        plot = currentData.plots[selectionManager.landSelectedInt, fertID];
        Fertilizer plotFert = plot.GetFertilizer();

        if (plotFert != null)
        {
            srend.enabled = true;
            string hexColor = plotFert.getColorOrText();
            Color color;
            ColorUtility.TryParseHtmlString(hexColor, out color);
            srend.color = color;
        }
        else
            srend.enabled = false;
    }

}
