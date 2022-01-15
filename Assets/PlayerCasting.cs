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
        ListenForMouseClick();
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

    private void ListenForMouseClick()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Spell.SpellType currentSpell = possibleSpells[selectedSpellIndex].GetSpellType();
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            switch (currentSpell)
            {
                case Spell.SpellType.SummonMountain:
                    if (currentMana < possibleSpells[selectedSpellIndex].GetSpellCost())
                    {
                        return;
                    }
                    
                    FadeHandler fh = Instantiate(possibleSpells[selectedSpellIndex].GetSpellPrefab(), clickPos, Quaternion.identity).GetComponent<FadeHandler>();
                    fh.SetLifetime(10f);
                    currentMana -= possibleSpells[selectedSpellIndex].GetSpellCost();
                    cp.SetManaBar(currentMana / maxMana);
                    return;

                case Spell.SpellType.SummonSkeleton:
                    if (currentMana < possibleSpells[selectedSpellIndex].GetSpellCost())
                    {
                        return;
                    }
                    FadeHandler fh2 = Instantiate(possibleSpells[selectedSpellIndex].GetSpellPrefab(), clickPos, Quaternion.identity).GetComponent<FadeHandler>();
                    fh2.SetLifetime(60f);
                    currentMana -= possibleSpells[selectedSpellIndex].GetSpellCost();
                    cp.SetManaBar(currentMana / maxMana);
                    return;

                case Spell.SpellType.LightningBolt:
                    if (currentMana < possibleSpells[selectedSpellIndex].GetSpellCost())
                    {
                        return;
                    }
                    FadeHandler fh3 = Instantiate(possibleSpells[selectedSpellIndex].GetSpellPrefab(), transform.position, Quaternion.identity).GetComponent<FadeHandler>();
                    Vector2 dir = clickPos - (Vector2)transform.position;
                    fh3.GetComponent<Rigidbody2D>().velocity = dir.normalized * 7f;                    
                    fh3.SetLifetime(6f);
                    currentMana -= possibleSpells[selectedSpellIndex].GetSpellCost();
                    cp.SetManaBar(currentMana / maxMana);
                    return;



            }
        }
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
