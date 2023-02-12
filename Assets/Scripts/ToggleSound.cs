using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    [SerializeField] AudioListener listener;

    private void Start()
    {
        if (PlayerPrefs.GetInt("soundIsOn", 1) == 1)
        {
            listener.enabled = true;
        }
        else
        {
            listener.enabled = false;
        }
    }

    public void ToggleSoundOnOff(bool toggleTo)
    {
        if (toggleTo)
        {
            PlayerPrefs.SetInt("soundIsOn", 1);

            listener.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("soundIsOn", 0);

            listener.enabled = false;
        }
    }
}
