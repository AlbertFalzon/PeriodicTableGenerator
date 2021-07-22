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

        FindObjectOfType<ButtonReader>().InitializeReader();
    }

    public IEnumerator SpawnFilterBlock(FilterConfig FilterToSpawn)
    {
        GameObject NextFilterBlock = Instantiate(FilterPrefab, new Vector3(FilterToSpawn.ReturnXpos() - 1.5f, (-FilterToSpawn.ReturnYpos()) + 3f, -0.25f), transform.rotation);
        NextFilterBlock.transform.SetParent(CanvasChild);
        NextFilterBlock.GetComponent<MeshRenderer>().material.SetColor("_Color", FilterToSpawn.ReturnBlockColour());
        NextFilterBlock.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = FilterToSpawn.ReturnCategoryName();
        NextFilterBlock.tag = FilterToSpawn.ReturnTagName();
        NextFilterBlock.name = FilterToSpawn.ReturnTagName();
        yield return new WaitForFixedUpdate();
    }

    public List<FilterConfig> ReturnAllFilters()
    {
        return AllFilters;
    }
}