using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mode : MonoBehaviour
{
    private bool action = false;
    public static int mode = 0;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject gameWithBot;
    [SerializeField] private GameObject gameEducation;

    public List<ModeList> items = new List<ModeList>();

    [SerializeField] private TextMeshProUGUI name;

    static public int education = 0;

    private void Start()
    {
       mode = PlayerPrefs.GetInt("mode", mode);
       education = PlayerPrefs.GetInt("education", education);
        Change(mode);
    }

    public void Open(GameObject gameObject)
    {
        if (action)
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

        if(mode == 0)
        {
            game.SetActive(true);
            panel.SetActive(true);
            gameWithBot.SetActive(false);
            gameEducation.SetActive(false);
        }
        else if(mode == 1)
        {
            game.SetActive(false);
            gameWithBot.SetActive(true);
            panel.SetActive(true);
            gameEducation.SetActive(false);
        }
        else
        {
            if(education == 0)
            {
                gameEducation.SetActive(true);
                education = 1;
                Save();
            }
            else
            {
                gameEducation.SetActive(false);
            }
            panel.SetActive(false);
            gameWithBot.SetActive(false);
            game.SetActive(true);
        }

        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("mode", mode);
        PlayerPrefs.SetInt("education", education);
        PlayerPrefs.Save();
    }
}
