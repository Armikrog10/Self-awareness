using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public TMP_Text Name, Hp, Str, Dex, Dur, Char, Self, Des;

    public Button Description, Skills;
    public TMP_Text DescriptionText, SkillsText;
    public Image Podlozka1, Podlozka2;

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
    }
    public void ButtonSkills()
    {
        Description.interactable = true;
        Skills.interactable = false;
        DescriptionText.color = new Color(0, 0, 0);
        SkillsText.color = new Color(255, 255, 255);
        Podlozka1.enabled = true;
        Podlozka2.enabled = false;
    }

    void Start()
    {
        vivod_stat();
    }
}
