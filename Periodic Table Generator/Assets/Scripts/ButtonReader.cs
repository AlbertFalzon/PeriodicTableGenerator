using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReader : MonoBehaviour
{

    public RaycastHit hit;
    public Transform FilterContainer;
    public ElementSpawner ElementsContainer;
    public List<Transform> FilterChildren;
    public FilterConfig SelectedFilter;
    public string CurrentFilter = "Untagged";

    public void InitializeReader()
    {
        FilterContainer = FindObjectOfType<FilterButtonSpawner>().transform;
        ElementsContainer = FindObjectOfType<ElementSpawner>().GetComponent<ElementSpawner>();
        for(int i = 0; i < FilterContainer.GetChild(0).childCount; i++)
        {
            FilterChildren.Add(FilterContainer.GetChild(0).GetChild(i));  
        }        
    }

    public void Update()
    {
        // Keep checking if user is hovering over something
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f);

        // Did user click while hovering over something?
        if (Input.GetMouseButtonDown(0) && hit.transform != null)
        {   
            // Check the tag of the clicked object
            switch(hit.transform.tag)
            {
                case "AlkaliMetals":
                case "AlkalineEarthMetals":
                case "Metalloids":
                case "NobleGases":
                case "PostTransitionMetals":
                case "ReactiveNonMetals":
                  
                    // Make sure the current filter is not the same as that of the clicked element, then update the current filter to that of the clicked element.
                    if (!(hit.transform.CompareTag(CurrentFilter))){
                        CurrentFilter = hit.transform.tag;
                        StartCoroutine(CallGroupedView(hit));
                    }
                    break;
                case "SwitchView":
                    if (CurrentFilter != "Untagged")
                    {
                        StartCoroutine(CallFullView());
                    }
                    break;
                case "Untagged":
                    // If the element is untagged, make sure it is a child of the GroupedViewContainer and call its show details function
                    if (hit.transform.parent.CompareTag("GroupContainer"))
                    {
                        hit.transform.parent.GetComponent<GroupedViewSpawner>().ShowDetails(hit.transform);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    // Function that instructs the ElementSpawner object to call the SpawnContainerGrouped coroutine
    public IEnumerator CallGroupedView(RaycastHit ClickedObject)
    {        
        // Check which filter to send as a parameter by comparing tags
        for(int i = 0; i < FilterContainer.GetChild(0).childCount - 1; i++)
        {
            if (FilterContainer.GetChild(0).GetChild(i).CompareTag(ClickedObject.transform.tag))
            {
                SelectedFilter = FilterContainer.GetComponent<FilterButtonSpawner>().ReturnAllFilters()[i];
                break;
            }
        }
        yield return StartCoroutine(ElementsContainer.SpawnContainerGrouped(SelectedFilter));
    }

    // Function that instructs the ElementSpawner object to call the SpawnContainerFull coroutine
    public IEnumerator CallFullView()
    {
        CurrentFilter = "Untagged";
        yield return StartCoroutine(ElementsContainer.SpawnContainerFull());
    }
}