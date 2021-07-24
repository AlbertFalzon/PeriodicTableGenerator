using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Filter Config")]

public class FilterConfig : ScriptableObject
{
    [SerializeField] string CategoryName;
    [SerializeField] string BlockColour;
    [SerializeField] float xpos;
    [SerializeField] float ypos;
    [SerializeField] string TagName;
    [SerializeField] int[] ElementsList;
    [SerializeField] float[] FilteredXPos;
    [SerializeField] float[] FilteredYPos;

    public int[] ReturnElementsList()
    {
        return ElementsList;
    }

    public string ReturnCategoryName()
    {
        return CategoryName;
    }

    public Color ReturnBlockColour()
    {
        Color ConvertedHex;
        if (ColorUtility.TryParseHtmlString(BlockColour, out ConvertedHex))
        {
            return ConvertedHex;
        } else
        {
            return Color.black;
        }
    }

    public float ReturnXpos()
    {
        return xpos;
    }

    public float ReturnYpos()
    {
        return ypos;
    }

    public string ReturnTagName()
    {
        return TagName;
    }

    public float[] ReturnFilteredXPos()
    {
        return FilteredXPos;
    }

    public float[] ReturnFilteredYPos()
    {
        return FilteredYPos;
    }
}
