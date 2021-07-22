using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterButton : MonoBehaviour
{
    [SerializeField] public FilterConfig ElementsToFilter;
    public FilterConfig ReturnElementsToFilter()
    {
        return ElementsToFilter;
    }
}