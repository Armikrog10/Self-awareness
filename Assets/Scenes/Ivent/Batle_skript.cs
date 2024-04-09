using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Batle_skript : MonoBehaviour
{
    public static List<string> enemy = new List<string>();
    public GameObject okno, enemy_text_window;
    public TMP_Text dist_text, enemy_name, enemy_hp_text;
    public TMP_Text hp, weapon;
    public TMP_Text ataka_text, blok_text, SokDist, RazDist;
    public Sprite[] deistvia_sprit;
    public Image[] deistvia_image;
    public TMP_Text okno_text, enemy_text;
    public static bool iniciativa = false;
    public static float dist = 0;
    int enemy_hp = 0, enemy_hp_max = 0, enemy_deistviAAA = 0, enemy_deistviAAA_Max = 0, enemy_skorost_min = 0, enemy_skorost_max = 0;
    int deistvia = 3;
    int enemy_deistvie = 0;
    void Start()
    {
        switch (enemy[0])
        {
            case "��������� ���������":
                enemy_hp_max = Random.Range(90, 110);
                enemy_hp = enemy_hp_max;
                enemy_skorost_min = 10;
                enemy_skorost_max = 30;
                enemy_deistviAAA_Max = 2;
                enemy_deistviAAA = enemy_deistviAAA_Max;
                break;
        }
        enemy_name.text = enemy[0];
        enemy_hp_text.text = enemy_hp + "/" + enemy_hp_max + " ���";
        dist_text.text = "" + dist + " �";
        hp.text = Player.Hp + "/" + Player.HpMax + " ��";
        weapon.text = "������ - " + Player.weapon + " " + Player.boepripas + "/" + Parametri.Parametr(Player.weapon,2)[0];
        if (Parametri.Parametr(Player.weapon, 1)[0] == 0)
        {
            if (Player.boepripas > 0)
            {
                ataka_text.text = "�����������";
            }
            else
            {
                ataka_text.text = "������������";
                if(deistvia == 2)
                { }
            }
        }
    }
    void VizovOkna(string nadpis)
    {
        if(okno.activeSelf == true)
        { 
            okno.SetActive(false);
            okno.SetActive(true);
        }
        else
        {
            okno.SetActive(true);
        }
        okno_text.text = nadpis;
    }
    public void EnemyWindow()
    {
        int enemy_hp_procent = enemy_hp * 100 / enemy_hp_max;
        int hp_procent = Player.Hp * 100 / Player.HpMax;
        void enemy_distancia(int a)
        {
            dist += (Random.Range(enemy_skorost_min, enemy_skorost_max) / 10f)*a;
            dist = (float)System.Math.Round(dist, 1);
            if(dist < 1)
            {
                dist = 1;
            }
            dist_text.text = "" + dist + " �";
        }
        if (enemy_deistviAAA > 0)
        {
            if (enemy_deistvie == 0)
            {
                if (enemy_hp_procent >= 70)
                {
                    if (dist <= 1f)
                    {
                        enemy_deistvie = 1;
                        enemy_text.text = "��������� ��������� � �����";
                    }
                    else
                    {
                        enemy_distancia(-1);
                        enemy_text.text = "��������� ������������ � ���";
                    }
                }
                else if (enemy_hp_procent >= 30)
                {
                    if (dist <= 1f)
                    {
                        if (Parametri.Parametr(Player.weapon, 1)[0] == 2)
                        {
                            if (enemy_deistvie == 2)
                            {
                                enemy_deistvie = 1;
                                enemy_text.text = "��������� ��������� � �����";
                            }
                            else
                            {
                                enemy_deistvie = 3;
                                enemy_text.text = "��������� �������� �������� ����";
                            }
                        }
                        else
                        {
                            enemy_deistvie = 1;
                            enemy_text.text = "��������� ��������� � �����";
                        }
                    }
                    else
                    {
                        if (Parametri.Parametr(Player.weapon, 1)[0] == 2)
                        {
                            if (dist <= 3)
                            {
                                enemy_distancia(1);
                                enemy_text.text = "��������� ������� �� ���";
                            }
                            else
                            {
                                enemy_deistvie = 2;
                                enemy_text.text = "��������� �������� ������ ���� ����";
                            }
                        }
                        else
                        {
                            enemy_distancia(-1);
                            enemy_text.text = "��������� ������������ � ���";
                        }
                    }
                }
                else
                {
                    if (dist <= 1f)
                    {
                        if (Parametri.Parametr(Player.weapon, 1)[0] == 2)
                        {
                            enemy_distancia(1);
                            enemy_text.text = "��������� ������� �� ���";
                        }
                        else
                        {
                            enemy_deistvie = 2;
                            enemy_text.text = "��������� �������� ������ ���� ����";
                        }
                    }
                    else
                    {
                        if (Parametri.Parametr(Player.weapon, 1)[0] == 2)
                        {
                            if (dist <= 5)
                            {
                                enemy_distancia(1);
                                enemy_text.text = "��������� ������� �� ���";
                            }
                            else
                            {
                                enemy_deistvie = 2;
                                enemy_text.text = "��������� �������� ������ ���� ����";
                            }
                        }
                        else
                        {
                            enemy_distancia(-1);
                            dist_text.text = "" + dist + " �";
                            enemy_text.text = "��������� ������������ � ���";
                        }
                    }
                }
            }
            else
            {
                switch (enemy_deistvie)
                {
                    case 1:
                        if (dist <= 1f)
                        {
                            switch (Player.Proverka_Lovkosti(0))
                            {
                                case 0:
                                    int yron = Random.Range(10, 20);
                                    Player.Hp -= yron;
                                    VizovOkna("-" + yron + " ��");
                                    enemy_text.text = "��������� ������� ���" + yron + " �����";
                                    hp.text = Player.Hp + "/" + Player.HpMax + " ��";
                                    break;
                                case 1: enemy_text.text = "��������� ������������� �� ���"; break;
                            }
                        }
                        else
                        {
                            enemy_text.text = "��������� �� ������������ �� ��� ����� ������";
                        }
                        enemy_deistvie = 0;
                        break;
                    case 2:
                        int hill = Random.Range(10, 30);
                        enemy_hp += hill;
                        enemy_text.text = "��������� ������������ " + hill + " ����� ������ ��������";
                        enemy_hp_text.text = enemy_hp + "/" + enemy_hp_max + " ���";
                        enemy_deistvie = 0;
                        break;
                }
            }
            enemy_deistviAAA--;
        }
        else
        {
            enemy_text_window.SetActive(false);
            deistvia = 3;
            for(int i = 0; i < 3; i++)
            {
                deistvia_image[i].sprite = deistvia_sprit[1];
            }
        }
    }
    public void deistvie_knopka(int variant)
    {
        if (deistvia > 0)
        {
            deistvia_image[deistvia-1].sprite = deistvia_sprit[0];
            deistvia--;
            switch (variant)
            {
                case 0:
                    if (ataka_text.text == "�������")
                    {
                        Player.boepripas--;
                        weapon.text = "������ - " + Player.weapon + " " + Player.boepripas + "/" + Parametri.Parametr(Player.weapon, 2)[0];
                        switch (Player.Proverka_Tochnosti(0, Parametri.Parametr(Player.weapon, 4)[0]))
                        {
                            case 0: VizovOkna("������"); break;
                            case 1:
                                VizovOkna("-"+Parametri.Parametr(Player.weapon, 3)[0]+" ���");
                                enemy_hp -= Parametri.Parametr(Player.weapon, 3)[0];
                                enemy_hp_text.text = enemy_hp + "/" + enemy_hp_max + " ���";
                                break;
                        }
                        if (Player.boepripas > 0)
                        {
                            if (Parametri.Parametr(Player.weapon, 1)[1] == 0)
                            {
                                ataka_text.text = "�����������";
                            }
                        }
                        else
                        {
                            ataka_text.text = "������������";
                            if (deistvia == 3)
                            { }
                        }
                    }
                    else if (ataka_text.text == "�����������")
                    {
                        if (dist >= 3.5f)
                        {
                            ataka_text.text = "�������";
                        }
                        else
                        {
                            VizovOkna("������� ������");
                        }
                    }
                    break;
                case 1: break;
                case 2: dist -= (float)System.Math.Round(Player.DexStat / 3f, 1); if (dist < 1) { dist = 1; } dist_text.text = "" + dist + " �"; break;
                case 3: dist += (float)System.Math.Round(Player.DexStat / 3f, 1); dist_text.text = "" + dist + " �"; break;
            }
        }
        if(deistvia <= 0)
        {
            enemy_text_window.SetActive(true);
            enemy_deistviAAA = enemy_deistviAAA_Max;
            enemy_text.text = "��� ����������";
        }
    }
}
