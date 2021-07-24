using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReader : MonoBehaviour
{

    public RaycastHit hit;
    public Transform FilterContainer;
    public List<Transform> FilterChildren;
    public FilterConfig SelectedFilter;

    public void InitializeReader()
    {
        FilterContainer = FindObjectOfType<FilterButtonSpawner>().transform;
        for(int i = 0; i < FilterContainer.GetChild(0).childCount; i++)
        {
            FilterChildren.Add(FilterContainer.GetChild(0).GetChild(i));  
        }        
    }

    public void Update()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f);
        if (Input.GetMouseButtonDown(0) && hit.transform != null)
        {   
            switch(hit.transform.tag)
            {
                case "AlkaliMetals":
                case "AlkalineEarthMetals":
                case "Metalloids":
                case "NobleGases":
                case "PostTransitionMetals":
                case "ReactiveNonMetals":
                    RayCastHit(hit);
                    break;
                
                default:
                    print("Clicked on an invalid element");
                    break;
            }
        }
    }

    public void RayCastHit(RaycastHit ClickedObject)
    {        
        for(int i = 0; i < FilterContainer.GetChild(0).childCount; i++)
        {
            if (FilterContainer.GetChild(0).GetChild(i).CompareTag(ClickedObject.transform.tag))
            {
                SelectedFilter = FilterContainer.GetComponent<FilterButtonSpawner>().ReturnAllFilters()[i];
                break;
            }
        }
        StartCoroutine(FindObjectOfType<ElementSpawner>().SpawnElementsFiltered(SelectedFilter.ReturnElementsList(), SelectedFilter));
    }
}