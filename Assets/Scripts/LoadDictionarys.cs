using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Language
{
    En,
    Ua
}
public class LoadDictionarys : MonoBehaviour
{
    private static Dictionary<string, string> m_dcAllWord = new Dictionary<string, string>();
    private static Language m_enSavCh;
    public static Language m_enChangebl
    {
        get => m_enSavCh;
        set
        {
            m_enSavCh = value;
            PlayerPrefs.SetInt("Language", (int)m_enSavCh);
        }
    }
    public static bool m_bInit;

    private static bool Init()
    {
        if (m_bInit) return true;

        LocalizeSettings lcst = Resources.Load<LocalizeSettings>("localize");
        if (!lcst)
        {
            Debug.LogError("You dont have localize File");
            return false;
        }
        m_enSavCh = (Language)PlayerPrefs.GetInt("Language");
        if (lcst.m_lLanguage.Count > 0)
        {
            foreach (Word lg in lcst.m_lLanguage[(int)m_enChangebl].m_lisAllWards)
            {
                m_dcAllWord.Add(lg.m_strKey, lg.m_strValue);
            }

        }
        m_bInit = true;
        return true;
    }
    public static string GetValue(string Key)
    {
        if (!Init()) return Key;

        m_dcAllWord.TryGetValue(Key, out string value);
        value ??= Key;
        return value;
    }
}
