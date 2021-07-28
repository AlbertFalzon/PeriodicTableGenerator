using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroupedViewSpawner : MonoBehaviour
{
    // Object prefab to use on the periodic table
    [SerializeField] GameObject ElementPrefab;
    [SerializeField] Material MaterialOpaque;
    public List<Details> CurrentElements;

    public IEnumerator SpawnElementsFiltered(List<Details> ElementsList, Vector3[] PositionsList)
    {
        CurrentElements = ElementsList;
        
        for (int i = 0; i < CurrentElements.Count; i++)
        {
            GameObject NextElement = Instantiate(ElementPrefab, PositionsList[i] + transform.position, transform.rotation);
            NextElement.transform.SetParent(transform);

            // Get TMP child of spawned element
            GameObject TextChild = NextElement.transform.GetChild(0).gameObject;

            // Set text in a string and assign it
            string NewText = "<align=\"right\"><size=18>" + CurrentElements[i].Number + "</size></align>\n<size=40>" + CurrentElements[i].Symbol + "</size>\n<size=14>" + CurrentElements[i].Name + "\n" + CurrentElements[i].Atomic_Mass + "</size>";
            TextChild.GetComponent<TextMeshProUGUI>().text = NewText;

            // Use Cpk_Hex to colour the text
            if (ColorUtility.TryParseHtmlString("#" + CurrentElements[i].Cpk_Hex[0], out Color NewColor))
            {
                TextChild.GetComponent<TextMeshProUGUI>().color = NewColor;
            }

                // Use Cpk_Hex to colour the material
            if (ColorUtility.TryParseHtmlString("#" + CurrentElements[i].Cpk_Hex[1], out NewColor))
            {
                NextElement.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", NewColor);
            }
        }
        transform.localScale = new Vector3(0.1f, 0.1f, 0.025f);
        yield return new WaitForFixedUpdate();
    }

    public void ShowDetails(Transform hit)
    {
        for(int i = 2; i < transform.childCount; i++)
        {
            if(hit == transform.GetChild(i))
            {
                i -= 2;
                transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "<color=#" + CurrentElements[i].Cpk_Hex[0] + "><size=8>" + CurrentElements[i].Name + "</size></color>\n" + CurrentElements[i].Summary;
                if (ColorUtility.TryParseHtmlString("#" + CurrentElements[i].Cpk_Hex[1], out Color NewColor))
                {
                    transform.GetChild(0).GetComponent<MeshRenderer>().material = MaterialOpaque;
                    transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_BaseColor", NewColor);
                }
                break;
            }
        }
    }
}
