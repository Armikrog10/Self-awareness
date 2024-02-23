using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Yslygi_skript : MonoBehaviour
{
    public Image icon1, icon2;
    public Image[] icheika;
    public Sprite[] tip_icheika;
    public Sprite[] predmet_sprite;
    public Sprite[] yslyga_sprite;
    public Sprite non;
    public TMP_Text name_predmet1, name_predmet2;
    public Button v, n, obmen;
    int nomer_predmeta;
    public void Obmen()
    {
        Player.inventar[nomer_predmeta] = null;
        icheika[nomer_predmeta].sprite = tip_icheika[0];
        Parametri.Actions(Player.yslyga);
        if (!isPusto(Player.inventar))
        {
            nomer_predmeta = Ne_Pusto(Player.inventar, nomer_predmeta, false);
            icheika[nomer_predmeta].sprite = tip_icheika[3];
            name_predmet2.text = Player.inventar[nomer_predmeta];
            icon2.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[nomer_predmeta])];
        }
        else
        {
            v.interactable = false;
            n.interactable = false;
            obmen.interactable = false;
            name_predmet2.text = null;
            icon2.sprite = non;
        }

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
    int Ne_Pusto(string[] nahodki_ili_ilventar, int nomer_predmeta, bool nazad)
    {
        bool vova = true;
        if (!nazad)
        {
            for (int i = nomer_predmeta + 1; i < 5; i++)
            {
                if (nahodki_ili_ilventar[i] is not null)
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
                else if (nahodki_ili_ilventar[i] is not null)
                {
                    return (i);
                }
            }
        }
        return (0);
    }
    public void strelka(bool t)
    {
        icheika[nomer_predmeta].sprite = tip_icheika[2];
        nomer_predmeta = Ne_Pusto(Player.inventar, nomer_predmeta, t);
        icheika[nomer_predmeta].sprite = tip_icheika[3];
        name_predmet2.text = Player.inventar[nomer_predmeta];
        icon2.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[nomer_predmeta])];
    }
    void Start()
    {
        bool flag = false;
        name_predmet1.text = Player.yslyga;
        icon1.sprite = yslyga_sprite[Array.IndexOf(Parametri.yslygi, Player.yslyga)];
        for (int i = 0; i < 5; i++)
        {
            if (Player.inventar[i] is not null)
            {
                if (flag)
                {
                    icheika[i].sprite = tip_icheika[2];
                }
                else
                {
                    name_predmet2.text = Player.inventar[i];
                    icon2.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[i])];
                    icheika[i].sprite = tip_icheika[3];
                    nomer_predmeta = i;
                    flag = true;
                }
            }
            else
            {
                icheika[i].sprite = tip_icheika[0];
            }
        }
        if (isPusto(Player.inventar))
        {
            v.interactable = false;
            n.interactable = false;
            obmen.interactable = false;
        }
    }
}
