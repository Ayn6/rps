using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DefultNamespace;

public class ChangeChose : MonoBehaviour
{
    [SerializeField] private Image sprite;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI resault;

    public List<RPS> items = new List<RPS>();
    public void ChangeSprite(int index)
    {
        sprite.sprite = items[index].sprite;
        name.text = items[index].name;

        int i = Random.Range(0, 3);

        if (index > i)
        {
            if(index == 2 && i == 0)
            {
                resault.text = "LOSE!";
                return;
            }
            resault.text = "WIN!";
        }
        else if (index == i)
        {
            resault.text = "DRAW!";
        }
        else if(index < i)
        {
            if (index == 0 && i == 2)
            {
                resault.text = "WIN!";
                return;
            }
            resault.text = "LOSE!";
        }
    }
}
