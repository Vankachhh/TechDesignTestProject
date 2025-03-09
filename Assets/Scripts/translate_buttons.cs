using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class translate_buttons : MonoBehaviour
{
    void Start()
    {
        int ID = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLocale(ID);
    }
    private bool active = false;
    public void ChangeLocale(int localeID)
    {
        if(active == true)
        {
            return;
        }
        StartCoroutine(SetLocate(localeID));
    }

    IEnumerator SetLocate(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        PlayerPrefs.SetInt("LocaleKey", _localeID);
        active = false;
    }
}
