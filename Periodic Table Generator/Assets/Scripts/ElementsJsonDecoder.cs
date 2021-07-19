using System.Collections;
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

    IEnumerator Start()
    {
        // Populate object with their respective json file contents
        ElementsDetail = JsonUtility.FromJson<ElementsJsonDetails>(PeriodicTableJson.text);
        // elementsLookup = JsonUtils.ImportJson<ElementsJsonLookup>(periodicTableLookup);

        // Generate blocks
        for(int i = 0; i < ElementsDetail.Elements.Length; i++)
        {
            // print("Block Name: " + ElementsDetail.Elements[i].Name + "\nXpos: " + ElementsDetail.Elements[i].Xpos + "\nYpos: " + ElementsDetail.Elements[i].Ypos);
            yield return StartCoroutine(SpawnElement(i));
        }
    }

    public IEnumerator SpawnElement(int index)
    {
        // Spawn object and set the spawner as its parent
        GameObject NextElement = Instantiate(ElementPrefab, new Vector3(ElementsDetail.Elements[index].Xpos, -ElementsDetail.Elements[index].Ypos, 0), transform.rotation);
        NextElement.transform.SetParent(transform);

        // Get canvas child of spawned element
        GameObject CanvasChild = NextElement.transform.GetChild(0).gameObject;

        // Set text of spawned element
        CanvasChild.transform.GetChild(0).GetComponent<Text>().text = (ElementsDetail.Elements[index].Number).ToString();
        CanvasChild.transform.GetChild(1).GetComponent<Text>().text = ElementsDetail.Elements[index].Symbol;
        CanvasChild.transform.GetChild(2).GetComponent<Text>().text = ElementsDetail.Elements[index].Name;
        CanvasChild.transform.GetChild(3).GetComponent<Text>().text = (ElementsDetail.Elements[index].Atomic_Mass).ToString();

        yield return new WaitForFixedUpdate();
    }
}
