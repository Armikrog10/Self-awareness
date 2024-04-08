using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Batle_skript : MonoBehaviour
{
    public static List<string> enemy = new List<string>();
    public GameObject okno;
    public TMP_Text dist_text, enemy_name, enemy_hp_text;
    public TMP_Text hp, weapon;
    public TMP_Text ataka_text, blok_text, SokDist, RazDist;
    public Sprite[] deistvia_sprit;
    public Image[] deistvia_image;
    public TMP_Text okno_text;
    public static bool iniciativa = false;
    public static float dist = 0;
    int enemy_hp = 0, enemy_hp_max = 0;
    int deistvia = 2;
    void Start()
    {
        okno.SetActive(true);
        switch (enemy[0])
        {
            case "Полоумная медсестра":
                enemy_hp_max = Random.Range(90, 110);
                enemy_hp = enemy_hp_max;
                break;
        }
        enemy_name.text = enemy[0];
        enemy_hp_text.text = enemy_hp + " ОЗ";
        dist_text.text = "" + dist + " м";
        hp.text = Player.Hp + "/" + Player.HpMax + " ОЗ";
        weapon.text = "Оружие - " + Player.weapon + " " + Player.boepripas + "/" + Parametri.Parametr(Player.weapon,2)[0];
        if (Parametri.Parametr(Player.weapon, 1)[0] == 0)
        {
            if (Player.boepripas > 0)
            {
                ataka_text.text = "Прицелиться";
            }
            else
            {
                ataka_text.text = "Перезарядить";
                if(deistvia == 2)
                { }
            }
        }
    }
    public void deistvie_knopka(int variant)
    {
        switch(variant)
        {
            case 0:
                if(ataka_text.text == "Выстрел")
                {
                    deistvia_image[deistvia].sprite = deistvia_sprit[0];
                    deistvia--;
                    Player.boepripas--;
                    switch(Player.Proverka_Tochnosti(0, Parametri.Parametr(Player.weapon, 4)[0]))
                    {
                        case 0: okno.SetActive(true); break;
                        case 1: 
                            enemy_hp -= Parametri.Parametr(Player.weapon, 3)[0];
                            enemy_hp_text.text = enemy_hp + " ОЗ";
                        break;
                    }
                    if (Player.boepripas > 0)
                    {
                        if(Parametri.Parametr(Player.weapon, 1)[1] == 0)
                        {
                            ataka_text.text = "Прицелиться";
                        }
                    }
                    else
                    {
                        ataka_text.text = "Перезарядить";
                        if (deistvia == 2)
                        { }
                    }
                }
                else if(ataka_text.text == "Прицелиться")
                {
                    deistvia_image[deistvia].sprite = deistvia_sprit[0];
                    deistvia--;
                    ataka_text.text = "Выстрел";
                }
            break;
            case 1:break;
            case 2:break;
            case 3:break;
        }
    }
}
