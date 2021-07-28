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

    public IEnumerator CallGroupedView(RaycastHit ClickedObject)
    {        
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

    public IEnumerator CallFullView()
    {
        CurrentFilter = "Untagged";
        yield return StartCoroutine(ElementsContainer.SpawnContainerFull());
    }
}