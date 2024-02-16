using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Nahodki_skript : MonoBehaviour
{
    public Image icon1, icon2;
    public Image[] icheika1 = new Image[5];
    public Image[] icheika2 = new Image[5];
    public Sprite[] tip_icheika = new Sprite[4];
    public Sprite[] predmet_sprite = new Sprite[4];
    public Sprite non;
    public TMP_Text name_predmet1, name_predmet2;
    public Button v1, n1, v2, n2, vzat, vikinyt;
    int nomer_predmeta1 = 0, nomer_predmeta2 = 0;
    public void Vzat()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Player.inventar[i] is null)
            {
                if(isPusto(Player.inventar))
                {
                    v2.interactable = true;
                    n2.interactable = true;
                    vikinyt.interactable = true;
                    icheika2[0].sprite = tip_icheika[3];
                    name_predmet2.text = Player.nahodki[nomer_predmeta1];
                    icon2.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.nahodki[nomer_predmeta1])];
                }
                else
                {
                    icheika2[i].sprite = tip_icheika[2];
                }
                Player.inventar[i] = Player.nahodki[nomer_predmeta1];
                Player.nahodki[nomer_predmeta1] = null;
                icheika1[nomer_predmeta1].sprite = tip_icheika[0];
                if(!isPusto(Player.nahodki))
                {
                    nomer_predmeta1 = Ne_Pusto(Player.nahodki, nomer_predmeta1, false);
                    icheika1[nomer_predmeta1].sprite = tip_icheika[3];
                    name_predmet1.text = Player.nahodki[nomer_predmeta1];
                    icon1.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.nahodki[nomer_predmeta1])];
                }
                else
                {
                    vzat.interactable = false;
                    v1.interactable = false;
                    n1.interactable = false;
                    name_predmet1.text = null;
                    icon1.sprite = non;
                }
                if(isFull(Player.inventar))
                {
                    vzat.interactable = false;
                }
                i = 5;
            }
        }
    }
    public void Vikinyt()
    {
        if(!isPusto(Player.nahodki))
        {
            vzat.interactable = true;
        }
        Player.inventar[nomer_predmeta2] = null;
        icheika2[nomer_predmeta2].sprite = tip_icheika[0];
        if (!isPusto(Player.inventar))
        {
            nomer_predmeta2 = Ne_Pusto(Player.inventar, nomer_predmeta2, false);
            icheika2[nomer_predmeta2].sprite = tip_icheika[3];
            name_predmet2.text = Player.inventar[nomer_predmeta2];
            icon2.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[nomer_predmeta2])];
        }
        else
        {
            v2.interactable = false;
            n2.interactable = false;
            vikinyt.interactable = false;
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
    bool isFull(string[] mass)
    {
        for (int i = 0; i < 5; i++)
        {
            if (mass[i] is null)
            {
                return (false);
            }
        }
        return (true);
    }
    int Ne_Pusto(string[] nahodki_ili_ilventar, int nomer_predmeta, bool nazad)
    {
        bool vova = true;
        if(!nazad)
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
    public void strelka1(bool t)
    {
        icheika1[nomer_predmeta1].sprite = tip_icheika[2];
        nomer_predmeta1 = Ne_Pusto(Player.nahodki, nomer_predmeta1, t);
        icheika1[nomer_predmeta1].sprite = tip_icheika[3];
        name_predmet1.text = Player.nahodki[nomer_predmeta1];
        icon1.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.nahodki[nomer_predmeta1])];
    }
    public void strelka2(bool t)
    {
        icheika2[nomer_predmeta2].sprite = tip_icheika[2];
        nomer_predmeta2 = Ne_Pusto(Player.inventar, nomer_predmeta2, t);
        icheika2[nomer_predmeta2].sprite = tip_icheika[3];
        name_predmet2.text = Player.inventar[nomer_predmeta2];
        icon2.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[nomer_predmeta2])];
    }
    void Start()
    {
        bool flag1 = false, flag2 = false;
        for (int i = 0; i < 5; i++)
        {
            if (Player.inventar[i] is not null)
            {
                if (flag1)
                {
                    icheika2[i].sprite = tip_icheika[2];
                }
                else
                {
                    name_predmet2.text = Player.inventar[i];
                    icon2.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.inventar[i])];
                    icheika2[i].sprite = tip_icheika[3];
                    nomer_predmeta2 = i;
                    flag1 = true;
                }
            }
            else
            {
                icheika2[i].sprite = tip_icheika[0];
            }
            if (Player.nahodki[i] is not null)
            {
                if (flag2)
                {
                    icheika1[i].sprite = tip_icheika[2];
                }
                else
                {
                    name_predmet1.text = Player.nahodki[i];
                    icon1.sprite = predmet_sprite[Array.IndexOf(Parametri.predmet, Player.nahodki[i])];
                    icheika1[i].sprite = tip_icheika[3];
                    nomer_predmeta1 = i;
                    flag2 = true;
                }
            }
            else
            {
                icheika1[i].sprite = tip_icheika[0];
            }
        }
        if (isPusto(Player.inventar))
        {
            v2.interactable = false;
            n2.interactable = false;
            vikinyt.interactable = false;
        }
        if (isFull(Player.inventar))
        {
            vzat.interactable = false;
        }
    }
}
