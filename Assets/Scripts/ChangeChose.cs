using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DefultNamespace;
using System.Collections;

public class ChangeChose : MonoBehaviour
{

    public Animator anim;

    public List<Image> sprite = new List<Image>();
    public List<TextMeshProUGUI> name = new List<TextMeshProUGUI>();
    public List<RPS> items = new List<RPS>();
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

        anim.SetBool("Anim", true);
        StartCoroutine(Anim());

        sprite[1].sprite = items[index].sprite;
        name[1].text = items[index].name;

        sprite[2].sprite = items[i].sprite;
        name[2].text = items[i].name;
    }
    
    private IEnumerator Anim()
    {
        yield return new WaitForSeconds(0.05f);
        anim.SetBool("Anim", false);
    }
}
