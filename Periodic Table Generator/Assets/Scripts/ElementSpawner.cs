using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    // Declaring variables to call the Json file
    [SerializeField] TextAsset PeriodicTableJson;
    
    // Create objects from object classes
    public ElementsJsonDetails ElementsDetail = new ElementsJsonDetails();

    // Containers to spawn
    [SerializeField] GameObject FullViewPrefab;
    [SerializeField] GameObject GroupedViewPrefab;
    [SerializeField] GameObject FilterContainerPrefab;

    // Frequently Referred Objects/Variables
    Transform CurrentContainer;
    Vector3 FullContainerPos = new Vector3(-3f, 1.75f, 0f);
    float FullViewMultiplier = 7f;
    Vector3 GroupedContainerPos = new Vector3(0f, -3f, 0f);
    float GroupedContainerMultiplier = 10f;
    float ShrinkMultiplier = 0.001f;

    public IEnumerator Start()
    {
        // Populate object with json file contents
        ElementsDetail = JsonUtility.FromJson<ElementsJsonDetails>(PeriodicTableJson.text);

        yield return StartCoroutine(SpawnContainerFull());
    }

    public IEnumerator SpawnContainerFull()
    {
        yield return StartCoroutine(DestroyContainer(FullViewPrefab, FullContainerPos));
        yield return StartCoroutine(CurrentContainer.GetComponent<FullViewSpawner>().SpawnElementsAll(ElementsDetail));
        yield return StartCoroutine(ScaleContainer(FullViewMultiplier));
        GameObject FilterContainer = Instantiate(FilterContainerPrefab, transform.position, transform.rotation);
        FilterContainer.transform.parent = CurrentContainer;
    }

    public IEnumerator SpawnContainerGrouped(FilterConfig ChosenFilter)
    {
        yield return StartCoroutine(DestroyContainer(GroupedViewPrefab, GroupedContainerPos));
        Destroy(FindObjectOfType<FilterButtonSpawner>().gameObject);
        List<Details> ElementsList = new List<Details>();

        // Select Elements to spawn
        foreach (Details element in ElementsDetail.Elements) 
        {
            for (int i = 0; i < ChosenFilter.ReturnElementsList().Length; i++)
            {
                if(element.Number == ChosenFilter.ReturnElementsList()[i])
                {
                    ElementsList.Add(element);
                }
            }
        }

        Vector3[] PosList = new Vector3[ChosenFilter.ReturnElementsList().Length];

        for(int i = 0; i < PosList.Length; i++)
        {
            PosList[i] = new Vector3(ChosenFilter.ReturnFilteredXPos()[i] - 1.5f, ChosenFilter.ReturnFilteredYPos()[i] + 3f, -0.25f);
        }

        yield return StartCoroutine(CurrentContainer.GetComponent<GroupedViewSpawner>().SpawnElementsFiltered(ElementsList, PosList));
        yield return StartCoroutine(ScaleContainer(GroupedContainerMultiplier));
    }
    
    public IEnumerator ScaleContainer(float TargetMultiplier)
    {
        float Multiplier;
        float StartMultiplier = 1f;
        float counter = 0;
        Vector3 StartingScale = CurrentContainer.localScale;

        while (counter < 0.25f)
        {
            Multiplier = Mathf.Lerp(StartMultiplier, TargetMultiplier, counter / 0.25f);
            CurrentContainer.localScale = StartingScale * Multiplier;
            counter += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator DestroyContainer(GameObject ContainerToSpawn, Vector3 NewPos)
    {
        if (CurrentContainer != null)
        {
            yield return StartCoroutine(ScaleContainer(ShrinkMultiplier));
            Destroy(CurrentContainer.gameObject);
        }
        GameObject NewContainer = Instantiate(ContainerToSpawn, NewPos, transform.rotation);
        NewContainer.transform.parent = transform.GetChild(0);
        CurrentContainer = NewContainer.transform;
    }
}
