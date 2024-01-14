using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager
{
    public static event UnityAction<int> m_evValueCh;

    private static int _m_inCoin;

    private static bool m_bInit = false;
    public static bool Init()
    {
        if (m_bInit) return true;

        m_inCoin = PlayerPrefs.GetInt("coins");
        m_bInit = true;

        return true;
    }

    public static int m_inCoin
    {
        get
        {
            Init();
            return _m_inCoin;
        }
        set
        {
            _m_inCoin = value;
            if (_m_inCoin < 0) _m_inCoin = 0;
            PlayerPrefs.SetInt("coins", _m_inCoin);
            m_evValueCh?.Invoke(_m_inCoin);
        }
    }
}
public class SkinManager
{

    private static PlayerSettings _m_siscrSkins;
    public static PlayerSettings m_siscrSkins
    {
        get
        {
            if (!_m_siscrSkins) _m_siscrSkins = Resources.LoadAll<PlayerSettings>("Skin")[0];
            return _m_siscrSkins;
        }
        private set { _m_siscrSkins = value; }
    }

    public static event UnityAction<int> m_evValueCh;

    private static int _m_inSkinId;

    private static bool m_bInit = false;
    public static bool Init()
    {
        if (m_bInit) return true;

        m_inSkinId = PlayerPrefs.GetInt("skin");
        m_bInit = true;

        return true;
    }

    public static int m_inSkinId
    {
        get
        {
            Init();
            return _m_inSkinId;
        }
        set
        {

            if(!Bought(value)) return;

            _m_inSkinId = value;

            if (_m_inSkinId < 0) _m_inSkinId = 0;

            PlayerPrefs.SetInt("skin", _m_inSkinId);
            m_evValueCh?.Invoke(_m_inSkinId);
        }
    }
    public static bool Bought(int index)
    {
        if (PlayerPrefs.GetInt("skin" + index.ToString(), 0) == 0) return false;
        return true;
    }
    public static void SetSkin(Image gm, PlayerSkinSettings pl, Sprite Default = default)
    {
        if (pl is PlayerSkinColored c)
        {
            gm.color = c.m_clColor;
            gm.sprite = Default;
        }
        else if (pl is PlayerSkinPng p)
        {
            gm.color = Color.white;
            gm.sprite = p.m_sprSprite;
        }
    }
    public static void SetPlayerSkin(Image gm)=> SetSkin(gm, m_siscrSkins.m_lsSkins[m_inSkinId]);
    public static bool BuySkin(int Id)
    {
        if(CoinManager.m_inCoin >= GetSkin(Id).m_inCost && !Bought(Id))
        {
            CoinManager.m_inCoin -= GetSkin(Id).m_inCost;
            PlayerPrefs.SetInt("skin" + Id.ToString(), 1);
            return true;
        }
        return true;
    }

    public static bool CanBuy(int Id)
    {
        if (m_siscrSkins.m_lsSkins[Id].m_inCost > CoinManager.m_inCoin) return false;

        return true;
    }
    public static PlayerSkinSettings GetSkin(int Id) => m_siscrSkins.m_lsSkins[Id];


}