using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
// Declare the the elements list which then will hold all other elements inside of it as objects
public class ElementsJsonDetails
{
    [SerializeField] private Details[] elements;
    public Details[] Elements
    {
        get { return elements; }
        private set { elements = value; }
    }
}


[System.Serializable]
// Declare element object to be stored within the elements list
public class Details
{
    [SerializeField] private string name;
    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    [SerializeField] private string appearance;
    public string Appearance
    {
        get { return appearance; }
        private set { appearance = value; }
    }

    [SerializeField] private float atomic_mass;
    public float Atomic_Mass
    {
        get { return atomic_mass; }
        private set { atomic_mass = value; }
    }

    [SerializeField] private float boil;
    public float Boil
    {
        get { return boil; }
        private set { boil = value; }
    }

    [SerializeField] private string category;
    public string Category
    {
        get { return category; }
        private set { category = value; }
    }

    [SerializeField] private string color;
    public string Color
    {
        get { return color; }
        private set { color = value; }
    }

    [SerializeField] private float density;
    public float Density
    {
        get { return density; }
        private set { density = value; }
    }

    [SerializeField] private string discovered_by;
    public string Discovered_By
    {
        get { return discovered_by; }
        private set { discovered_by = value; }
    }

    [SerializeField] private float melt;
    public float Melt
    {
        get { return melt; }
        private set { melt = value; }
    }

    [SerializeField] private float molar_heat;
    public float Molar_Heat
    {
        get { return molar_heat; }
        private set { molar_heat = value; }
    }

    [SerializeField] private string named_by;
    public string Named_By
    {
        get { return named_by; }
        private set { named_by = value; }
    }

    [SerializeField] private int number;
    public int Number
    {
        get { return number; }
        private set { number = value; }
    }

    [SerializeField] private int period;
    public int Period
    {
        get { return period; }
        private set { period = value; }
    }

    [SerializeField] private string phase;
    public string Phase
    {
        get { return phase; }
        private set { phase = value; }
    }

    [SerializeField] private string source;
    public string Source
    {
        get { return source; }
        private set { source = value; }
    }

    [SerializeField] private string spectral_img;
    public string Spectral_Img
    {
        get { return spectral_img; }
        private set { spectral_img = value; }
    }

    [SerializeField] private string summary;
    public string Summary
    {
        get { return summary; }
        private set { summary = value; }
    }

    [SerializeField] private string symbol;
    public string Symbol
    {
        get { return symbol; }
        private set { symbol = value; }
    }

    [SerializeField] private int xpos;
    public int Xpos
    {
        get { return xpos; }
        private set { xpos = value; }
    }

    [SerializeField] private int ypos;
    public int Ypos
    {
        get { return ypos; }
        private set { ypos = value; }
    }

    [SerializeField] private int[] shells;
    public int[] Shells
    {
        get { return shells; }
        private set { shells = value; }
    }

    [SerializeField] private string electron_configuration;
    public string Electron_Configuration
    {
        get { return electron_configuration; }
        private set { electron_configuration = value; }
    }

    [SerializeField] private string electron_configuration_semantic;
    public string Electron_Configuration_Semantic
    {
        get { return electron_configuration_semantic; }
        private set { electron_configuration_semantic = value; }
    }

    [SerializeField] private float electron_affinity;
    public float Electron_Affinity
    {
        get { return electron_affinity; }
        private set { electron_affinity = value; }
    }

    [SerializeField] private float electronegativity_pauling;
    public float Electronegativity_Pauling
    {
        get { return electronegativity_pauling; }
        private set { electronegativity_pauling = value; }
    }

    [SerializeField] private float[] ionization_energies;
    public float[] Ionization_Energies
    {
        get { return ionization_energies; }
        private set { ionization_energies = value; }
    }

    [SerializeField] private string cpk_hex;
    public string Cpk_Hex
    {
        get { return cpk_hex; }
        private set { cpk_hex = value; }
    }
}