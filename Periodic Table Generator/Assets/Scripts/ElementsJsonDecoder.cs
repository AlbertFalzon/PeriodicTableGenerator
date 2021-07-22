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

    public void Start()
    {
        // Initialise CanvasChild
        CanvasChild = transform.GetChild(0);
        // Populate object with their respective json file contents
        ElementsDetail = JsonUtility.FromJson<ElementsJsonDetails>(PeriodicTableJson.text);
        // elementsLookup = JsonUtils.ImportJson<ElementsJsonLookup>(periodicTableLookup);

    }
    
    public IEnumerator SpawnElement(int[] ElementIndexList)
    {
        yield return StartCoroutine(DestroyChildren());
        for(int i = 0; i < ElementIndexList.Length; i++)
        {
            Details ElementToSpawn = ElementsDetail.Elements[ElementIndexList[i]-1];

            // Spawn object and set the canvas as its parent
            GameObject NextElement = Instantiate(ElementPrefab, new Vector3(ElementToSpawn.Xpos - 1.5f, (-ElementToSpawn.Ypos) + 3f, -0.25f), transform.rotation);
            NextElement.transform.SetParent(CanvasChild);
            NextElement.transform.localScale -= new Vector3(0, 0, 3);
      
            // Get TMP child of spawned element
            GameObject TextChild = NextElement.transform.GetChild(0).gameObject;

            // Set text in a string and assign it
            string NewText = "<align=\"right\"><size=18>" + ElementToSpawn.Number + "</size></align>\n<size=40>" + ElementToSpawn.Symbol + "</size>\n<size=14>" + ElementToSpawn.Name + "\n" + ElementToSpawn.Atomic_Mass + "</size>";
            TextChild.GetComponent<TextMeshProUGUI>().text = NewText;
            Color NewColor;

            // Use Cpk_Hex to colour the text
            if (ColorUtility.TryParseHtmlString("#" + ElementToSpawn.Cpk_Hex[0], out NewColor))
            {
                TextChild.GetComponent<TextMeshProUGUI>().color = NewColor;
            }

            // Use Cpk_Hex to colour the material
            if (ColorUtility.TryParseHtmlString("#" + ElementToSpawn.Cpk_Hex[1], out NewColor))
            {
               NextElement.GetComponent<MeshRenderer>().material.SetColor("_Color", NewColor);
            }

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
