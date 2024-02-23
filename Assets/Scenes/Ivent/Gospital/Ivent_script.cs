using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ivent_script : MonoBehaviour
{
    int variant = 0;
    List<int> iteracia = new List<int>();
    public TMP_Text Sobitie;
    public TMP_Text[] Deistvie_text;
    public Button[] Deistvie;
    void drop_button()
    {
        for (int i = 0; i < 3; i++)
        {
            Deistvie_text[i].text = "";
            Deistvie[i].interactable = false;
        }
    }
    void active_button(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Deistvie[i].interactable = true;
        }
    }
    public void Vibor1()
    {
        if (Deistvie_text[0].text == "> ����")
        {
            SceneManager.LoadScene("Map");
        }
        drop_button();
        if (variant == 1)
        {
            switch(iteracia.Count)
            {
                case 0:
                    int podVariant = Random.Range(0, 3);
                    if (podVariant == 1)
                    {
                        iteracia.Add(podVariant);
                        string Text_soob = "�� �����: ";
                        int kol_predmetov = Player.Proverka_Ydachi(new int[] { 30, 50, 18, 2 });
                        string[] predmeti = new string[5];
                        for (int i = 0; i < kol_predmetov + 1; i++)
                        {
                            int random_predmet = Random.Range(0, 4);
                            predmeti[i] = Parametri.predmet[random_predmet];
                            if (i < kol_predmetov)
                            {
                                Text_soob += Parametri.predmet[random_predmet] + ", ";
                            }
                            else
                            {
                                Text_soob += Parametri.predmet[random_predmet];
                            }
                        }
                        Player.nahodki = predmeti;
                        Sobitie.text = Text_soob;
                        active_button(2);
                        Deistvie_text[0].text = "> �����";
                        Deistvie_text[1].text = "> ����";
                    }
                    else if(podVariant == 0)
                    {
                        iteracia.Add(podVariant);
                        Sobitie.text = "�� ������ �� �����";
                        active_button(1);
                        Deistvie_text[0].text = "> ����";
                    }
                    else if(podVariant == 2)
                    {
                        iteracia.Add(podVariant);
                        string Text_soob = "�� �����: ";
                        int kol_predmetov = Player.Proverka_Ydachi(new int[] { 30, 50, 18, 2 });
                        string[] predmeti = new string[5];
                        for (int i = 0; i < kol_predmetov + 1; i++)
                        {
                            int random_predmet = Random.Range(0, 4);
                            predmeti[i] = Parametri.predmet[random_predmet];
                            if (i < kol_predmetov)
                            {
                                Text_soob += Parametri.predmet[random_predmet] + ", ";
                            }
                            else
                            {
                                Text_soob += Parametri.predmet[random_predmet];
                            }
                        }
                        Player.nahodki = predmeti;
                        Sobitie.text = Text_soob + "\n�� ��� ������������ ��������� ��������� � ��������� �� ���";
                        active_button(2);
                        Deistvie_text[0].text = "> �������, ������ �����������";
                        Deistvie_text[1].text = "> ������� ���";
                    }
                break;
                case 1:
                    if (iteracia[iteracia.Count-1] == 1)
                    {
                        SceneManager.LoadScene("Nahodki");
                    }
                    else if(iteracia[iteracia.Count - 1] == 2)
                    {
                        SceneManager.LoadScene("Map");
                    }
                break;
            }
        }
        else if(variant == 0)
        {
            switch (iteracia.Count)
            {
                case 0:
                    iteracia.Add(0);
                    Sobitie.text = "��������� ������ ��������� �� ��� ������� ����� �������������� ������� � ����� �� ���� ����";
                    Player.yslyga = "�������";
                    active_button(2);
                    Deistvie_text[0].text = "> �����������";
                    Deistvie_text[1].text = "> ����";
                    break;
                case 1:
                    SceneManager.LoadScene("Yslygi");
                    break;
            }
        }
    }
    public void Vibor2()
    {
        if (Deistvie_text[1].text == "> ����")
        {
            SceneManager.LoadScene("Map");
        }
        drop_button();
        if (variant == 0 && iteracia.Count == 0)
        {
            iteracia.Add(Player.Proverka_Harizmi(0));
            switch (iteracia[iteracia.Count - 1])
            {
                case 0:
                    Sobitie.text = "���� ������� ������� ���-�� � ������ ���������, � ��� ������� ���";
                    active_button(1);
                    Deistvie_text[0].text = "> �����"; break;
                case 1:
                    Sobitie.text = "��������� ������� ����� ����� ����, �� ����� �������� ������� ���\n�������� ���������� �� ���������";
                    Player.Hp = Player.HpMax;
                    active_button(1);
                    Deistvie_text[0].text = "> ����"; break;
            }
        }
        else if(variant == 1)
        {
            switch(iteracia.Count)
            {
                case 1:
                    Batle_skript.enemy.Add("��������� ���������");
                    SceneManager.LoadScene("Batle"); break;
            }
        }
    }
    public void Vibor3()
    {
        if (Deistvie_text[2].text == "> ����")
        {
            SceneManager.LoadScene("Map");
        }
        drop_button();
    }
    void Start()
    {
        variant = Random.Range(0, 2);
        if(variant == 0)
        {
            Sobitie.text = "������ ���������, � ������� ����� ������ ������, �� ������, �� ���������. ��� �� �����, ��� ��������� ��������� �� ����� ��������";
            active_button(3);
            Deistvie_text[0].text = "> ������������ � �������";
            Deistvie_text[1].text = "> ��������� � ������������ �������";
            Deistvie_text[2].text = "> ����";
        }
        else if (variant == 1)
        {
            Sobitie.text = "������ ���������, � ������� ����� ������ ���";
            active_button(2);
            Deistvie_text[0].text = "> ������ ����������";
            Deistvie_text[1].text = "> ����";
        }
    }
}
