using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
   public void Back_Map()
    {
        SceneManager.LoadScene("Map");
    }
    public void Batle()
    {
        SceneManager.LoadScene("Batle");
    }
}
