using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UI_Controller : MonoBehaviour
{
    public enum UI_Context {StartMenu, InGame, Endgame};

    CinemachineVirtualCamera cvc;

    [SerializeField] Panel[] allPanels = null;
    public Panel StartPanel = null;
    public CombatPanel CombatPanel = null;
    public EndPanel EndPanel = null;

    //state
    UI_Context context;
    void Awake()
    {
        cvc = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
        foreach (var panel in allPanels)
        {
            panel.gameObject.SetActive(true);
        }

    }

    public void SetCurrentContext(UI_Context newContext)
    {
        context = newContext;

        foreach (var panel in allPanels)
        {
            panel.ShowHideElements(false);
        }

        switch (context)
        {
            case UI_Context.StartMenu:
                StartPanel.ShowHideElements(true);
                return;

            case UI_Context.InGame:
                cvc.Follow = GameController.GetGameController().GetPlayer().transform;
                CombatPanel.ShowHideElements(true);
                return;

            case UI_Context.Endgame:
                EndPanel.ShowHideElements(true);
                return;
        }

    }

}
