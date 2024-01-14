using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    private int _m_inCurPos = 0;
    private int m_inCurPos
    {
        get => _m_inCurPos;
        set
        {
            _m_inCurPos = value;
            if (_m_inCurPos >= m_lsObjectForBuy.m_lsSkins.Count) _m_inCurPos = 0;
            else if (_m_inCurPos < 0) _m_inCurPos = m_lsObjectForBuy.m_lsSkins.Count - 1;
            if (m_btBuyOrEquip) OnFocusCh();
        }
    }


    public void Start()
    {
        m_inCurPos = SkinManager.m_inSkinId;
        SetupVisualizer();
        SetupBuyMethod();


    }

    #region Visualize
    [Header("Visualize")]
    public Image m_imChLeft;
    public Image m_imChRight;
    [SerializeField]
    private Button m_btLeft, m_btRight;

    private PlayerSettings _m_lsObjectForBuy;
    public PlayerSettings m_lsObjectForBuy
    {
        get
        {
            if (!_m_lsObjectForBuy) _m_lsObjectForBuy = SkinManager.m_siscrSkins;
            return _m_lsObjectForBuy;
        }
        private set { _m_lsObjectForBuy = value; }
    }
    [SerializeField]
    private Sprite m_sprDefault;

    [SerializeField]
    private Image m_imLeft, m_imMiddle, m_imRight;
    public void SetupVisualizer()
    {
        var c = GetComponent<ShopManagerUi>();
        if (m_btLeft) m_btLeft.onClick.AddListener(() =>
        {
            m_btBuyOrEquip.interactable = false;
            c.SwipeRight(() =>
            {
                m_inCurPos++;
                m_imChRight = c.m_mgmObject[c.m_mgmObject.Length - 1].GetComponent<Image>();
                SetRRight();

            });
        });
        if (m_btRight) m_btRight.onClick.AddListener(() =>
        {
            m_btBuyOrEquip.interactable = false;
            c.Swipeleft(() =>
            {
                m_inCurPos--;
                m_imChLeft = c.m_mgmObject[0].GetComponent<Image>();
                SetLLeft();
            });
        });
        SetLeft();
        SetCenter();
        SetRight();
        SetLLeft();
        SetRRight();
    }
    public void SetLeft()
    {
        var l = m_inCurPos - 1;
        if (l < 0) l = m_lsObjectForBuy.m_lsSkins.Count - 1;
        var Left = m_lsObjectForBuy.m_lsSkins[l] == null ? null : m_lsObjectForBuy.m_lsSkins[l];
        if (l == m_inCurPos) Left = null;

        if (Left == null) Destroy(m_imLeft.gameObject);
        else SkinManager.SetSkin(m_imLeft, Left, m_sprDefault);
    }
    public void SetRight()
    {
        var r = m_inCurPos + 1;
        if (r >= m_lsObjectForBuy.m_lsSkins.Count) r = 0;
        var Right = m_lsObjectForBuy.m_lsSkins[r] == null ? null : m_lsObjectForBuy.m_lsSkins[r];
        if (r == m_inCurPos) Right = null;


        if (Right == null) Destroy(m_imRight.gameObject);
        else SetSkin(m_imRight, Right);
    }
    public void SetCenter()
    {
        var current = m_lsObjectForBuy.m_lsSkins[m_inCurPos];
        SkinManager.SetSkin(m_imMiddle, current, m_sprDefault);
    }
    public void SetLLeft()
    {
        var l = m_inCurPos - 1;
        if (l == 0) l = m_lsObjectForBuy.m_lsSkins.Count - 1;
        else if (l == -1) l = m_lsObjectForBuy.m_lsSkins.Count - 2;
        else l--;

        var Left = m_lsObjectForBuy.m_lsSkins[l] == null ? null : m_lsObjectForBuy.m_lsSkins[l];

        if (m_imChLeft) SetSkin(m_imChLeft, Left);
    }
    public void SetRRight()
    {
        var l = m_inCurPos + 1;
        if (l == m_lsObjectForBuy.m_lsSkins.Count -1) l = 0;
        else if (l >= m_lsObjectForBuy.m_lsSkins.Count) l = 1;
        else l++;

        var Right = m_lsObjectForBuy.m_lsSkins[l] == null ? null : m_lsObjectForBuy.m_lsSkins[l];
        if (m_imChLeft) SetSkin(m_imChRight, Right);
    }

    public void SetSkin(Image gm,PlayerSkinSettings Sets) => SkinManager.SetSkin(gm, Sets, m_sprDefault);
    #endregion

    #region Buy
    [Space(10)]
    [Header("Buy Method")]
    [SerializeField]
    private Button m_btBuyOrEquip;

    private void SetupBuyMethod()
    {
        if(m_btBuyOrEquip) m_btBuyOrEquip.onClick.AddListener(() =>
        {
            if (!SkinManager.Bought(m_inCurPos))
                OnBuy();
            else
                OnEquip();

        });
    }
    public void OnBuy()
    {
        if(SkinManager.BuySkin(m_inCurPos)) m_inCurPos = m_inCurPos;

    }
    public void OnEquip()
    {
        SkinManager.m_inSkinId = m_inCurPos;
        m_inCurPos = m_inCurPos;
    }
    public void OnFocusCh()
    {
        var text = m_btBuyOrEquip.GetComponentInChildren<Text>();
        if (SkinManager.Bought(m_inCurPos))
        {
            if(m_inCurPos == SkinManager.m_inSkinId)
            {
                m_btBuyOrEquip.interactable = false;
                text.text = LoadDictionarys.GetValue("Equiped");
            }
            else
            {
                m_btBuyOrEquip.interactable = true;
                text.text = LoadDictionarys.GetValue("Equip");
            }
        }
        else
        {
            m_btBuyOrEquip.onClick.RemoveListener(OnEquip);
            if (SkinManager.CanBuy(m_inCurPos))
            {
                m_btBuyOrEquip.interactable = true;
                text.text = SkinManager.GetSkin(m_inCurPos).m_inCost.ToString();
            }
            else
            {
                m_btBuyOrEquip.interactable = false;
                text.text = LoadDictionarys.GetValue("You can't buy") + $"Cost:{SkinManager.GetSkin(m_inCurPos).m_inCost}";
            }
        }
    }
    #endregion
    public void Exit() => SceneManager.LoadScene(0);
}

[System.Serializable]
class ShopSlot
{
    public int m_inCost;
    public PlayerSkinSettings m_scrSkin;
}
