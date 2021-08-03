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
        
        // Program starts with the full periodic table view
        yield return StartCoroutine(SpawnContainerFull());
    }

    public IEnumerator SpawnContainerFull()
    {
        yield return StartCoroutine(DestroyContainer(FullViewPrefab, FullContainerPos));
        
        // Instruct the container to spawn all elements
        yield return StartCoroutine(CurrentContainer.GetComponent<FullViewSpawner>().SpawnElementsAll(ElementsDetail));

        // After the elements are spawned, this function is called to make it grow to normal size
        yield return StartCoroutine(ScaleContainer(FullViewMultiplier));

        // Spawn the filter blocks and set it as a child of the current view container so that upon destruction, this container shrinks along with it
        GameObject FilterContainer = Instantiate(FilterContainerPrefab, transform.position, transform.rotation);
        FilterContainer.transform.parent = CurrentContainer;
    }

    public IEnumerator SpawnContainerGrouped(FilterConfig ChosenFilter)
    {
        yield return StartCoroutine(DestroyContainer(GroupedViewPrefab, GroupedContainerPos));
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
        
        // Store the x and y pos in a Vector3 list with some adjustments for a cleaner presentation on the board and simplified Instantiate code for the GroupedViewSpawner script
        for(int i = 0; i < PosList.Length; i++)
        {
            PosList[i] = new Vector3(ChosenFilter.ReturnFilteredXPos()[i] - 1.5f, -ChosenFilter.ReturnFilteredYPos()[i] + 4.5f, -0.25f);
        }

        yield return StartCoroutine(CurrentContainer.GetComponent<GroupedViewSpawner>().SpawnElementsFiltered(ElementsList, PosList));
        yield return StartCoroutine(ScaleContainer(GroupedContainerMultiplier));
    }
    
    // Function to shrink/grow containers
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
        CurrentContainer.localScale = StartingScale * TargetMultiplier;
        yield return new WaitForFixedUpdate();
    }

    // Function that destroys the current container and spawns a new one
    public IEnumerator DestroyContainer(GameObject ContainerToSpawn, Vector3 NewPos)
    {
        // Checks if there is a container spawned before shrinking and destroying it(there is no container upon starting the program)
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
