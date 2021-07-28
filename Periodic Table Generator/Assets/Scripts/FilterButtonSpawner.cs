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
    [SerializeField] GameObject LegendPrefab;

    Transform CanvasChild;
    public IEnumerator Start()
    {
        CanvasChild = transform.GetChild(0);
        for(int i = 0; i < AllFilters.Count; i++)
        {
            yield return StartCoroutine(SpawnFilterBlock(AllFilters[i]));
        }

        yield return StartCoroutine(SpawnLegend());

        FindObjectOfType<ButtonReader>().InitializeReader();
    }

    public IEnumerator SpawnFilterBlock(FilterConfig FilterToSpawn)
    {
        GameObject NextFilterBlock = Instantiate(FilterPrefab, new Vector3(FilterToSpawn.ReturnXpos() - 1.5f, (-FilterToSpawn.ReturnYpos()) + 3f, -0.25f), transform.rotation);
        NextFilterBlock.transform.SetParent(CanvasChild);
        NextFilterBlock.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", FilterToSpawn.ReturnBlockColour());
        NextFilterBlock.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = FilterToSpawn.ReturnCategoryName();
        NextFilterBlock.tag = FilterToSpawn.ReturnTagName();
        NextFilterBlock.name = FilterToSpawn.ReturnTagName();
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator SpawnLegend()
    {
        GameObject Legend = Instantiate(LegendPrefab, new Vector3(8.3f, 7.3f, 0f), transform.rotation);
        Legend.transform.SetParent(CanvasChild);
        
        yield return new WaitForFixedUpdate();
    }

    public List<FilterConfig> ReturnAllFilters()
    {
        return AllFilters;
    }
}