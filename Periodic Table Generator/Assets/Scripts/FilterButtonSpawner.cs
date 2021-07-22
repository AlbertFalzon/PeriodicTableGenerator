using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class FilterButtonSpawner : MonoBehaviour
{
    [SerializeField] List<FilterConfig> AllFilters;
    [SerializeField] GameObject FilterPrefab;

    Transform CanvasChild;
    public IEnumerator Start()
    {
        CanvasChild = transform.GetChild(0);
        for(int i = 0; i < AllFilters.Count; i++)
        {
            yield return StartCoroutine(SpawnFilterBlock(AllFilters[i]));
        }
    }

    public IEnumerator SpawnFilterBlock(FilterConfig FilterToSpawn)
    {
        GameObject NextElement = Instantiate(FilterPrefab, new Vector3(FilterToSpawn.ReturnXpos(), -FilterToSpawn.ReturnYpos(), 0), transform.rotation);
        NextElement.transform.SetParent(CanvasChild);
        NextElement.GetComponent<MeshRenderer>().material.SetColor("_Color", FilterToSpawn.ReturnBlockColour());
        NextElement.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = FilterToSpawn.ReturnCategoryName();
        NextElement.GetComponent<FilterButton>().ElementsToFilter = FilterToSpawn;
        yield return StartCoroutine(FindObjectOfType<ElementsJsonDecoder>().SpawnElement(FilterToSpawn.ReturnElementsList()));
        NextElement.transform.GetChild(0).transform.GetComponent<Button>().onClick.AddListener(() => { FindObjectOfType<ElementsJsonDecoder>().ButtonPressed(); });
        yield return new WaitForFixedUpdate();
    }
}