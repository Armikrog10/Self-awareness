using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Batle_skript : MonoBehaviour
{
    public static List<string> enemy = new List<string>();
    public TMP_Text dist_text, enemy_name, enemy_hp_text;
    public TMP_Text hp, weapon;
    public Sprite[] deistvia_sprit;
    public Image[] deistvia_image;
    int deistvia = 3, dist = 0, enemy_hp = 0;
    void Start()
    {
        enemy_name.text = enemy[0];
        enemy_hp_text.text = "" + enemy_hp;
        dist_text.text = "" + dist + " м";
        hp.text = Player.Hp + "/" + Player.HpMax + " ОЗ";
        weapon.text = "Оружие - " + Player.weapon + " " + Player.boepripas + "/" + Parametri.Parametr(Player.weapon,2);
    }
}
