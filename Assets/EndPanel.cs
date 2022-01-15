using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndPanel : Panel
{
    [SerializeField] TextMeshProUGUI tmp = null;

    public void SetRunText()
    {
        float time = GameController.GetGameController().GetLevelController().GetRunTime();
        tmp.text = $"But at least you had {time} seconds of peace";
    }
}
