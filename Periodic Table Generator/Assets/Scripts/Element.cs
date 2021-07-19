using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : ScriptableObject
{
    // Initialise Variables with the default values of Hydrogen
    string ElementName = "Hydrogen";
    string ElementAppearance = "Colorless Gas";
    float ElementAtomicMass = 1.008f;
    float ElementBoil = 20.271f;
    string ElementCategory = "Diatomic Nonmetal";
    string ElementColor;
    float ElementDensity = 0.08988f;
    string ElementDiscovery = "Henry Cavendish";
    float ElementMelt = 13.99f;
    float ElementMolarHeat = 28.836f;
    string ElementNamedBy = "Antoine Lavoisier";
    int ElementNumber = 1;
    int ElementPeriod = 1;
    string ElementPhase = "Gas";
    string ElementSource = "https://en.wikipedia.org/wiki/Hydrogen";
    string ElementSpectralImg = "https://en.wikipedia.org/wiki/File:Hydrogen_Spectra.jpg";
    string ElementSummary = "Hydrogen is a chemical element with chemical symbol H and atomic number 1. With an atomic weight of 1.00794 u, hydrogen is the lightest element on the periodic table. Its monatomic form (H) is the most abundant chemical substance in the Universe, constituting roughly 75% of all baryonic mass.";
    string ElementSymbol = "H";
    int[] ElementShells;
    string ElementElectronConfig = "1s1";
    string ElementElectronConfigSemantic = "1s1";
    float ElementElectronAffinity = 72.769f;
    float ElementElectroNegativity = 2.2f;
    int[] ElementIonizationEnergy;

    public string ReturnName()
    {
        return ElementName;
    }

    public string ReturnAppearance()
    {
        return ElementAppearance;
    }

    public float ReturnAtomicMass()
    {
        return ElementAtomicMass;
    }

    public float ReturnBoil()
    {
        return ElementBoil;
    }

    public string ReturnCategory()
    {
        return ElementCategory;
    }

    public string ReturnColor()
    {
        return ElementColor;
    }

    public float ReturnDensity()
    {
        return ElementDensity;
    }

    public string ReturnDiscovery()
    {
        return ElementDiscovery;
    }

    public float ReturnMelt()
    {
        return ElementMelt;
    }

    public float ReturnMolarHeat()
    {
        return ElementMolarHeat;
    }

    public string ReturnNamedBy()
    {
        return ElementNamedBy;
    }

    public int ReturnNumber()
    {
        return ElementNumber;
    }

    public int ReturnPeriod()
    {
        return ElementPeriod;
    }

    public string ReturnPhase()
    {
        return ElementPhase;
    }

    public string ReturnSource()
    {
        return ElementSource;
    }

    public string ReturnSpectralImg()
    {
        return ElementSpectralImg;
    }

    public string ReturnSummary()
    {
        return ElementSummary;
    }

    public string ReturnSymbol()
    {
        return ElementSymbol;
    }

    public int[] ReturnShells()
    {
        return ElementShells;
    }

    public string ReturnElectronConfig()
    {
        return ElementElectronConfig;
    }

    public string ReturnElectronConfigSemantic()
    {
        return ElementElectronConfigSemantic;
    }

    public float ReturnElectronAffinity()
    {
        return ElementElectronAffinity;
    }

    public float ReturnElectroNegativity()
    {
        return ElementElectroNegativity;
    }

    public int[] ReturnIonizationEnergy()
    {
        return ElementIonizationEnergy;
    }
}