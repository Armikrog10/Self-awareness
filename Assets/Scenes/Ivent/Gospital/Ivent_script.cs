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
    public TMP_Text[] Deistvie_text = new TMP_Text[3];
    public Button[] Deistvie = new Button[3];
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
        if (Deistvie_text[0].text == "> Уйти")
        {
            SceneManager.LoadScene("Map");
        }
        drop_button();
        if (variant == 1 && iteracia.Count == 0)
        {
            iteracia.Add(0);//заглушка!!!!!!!!!1
            string Text_soob = "Вы нашли: ";
            int kol_predmetov = Player.Proverka_Ydachi(new int[]{30, 50, 18, 2});
            List<string> predmeti = new List<string>();
            for (int i = 0; i < kol_predmetov+1; i++)
            {
                int random_predmet = Random.Range(0, 4);
                predmeti.Add(Parametri.predmet[random_predmet]);
                if(i < kol_predmetov)
                {
                    Text_soob += Parametri.predmet[random_predmet] + ", ";
                }
                else
                {
                    Text_soob += Parametri.predmet[random_predmet];
                }
            }
            Player.Add_Inventar(predmeti);
            Sobitie.text = Text_soob;
            active_button(1);
            Deistvie_text[0].text = "> Уйти";
        }
    }
    public void Vibor2()
    {
        if (Deistvie_text[1].text == "> Уйти")
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
                    Sobitie.text = "Ваша просьба двинула что-то в голове медсестры, и она атакует вас";
                    active_button(1);
                    Deistvie_text[0].text = "> Далее"; break;
                case 1:
                    Sobitie.text = "Медсестра застыла после ваших слов, но после медленно кивнула вам\nЗдоровье восполнено до максимума";
                    active_button(1);
                    Deistvie_text[0].text = "> Далее"; break;
            }
        }
    }
    public void Vibor3()
    {
        if (Deistvie_text[2].text == "> Уйти")
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
            Sobitie.text = "Старый госпиталь, в котором давно никого небыло, не врачей, не пациентов. Тем не менее, вас встречает медсестра на грани полоумия";
            active_button(3);
            Deistvie_text[0].text = "> Договориться о лечении";
            Deistvie_text[1].text = "> Попросить о бескорыстном лечении";
            Deistvie_text[2].text = "> Уйти";
        }
        if (variant == 1)
        {
            Sobitie.text = "Старый госпиталь, в котором давно никого нет";
            active_button(2);
            Deistvie_text[0].text = "> Искать медикометы";
            Deistvie_text[1].text = "> Уйти";
        }
    }
}
