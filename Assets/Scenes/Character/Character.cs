using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public TMP_Text Name, Hp, Str, Dex, Dur, Char, Self, Des;

    public Button Description, Skills;
    public TMP_Text DescriptionText, SkillsText;
    public Image Podlozka1, Podlozka2;

    bool Skill = true;

    static int gameClassNamder = 0;
    private void vivod_stat()
    {
        Name.SetText(Parametri.gameClass[gameClassNamder].Item1);
        Hp.SetText(Parametri.gameClass[gameClassNamder].Item2.ToString());
        Str.SetText(Parametri.gameClass[gameClassNamder].Item3.ToString());
        Dex.SetText(Parametri.gameClass[gameClassNamder].Item4.ToString());
        Dur.SetText(Parametri.gameClass[gameClassNamder].Item5.ToString());
        Char.SetText(Parametri.gameClass[gameClassNamder].Item6.ToString());
        Self.SetText(Parametri.gameClass[gameClassNamder].Item7.ToString());
        if (Skill)
        {
            Des.SetText(Parametri.ClassSkillDes[gameClassNamder]);
        }
    }
    public void gameClassNamderPlus()
    {
        if (gameClassNamder < 5)
        {
            gameClassNamder++;
        }
        else
        {
            gameClassNamder = 0;
        }
        vivod_stat();
    }
    public void gameClassNamderMinus()
    {
        if (gameClassNamder > 0)
        {
            gameClassNamder--;
        }
        else
        {
            gameClassNamder = 5;
        }
        vivod_stat();
    }
    public void ButtonDescription()
    {
        Description.interactable = false;
        Skills.interactable = true;
        DescriptionText.color = new Color(255, 255, 255);
        SkillsText.color = new Color(0, 0, 0);
        Podlozka1.enabled = false;
        Podlozka2.enabled = true;
        Skill = false;
        Des.SetText("Здоровье - отечает за колличество вашего здоровья.\n" +
            "Сила - отвечает за колличества урона которое вы наносите в ближнем бою.\n" +
            "Ловкость - отвечает за успешность манёвров и точность.\n" +
            "Стойкость - отвечает за снижение получаемого урона.\n" +
            "Харизма - отвечает за навык общения.");
    }
    public void ButtonSkills()
    {
        Description.interactable = true;
        Skills.interactable = false;
        DescriptionText.color = new Color(0, 0, 0);
        SkillsText.color = new Color(255, 255, 255);
        Podlozka1.enabled = true;
        Podlozka2.enabled = false;
        Skill = true;
        Des.SetText(Parametri.ClassSkillDes[gameClassNamder]);
    }
    public void Dalee()
    {
        SceneManager.LoadScene("Map");
        Player.gameClass = gameClassNamder;
        Player.HpStat = Parametri.gameClass[gameClassNamder].Item2;
        Player.StrStat = Parametri.gameClass[gameClassNamder].Item3;
        Player.DexStat = Parametri.gameClass[gameClassNamder].Item4;
        Player.DurStat = Parametri.gameClass[gameClassNamder].Item5;
        Player.CharStat = Parametri.gameClass[gameClassNamder].Item6;
        Player.Self = Parametri.gameClass[gameClassNamder].Item7;
    }
    public void Nazad()
    {
        SceneManager.LoadScene("Menu");
    }

    void Start()
    {
        vivod_stat();
    }
}
