using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class jhsdbdgf : MonoBehaviour
{
    public static void Nachalo()
    {
        PlayerPrefs.SetFloat("C1", Map.Target.x);
        PlayerPrefs.SetFloat("C2", Map.Target.y);
        SceneManager.LoadScene("Gospital");
    }
}
