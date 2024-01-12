using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLocalize : MonoBehaviour
{
    public string m_strKey;
    private Text m_txMain;
    void Start()
    {
        m_txMain = GetComponentInChildren<Text>();

        if (m_strKey.Equals("") || m_strKey.Equals(" ")) m_strKey = m_txMain.text;

        m_txMain.text = LoadDictionarys.GetValue(m_strKey);
    }
}
