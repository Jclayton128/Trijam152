using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatPanel : Panel
{
    [SerializeField] Slider manaBar = null;
    [SerializeField] Image[] spellSlots = null;

    Color highlightedColor = Color.white;
    Color unselectedColor = new Color(1, 1, 1, .3f);

    public void SetManaBar(float factor)
    {
        manaBar.value = factor;
    }


    public void HighlightSelectedSpell(int selectedSpell)
    {
        foreach (var spell in spellSlots)
        {
            spell.color = unselectedColor;
        }
        spellSlots[selectedSpell].color = highlightedColor;
    }

    public void PopulateSpellSlots(Sprite[] incomingSpells)
    {
        for (int i = 0; i < spellSlots.Length; i++)
        {
            spellSlots[i].sprite = incomingSpells[i];
        }
    }
}
