using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DefultNamespace;
using System.Collections;
using System.Drawing;

public class ChangeChose : MonoBehaviour
{

    public Animator anim;

    public List<Image> sprite = new List<Image>();
    public List<TextMeshProUGUI> name = new List<TextMeshProUGUI>();
    public List<RPS> items = new List<RPS>();

    [SerializeField] private TextMeshProUGUI countUser;
    [SerializeField] private TextMeshProUGUI countBot;

    [SerializeField] private TextMeshProUGUI resault;
    [SerializeField] private TextMeshProUGUI resaultBot;

    private int countUs = 0, count = 0;

    private void Start()
    {
        count = PlayerPrefs.GetInt("count", count);
        countUs = PlayerPrefs.GetInt("countUs", countUs);
        countBot.text = "Ñ÷¸ò: " + count;
        countUser.text = "Ñ÷¸ò: " + countUs;
    }

    private void Update()
    {
        Save();
    }

    public void ChangeSprite(int index)
    {        

        sprite[0].sprite = items[index].sprite;
        name[0].text = items[index].name;

        if (Mode.mode == 0)
        {
            anim.SetBool("Anim", true);
            StartCoroutine(Anim());

            return;
        }

        int i = Random.Range(0, 3);

        sprite[1].sprite = items[index].sprite;
        name[1].text = items[index].name;

        sprite[2].sprite = items[i].sprite;
        name[2].text = items[i].name;

        if (index > i)
        {
            if (index == 2 && i == 0)
            {
                count++;
                countBot.text = "Ñ÷¸ò: " + count;          
                
                resault.color = UnityEngine.Color.red;  
                resault.text = "LOSE!";
              
                resaultBot.color = UnityEngine.Color.green;
                resaultBot.text = "WIN!";

                return;
            }
            countUs++;
            countUser.text = "Ñ÷¸ò: " + countUs;

            resault.color = UnityEngine.Color.green;
            resault.text = "WIN!";

            resaultBot.color = UnityEngine.Color.red;
            resaultBot.text = "LOSE!";
        }
        else if (index == i)
        {
            resaultBot.color = resault.color = UnityEngine.Color.gray;
            resault.text = "DRAW!";
            resaultBot.text = "DRAW!";

            return;
        }
        else if (index < i)
        {
            if (index == 0 && i == 2)
            {
                countUs++;
                countUser.text = "Ñ÷¸ò: " + countUs;

                resault.color = UnityEngine.Color.green;
                resault.text = "WIN!";

                resaultBot.color = UnityEngine.Color.red;
                resaultBot.text = "LOSE!";
                return;
            }
            count++;
            countBot.text = "Ñ÷¸ò: " + count;    
            
            resault.color = UnityEngine.Color.red;
            resault.text = "LOSE!";

            resaultBot.color = UnityEngine.Color.green;
            resaultBot.text = "WIN!";
        }
    }

    public void Drop()
    {
        countUs = count = 0;
        countBot.text = "Ñ÷¸ò: " + count;
        countUser.text = "Ñ÷¸ò: " + countUs;
        resault.text = "";
        resaultBot.text = "";
    }
    
    private IEnumerator Anim()
    {
        yield return new WaitForSeconds(0.05f);
        anim.SetBool("Anim", false);
    }

    private void Save()
    {
        PlayerPrefs.SetInt("count", count);
        PlayerPrefs.SetInt("countUs", countUs);
        PlayerPrefs.Save();
    }
}
