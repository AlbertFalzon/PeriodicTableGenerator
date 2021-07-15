using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ElementsJsonDetails : JsonDetails<Elements>
{
    public Elements Elements;
    public string Noise;

    public override Elements GetEnumCode()
    {
        return Elements;
    }
}