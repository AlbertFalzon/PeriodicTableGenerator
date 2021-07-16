using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsJsonDecoder : MonoBehaviour
{
    // Declaring variables to call the Json files
    [SerializeField] TextAsset periodicTableJson;
    public string periodicTableLookup = "Json/PeriodicTableLookup";
    private ElementsJsonDetails elementsDetail;
    //private ElementsJsonLookup elementsLookup;

    void Start()
    {
        elementsDetail = JsonUtility.FromJson<ElementsJsonDetails>(periodicTableJson.text);
        // elementsLookup = JsonUtils.ImportJson<ElementsJsonLookup>(periodicTableLookup);
        
        print(elementsDetail);
        print(periodicTableJson);
        print(periodicTableJson.text);
    }
}
