using System;
using System.Collections.Generic;

[Serializable]
public class ElementsJsonDetails
{
    private List<Details> elements;
    public List<Details> Elements
    {
        get { return elements; }
        private set { elements = value; }
    }
}

[Serializable]
public class Details
{
    private string name;
    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    private string appearance;
    public string Appearance
    {
        get { return appearance; }
        private set { appearance = value; }
    }

    private float atomic_mass;
    public float Atomic_Mass
    {
        get { return atomic_mass; }
        private set { atomic_mass = value; }
    }

    private float boil;
    public float Boil
    {
        get { return boil; }
        private set { boil = value; }
    }

    private string category;
    public string Category
    {
        get { return category; }
        private set { category = value; }
    }

    private string color;
    public string Color
    {
        get { return color; }
        private set { color = value; }
    }

    private float density;
    public float Density
    {
        get { return density; }
        private set { density = value; }
    }

    private string discovered_by;
    public string Discovered_By
    {
        get { return discovered_by; }
        private set { discovered_by = value; }
    }

    private float melt;
    public float Melt
    {
        get { return melt; }
        private set { melt = value; }
    }

    private float molar_heat;
    public float Molar_Heat
    {
        get { return molar_heat; }
        private set { molar_heat = value; }
    }

    private string named_by;
    public string Named_By
    {
        get { return named_by; }
        private set { named_by = value; }
    }

    private int number;
    public int Number
    {
        get { return number; }
        private set { number = value; }
    }

    private int period;
    public int Period
    {
        get { return period; }
        private set { period = value; }
    }

    private string phase;
    public string Phase
    {
        get { return phase; }
        private set { phase = value; }
    }

    private string source;
    public string Source
    {
        get { return source; }
        private set { source = value; }
    }

    private string spectral_img;
    public string Spectral_Img
    {
        get { return spectral_img; }
        private set { spectral_img = value; }
    }

    private string summary;
    public string Summary
    {
        get { return summary; }
        private set { summary = value; }
    }

    private string symbol;
    public string Symbol
    {
        get { return symbol; }
        private set { symbol = value; }
    }

    private int xpos;
    public int Xpos
    {
        get { return xpos; }
        private set { xpos = value; }
    }

    private int ypos;
    public int Ypos
    {
        get { return ypos; }
        private set { ypos = value; }
    }

    private List<int> shells;
    public List<int> Shells
    {
        get { return shells; }
        private set { shells = value; }
    }

    private string electron_configuration;
    public string Electron_Configuration
    {
        get { return electron_configuration; }
        private set { electron_configuration = value; }
    }

    private string electron_configuration_semantic;
    public string Electron_Configuration_Semantic
    {
        get { return electron_configuration_semantic; }
        private set { electron_configuration_semantic = value; }
    }

    private float electron_affinity;
    public float Electron_Affinity
    {
        get { return electron_affinity; }
        private set { electron_affinity = value; }
    }

    private float electronegativity_pauling;
    public float Electronegativity_Pauling
    {
        get { return electronegativity_pauling; }
        private set { electronegativity_pauling = value; }
    }

    private List<float> ionization_energies;
    public List<float> Ionization_Energies
    {
        get { return ionization_energies; }
        private set { ionization_energies = value; }
    }

    private string cpk_hex;
    public string Cpk_Hex
    {
        get { return cpk_hex; }
        private set { cpk_hex = value; }
    }
}