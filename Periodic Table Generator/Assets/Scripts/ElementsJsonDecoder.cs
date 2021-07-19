using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ElementsJsonDecoder : MonoBehaviour
{
    // Declaring variables to call the Json files
    [SerializeField] TextAsset periodicTableJson;
    public string periodicTableLookup = "Json/PeriodicTableLookup";
    public newJsonDetails elementsDetail = new newJsonDetails();
    //private ElementsJsonLookup elementsLookup;

    void Start()
    {
        elementsDetail = JsonUtility.FromJson<newJsonDetails>(periodicTableJson.text);
        // elementsLookup = JsonUtils.ImportJson<ElementsJsonLookup>(periodicTableLookup);
        print(elementsDetail);
        print(elementsDetail.elements);
        print(elementsDetail.elements[0].name);
        print(periodicTableJson.text);
    }
}
