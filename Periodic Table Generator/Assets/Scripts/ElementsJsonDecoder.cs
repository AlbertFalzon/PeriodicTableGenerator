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
    public ElementsJsonDetails elementsDetail = new ElementsJsonDetails();
    //private ElementsJsonLookup elementsLookup;

    void Start()
    {
        elementsDetail = JsonUtility.FromJson<ElementsJsonDetails>(periodicTableJson.text);
        // elementsLookup = JsonUtils.ImportJson<ElementsJsonLookup>(periodicTableLookup);
        print(elementsDetail);
        print(elementsDetail.Elements);
        print(elementsDetail.Elements[0].Name);
        print(periodicTableJson.text);
    }
}
