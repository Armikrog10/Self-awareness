using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventar_skript : MonoBehaviour
{
    public Image[] icheika = new Image[5];
    public Sprite[] tip_icheika = new Sprite[4];
    public Button v, n;
    public TMP_Text name_predmet;
    int nomer_predmeta = 0, pusto = 0;
    int Ne_Pusto_V()
    {
        bool vova = true;
        for (int i = nomer_predmeta + 1; i < 5; i++)
        {
            if (Player.inventar[i] != null)
            {
                return (i);
            }
            else if(i == 4 && vova)
            {
                vova = false;
                i = -1;
            }
        }
        return (0);
    }
    int Ne_Pusto_N()
    {
        bool vova = true;
        for (int i = nomer_predmeta - 1; i > -2; i--)
        {
            if (i == -1 && vova)
            {
                vova = false;
                i = 5;
            }
            else if (Player.inventar[i] != null)
            {
                return (i);
            }
        }
        return (0);
    }
    public void vperod()
    {
        
        icheika[nomer_predmeta].sprite = tip_icheika[2];
        nomer_predmeta = Ne_Pusto_V();
        icheika[nomer_predmeta].sprite = tip_icheika[3];
        name_predmet.text = Player.inventar[nomer_predmeta];
    }
    public void nazad()
    {
        icheika[nomer_predmeta].sprite = tip_icheika[2];
        nomer_predmeta = Ne_Pusto_N();
        icheika[nomer_predmeta].sprite = tip_icheika[3];
        name_predmet.text = Player.inventar[nomer_predmeta];
    }
    private void Start()
    {
        name_predmet.text = Player.inventar[nomer_predmeta];
        for (int i = 0; i < 5; i++)
        {
            if (Player.inventar[i] != null)
            {
                if (i > 0)
                {
                    icheika[i].sprite = tip_icheika[2];
                }
                else
                {
                    icheika[i].sprite = tip_icheika[3];
                }
            }
            else
            {
                icheika[i].sprite = tip_icheika[0];
                pusto++;
            }
        }
        if(pusto == 5)
        {
            v.interactable = false;
            n.interactable = false;
        }
    }
}
