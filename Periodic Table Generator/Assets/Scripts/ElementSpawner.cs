using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementSpawner : MonoBehaviour
{
    // Declaring variables to call the Json file
    [SerializeField] TextAsset PeriodicTableJson;
    
    // Create objects from object classes
    public ElementsJsonDetails ElementsDetail = new ElementsJsonDetails();
    
    // List of categories that can be spawned
    [SerializeField] string[] SpawnableCategories;

    // Object prefab to use on the periodic table
    [SerializeField] GameObject ElementPrefab;
    [SerializeField] GameObject ElementsContainer;

    // Frequently Referred Objects
    Transform CurrentContainer;

    public void Start()
    {
        GameObject NewContainer = Instantiate(ElementsContainer, transform.position, transform.rotation);
        NewContainer.transform.parent = transform.GetChild(0);
        // Initialise CurrentContainer
        CurrentContainer = transform.GetChild(0).GetChild(0);

        // Populate object with json file contents
        ElementsDetail = JsonUtility.FromJson<ElementsJsonDetails>(PeriodicTableJson.text);

        print("Calling Function");
        StartCoroutine(SpawnElementsAll(SpawnableCategories));
        print("Function Called");
    }
    
    public IEnumerator SpawnElementsAll(string[] Categories)
    {
        print("Second Function");
        yield return StartCoroutine(EnlargeShrinkContainer(true));
        print("Second Function Done");
        foreach(Details element in ElementsDetail.Elements)
        {
            GameObject NextElement = Instantiate(ElementPrefab, new Vector3(element.Xpos - 1.5f, (-element.Ypos) + 3f, -0.25f), transform.rotation);
            NextElement.transform.SetParent(CurrentContainer);
            print(element.Category);
            for(int i = 0; i < Categories.Length; i++)
            {
                if(element.Category == Categories[i])
                {
                    // Assign Tag to element
                    NextElement.tag = element.Category;

                    // Get TMP child of spawned element
                    GameObject TextChild = NextElement.transform.GetChild(0).gameObject;

                    // Set text in a string and assign it
                    string NewText = "<align=\"right\"><size=18>" + element.Number + "</size></align>\n<size=40>" + element.Symbol + "</size>\n<size=14>" + element.Name + "\n" + element.Atomic_Mass + "</size>";
                    TextChild.GetComponent<TextMeshProUGUI>().text = NewText;
                    Color NewColor;

                    // Use Cpk_Hex to colour the text
                    if (ColorUtility.TryParseHtmlString("#" + element.Cpk_Hex[0], out NewColor))
                    {
                      TextChild.GetComponent<TextMeshProUGUI>().color = NewColor;
                    }

                    // Use Cpk_Hex to colour the material
                    if (ColorUtility.TryParseHtmlString("#" + element.Cpk_Hex[1], out NewColor))
                    {
                      NextElement.GetComponent<MeshRenderer>().material.SetColor("_Color", NewColor);
                    }
                }
            }
        }
        yield return StartCoroutine(EnlargeShrinkContainer(false));
    }

    public IEnumerator SpawnElementsFiltered(int[] ElementIndexList, FilterConfig ChosenFilter)
    {
        yield return StartCoroutine(EnlargeShrinkContainer(true));
        int count = 0;
        foreach(Details element in ElementsDetail.Elements)
        {
            if(element.Category == ChosenFilter.ReturnTagName())
            {
                GameObject NextElement = Instantiate(ElementPrefab, new Vector3(ChosenFilter.ReturnFilteredXPos()[count] - 1.5f, -(ChosenFilter.ReturnFilteredYPos()[count]) + 3f, -0.25f), transform.rotation);
                NextElement.transform.SetParent(CurrentContainer);
                NextElement.tag = element.Category;

                // Get TMP child of spawned element
                GameObject TextChild = NextElement.transform.GetChild(0).gameObject;

                // Set text in a string and assign it
                string NewText = "<align=\"right\"><size=18>" + element.Number + "</size></align>\n<size=40>" + element.Symbol + "</size>\n<size=14>" + element.Name + "\n" + element.Atomic_Mass + "</size>";
                TextChild.GetComponent<TextMeshProUGUI>().text = NewText;
                Color NewColor;

                // Use Cpk_Hex to colour the text
                if (ColorUtility.TryParseHtmlString("#" + element.Cpk_Hex[0], out NewColor))
                {
                  TextChild.GetComponent<TextMeshProUGUI>().color = NewColor;
                }

                // Use Cpk_Hex to colour the material
                if (ColorUtility.TryParseHtmlString("#" + element.Cpk_Hex[1], out NewColor))
                {
                  NextElement.GetComponent<MeshRenderer>().material.SetColor("_Color", NewColor);
                }

                count++;
            }
        }
        yield return StartCoroutine(EnlargeShrinkContainer(false));
    }

    public IEnumerator EnlargeShrinkContainer(bool shrink)
    {
        
        float counter = 0;
        if (shrink)
        {
            Vector3 StartingScale = CurrentContainer.localScale;
            Vector3 EndScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
            while (counter < 0.25f)
            {
                counter += Time.deltaTime;
                CurrentContainer.localScale = Vector3.Lerp(StartingScale, EndScale, counter / 0.25f);
                yield return null;
            }

            Destroy(CurrentContainer.gameObject);
            GameObject NewContainer = Instantiate(ElementsContainer, transform.position, transform.rotation);
            NewContainer.transform.parent = transform.GetChild(0);
            CurrentContainer = NewContainer.transform;
        } else
        {
            CurrentContainer.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            Vector3 StartingScale = CurrentContainer.localScale;
            Vector3 EndScale = new Vector3(1f , 1f, 1f);
            while (counter < 0.25f)
            {
                counter += Time.deltaTime;
                CurrentContainer.localScale = Vector3.Lerp(StartingScale, EndScale, counter / 0.25f);
                yield return null;
            }
        }
        
    }
}
