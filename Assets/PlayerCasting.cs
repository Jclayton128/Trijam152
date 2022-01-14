using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    CombatPanel cp;
    [SerializeField] Spell[] possibleSpells = null;

    //param
    float manaGainRate = 3f; //per second
    float maxMana = 100f;

    //state
    float currentMana;
    int selectedSpellIndex = 0;


    void Start()
    {
        cp = GameController.GetGameController().GetUI_Controller().CombatPanel;

        currentMana = maxMana;
        cp.SetManaBar(1f);
        Sprite[] spellsprites = CreateSpellSprites();
        cp.PopulateSpellSlots(spellsprites);
    }

    private Sprite[] CreateSpellSprites()
    {
        List<Sprite> p = new List<Sprite>();
        foreach (var spell in possibleSpells)
        {
            p.Add(spell.GetSpellIcon());
        }

        return p.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        ListenForMouse();

        RegainMana();

        cp.SetManaBar(currentMana / maxMana);
    }

    private void ListenForMouse()
    {
        ListenForSpellScrolling();
    }

    private void ListenForSpellScrolling()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            //scroll up?
            selectedSpellIndex++;
            if (selectedSpellIndex >= possibleSpells.Length)
            {
                selectedSpellIndex = 0;
            }
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            //scroll down?
            selectedSpellIndex--;
            if (selectedSpellIndex < 0)
            {
                selectedSpellIndex = possibleSpells.Length - 1 ;
            }
        }
        cp.HighlightSelectedSpell(selectedSpellIndex);
    }

    private void RegainMana()
    {
        currentMana += Time.deltaTime * manaGainRate;
    }




    #region Helpers
    private void SummonTree(Vector2 position)
    {

    }

    #endregion
}
