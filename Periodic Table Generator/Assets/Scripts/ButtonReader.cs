using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReader : MonoBehaviour
{
    public void ButtonPressed()
    {
        GameObject ClickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        FilterConfig SelectedFilter = ClickedButton.transform.parent.GetComponent<FilterButton>().ReturnElementsToFilter();
        StartCoroutine(FindObjectOfType<ElementsJsonDecoder>().SpawnElement(SelectedFilter.ReturnElementsList()));
    }
}