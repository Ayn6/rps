using DefultNamespace;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mode : MonoBehaviour
{
    private bool action = false;
    public static int mode = 0;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject Screen;

    public List<ModeList> items = new List<ModeList>();

    [SerializeField] private TextMeshProUGUI name;

    public void Open(GameObject gameObject)
    {
        if(action)
        {
            gameObject.SetActive(false);
            action = false;
        }
        else
        {
            gameObject.SetActive(true);
            action = true;
        }

    }

    public void Change(int i)
    {
        mode = items[i].index;
        name.text = items[i].name;
    }
}
