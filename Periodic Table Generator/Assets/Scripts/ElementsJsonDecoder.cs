using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementsJsonDecoder : MonoBehaviour
{
    // Declaring variables to call the Json files
    [SerializeField] TextAsset PeriodicTableJson;
    [SerializeField] TextAsset PeriodicTableLookup;

    // Create objects from object classes
    public ElementsJsonDetails ElementsDetail = new ElementsJsonDetails();
    //private ElementsJsonLookup elementsLookup;

    // Object prefab to use on the periodic table
    [SerializeField] GameObject ElementPrefab;
    [SerializeField] string CurrentCategory = "alkali metal";

    // Frequently Referred Objects
    Transform CanvasChild;

    IEnumerator Start()
    {
        // Initialise CanvasChild
        CanvasChild = transform.GetChild(0);
        // Populate object with their respective json file contents
        ElementsDetail = JsonUtility.FromJson<ElementsJsonDetails>(PeriodicTableJson.text);
        // elementsLookup = JsonUtils.ImportJson<ElementsJsonLookup>(periodicTableLookup);

        // Generate blocks
        for(int i = 0; i < ElementsDetail.Elements.Length; i++)
        {
            // print("Block Name: " + ElementsDetail.Elements[i].Name + "\nXpos: " + ElementsDetail.Elements[i].Xpos + "\nYpos: " + ElementsDetail.Elements[i].Ypos);
            yield return StartCoroutine(CheckElement(i));
        }

        yield return StartCoroutine(DestroyChildren());
    }
    
    public IEnumerator CheckElement(int index)
    {
        Details ElementToCheck = ElementsDetail.Elements[index];

        if(ElementToCheck.Category == CurrentCategory)
        {
            print("Spawning Element: " + ElementToCheck.Name);
            yield return StartCoroutine(SpawnElement(ElementToCheck));
        } else
        {
            print("Skipped Element: " + ElementToCheck.Name);
            yield return new WaitForFixedUpdate();
        }
    }
    
    public IEnumerator SpawnElement(Details ElementToSpawn)
    {
        // Spawn object and set the canvas as its parent
        GameObject NextElement = Instantiate(ElementPrefab, new Vector3(ElementToSpawn.Xpos, -ElementToSpawn.Ypos, 0), transform.rotation);
        NextElement.transform.SetParent(CanvasChild);

        // Get TMP child of spawned element
        GameObject TextChild = NextElement.transform.GetChild(0).gameObject;

        // Set text in a string and assign it
        string NewText = "<align=\"right\"><size=18>" + ElementToSpawn.Number + "</size></align>\n<size=40>" + ElementToSpawn.Symbol + "</size>\n<size=14>" + ElementToSpawn.Name + "\n" + ElementToSpawn.Atomic_Mass + "</size>";
        TextChild.GetComponent<TextMeshProUGUI>().text = NewText;
        Color NewColor;

        if (ColorUtility.TryParseHtmlString("#" + ElementToSpawn.Cpk_Hex, out NewColor))
        {
            NextElement.GetComponent<MeshRenderer>().material.SetColor("_Color", NewColor);
        }
       

        yield return new WaitForFixedUpdate();
    }

    public IEnumerator DestroyChildren()
    {
        int i = 0;
        GameObject[] SpawnedElements = new GameObject[CanvasChild.childCount];

        foreach(Transform element in CanvasChild)
        {
            SpawnedElements[i] = element.gameObject;
            i += 1;
        }
        
        foreach(GameObject element in SpawnedElements)
        {
            Destroy(element);
        }

        yield return new WaitForFixedUpdate();
    }
}
