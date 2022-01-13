using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CrystalCounter : MonoBehaviour
{
    public Text CrystalCounterText;
    void Start()
    {
        UpdateCrystalCounterText();
    }

    public void UpdateCrystalCounterText()
    {
        var crystals = FindObjectsOfType<Crystal>();
        var crystalCount = crystals.Length;
        var crystalInactive = crystals.Count(crystal => !crystal.Active);

        var text = crystalInactive + "/ " + crystalCount;
        CrystalCounterText.text = text;
    }

    public int ReachedCrystals()
    {
        var crystals = FindObjectsOfType<Crystal>();
        var crystalInactive = crystals.Count(crystal => !crystal.Active);

        return crystalInactive;
    }
}
