using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Spell")]
public class Spell : ScriptableObject
{
    [SerializeField] Sprite spellIcon = null;
    [SerializeField] GameObject generatedPrefab = null;

    public enum SpellType { SummonTree};

    [SerializeField] SpellType spellType = SpellType.SummonTree;
    [SerializeField] int spellCost = 0;

    public Sprite GetSpellIcon()
    {
        return spellIcon;
    }

    public SpellType GetSpellType()
    {
        return spellType;
    }

    public GameObject GetSpellPrefab()
    {
        return generatedPrefab;
    }

    public int GetSpellCost()
    {
        return spellCost;
    }
}
