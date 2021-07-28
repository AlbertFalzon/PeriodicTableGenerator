using System.Collections;
using TMPro;
using UnityEngine;

public class FullViewSpawner : MonoBehaviour
{
    // List of categories that can be spawned
    [SerializeField] string[] Categories;

    // Object prefab to use on the periodic table
    [SerializeField] GameObject ElementPrefab;

    // Transparent Material for unnecessary elements
    [SerializeField] Material MaterialAlpha;

    public IEnumerator SpawnElementsAll(ElementsJsonDetails AllElements)
    {
        foreach (Details element in AllElements.Elements)
        {
            GameObject NextElement = Instantiate(ElementPrefab, new Vector3(element.Xpos - 4.5f, (-element.Ypos) + 4.75f, -0.25f), transform.rotation);
            NextElement.transform.SetParent(transform);

            for (int i = 0; i < Categories.Length; i++)
            {
                if (element.Category == Categories[i])
                {
                    // Assign Tag to element
                    NextElement.tag = element.Category;
                    break;
                }
            }

            // Get TMP child of spawned element
            GameObject TextChild = NextElement.transform.GetChild(0).gameObject;

            // Set text in a string and assign it
            string NewText = "<align=\"right\"><size=18>" + element.Number + "</size></align>\n<size=40>" + element.Symbol + "</size>\n<size=14>" + element.Name + "\n" + element.Atomic_Mass + "</size>";
            TextChild.GetComponent<TextMeshProUGUI>().text = NewText;

            // Use Cpk_Hex to colour the text
            if (ColorUtility.TryParseHtmlString("#" + element.Cpk_Hex[0], out Color NewColor))
            {
                TextChild.GetComponent<TextMeshProUGUI>().color = NewColor;
            }

            // Use Cpk_Hex to colour the material
            if (ColorUtility.TryParseHtmlString("#" + element.Cpk_Hex[1], out NewColor))
            {
                if (NextElement.CompareTag("Untagged"))
                {
                    NewColor.a = 0.25f;
                    NextElement.GetComponent<MeshRenderer>().material = MaterialAlpha;
                }
                NextElement.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", NewColor);
            }
        }
        transform.localScale = new Vector3(0.1f, 0.1f, 0.025f);
        yield return new WaitForFixedUpdate();
    }

    // Called by switch view button from ButtonReader script
    public string[] ReturnCategories()
    {
        return Categories;
    }
}
