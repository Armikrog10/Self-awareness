using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Inventar_skript : MonoBehaviour
{
    public Image icon;
    public Image[] icheika = new Image[5];
    public Sprite[] tip_icheika = new Sprite[4];
    public Sprite[] predmet_sprite = new Sprite[4];
    public Sprite non;
    public Button v, n,vikinyt;
    public TMP_Text name_predmet;
    int nomer_predmeta = 0, pusto = 0;
    int Ne_Pusto(bool nazad)
    {
        bool vova = true;
        if (!nazad)
        {
            for (int i = nomer_predmeta + 1; i < 5; i++)
            {
                if (Player.inventar[i] is not null)
                {
                    return (i);
                }
                else if (i == 4 && vova)
                {
                    vova = false;
                    i = -1;
                }
            }
        }
        else
        {
            for (int i = nomer_predmeta - 1; i > -2; i--)
            {
                if (i == -1 && vova)
                {
                    vova = false;
                    i = 5;
                }
                else if (Player.inventar[i] is not null)
                {
                    return (i);
                }
            }
        }
        return (0);
    }
    bool isPusto(string[] mass)
    {
        for (int i = 0; i < 5; i++)
        {
            if (mass[i] is not null)
            {
                return (false);
            }
        }
        return (true);
    }
    public void strelka(bool t)
    {
        
        icheika[nomer_predmeta].sprite = tip_icheika[2];
        nomer_predmeta = Ne_Pusto(t);
        icheika[nomer_predmeta].sprite = tip_icheika[3];
        name_predmet.text = Player.inventar[nomer_predmeta];
        icon.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[nomer_predmeta])];
    }
    public void Vikinyt()
    {
        Player.inventar[nomer_predmeta] = null;
        icheika[nomer_predmeta].sprite = tip_icheika[0];
        if (!isPusto(Player.inventar))
        {
            nomer_predmeta = Ne_Pusto(false);
            icheika[nomer_predmeta].sprite = tip_icheika[3];
            name_predmet.text = Player.inventar[nomer_predmeta];
            icon.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[nomer_predmeta])];
        }
        else
        {
            v.interactable = false;
            n.interactable = false;
            vikinyt.interactable = false;
            name_predmet.text = null;
            icon.sprite = non;
        }

    }
    private void Start()
    {
        name_predmet.text = Player.inventar[nomer_predmeta];
        if (Player.inventar[nomer_predmeta] != null)
        {
            icon.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[nomer_predmeta])];
        }
        for (int i = 0; i < 5; i++)
        {
            bool flag = false;
            if (Player.inventar[i] is not null)
            {
                if (flag)
                {
                    icheika[i].sprite = tip_icheika[2];
                }
                else
                {
                    name_predmet.text = Player.inventar[i];
                    icon.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[i])];
                    icheika[i].sprite = tip_icheika[3];
                    nomer_predmeta = i;
                    flag = true;
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
            vikinyt.interactable = false;
        }
    }
}
