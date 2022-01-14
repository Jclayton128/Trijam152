using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    List<GameObject> elements = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            elements.Add(transform.GetChild(i).gameObject);
        }
    }

    public void ShowHideElements(bool shouldShow)
    {
        foreach(var elem in elements)
        {
            elem.SetActive(shouldShow);
        }
    }
}
