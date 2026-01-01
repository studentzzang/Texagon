using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTileDetail : MonoBehaviour
{
    public int num = 0;
    TextMeshPro tmp;
    SpriteRenderer sp;

    public Color trueColor;
    public Color falseColor; //0, 없을때 컬러 아마 회색

    private void Awake()
    {
        sp=GetComponent<SpriteRenderer>();
        tmp=GetComponentInChildren<TextMeshPro>();
    }

    void Update()
    {
        if (num > 0)
        {
            ChangeColor(trueColor);
            ChangeNumText(num.ToString());
        }
        else
        {
            ChangeColor(falseColor);
            ChangeNumText(" ");
        }

    }
    void ChangeColor(Color setColor)
    {
        sp.color = setColor;
    }
    void ChangeNumText(string txt)
    {
        tmp.text = txt;
    }
}
