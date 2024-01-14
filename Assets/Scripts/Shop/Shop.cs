using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Image m_imChLeft, m_imChRight;
    [SerializeField]
    private Button m_btLeft,m_btRight;

    private PlayerSettings _m_lsObjectForBuy;
    public PlayerSettings m_lsObjectForBuy
    {
        get
        {
            if (!_m_lsObjectForBuy) _m_lsObjectForBuy = CoinManager.m_siscrSkins;
            return _m_lsObjectForBuy;
        }
        private set { _m_lsObjectForBuy = value; }
    }
    [SerializeField]
    private Sprite m_sprDefault;

    [SerializeField]
    private Image m_imLeft, m_imMiddle, m_imRight;

    private int _m_inCurPos = 0;
    private int m_inCurPos
    {
        get => _m_inCurPos;
        set
        {
            _m_inCurPos = value;
            if (_m_inCurPos >= m_lsObjectForBuy.m_lsSkins.Count) _m_inCurPos = 0;
            else if (_m_inCurPos < 0) _m_inCurPos = m_lsObjectForBuy.m_lsSkins.Count - 1;
        }
    }
    public void Start()
    {
        var c = GetComponent<ShopManagerUi>();
        SetCur();
        if (m_btLeft) m_btLeft.onClick.AddListener(() =>
          {
              c.SwipeRight(() =>
              {
                  m_inCurPos++;
                  m_imChRight = c.m_mgmObject[c.m_mgmObject.Length -1].GetComponent<Image>();
                  SetRRight();
              });
          });
        if (m_btRight) m_btRight.onClick.AddListener(() =>
        {

            c.Swipeleft(()=> 
            {
                m_inCurPos--;
                m_imChLeft = c.m_mgmObject[0].GetComponent<Image>();
                SetLLeft();
            });
        });
    }

    public void SetCur()
    {
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
        else SetSkin(m_imLeft, Left);
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
        SetSkin(m_imMiddle, current);
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
    public void SetSkin(Image gm,PlayerSkinSettings pl)
    {
        if (pl is PlayerSkinColored c)
        {
            
            gm.color = c.m_clColor ;
            gm.sprite = m_sprDefault;
        }
        else if (pl is PlayerSkinPng p)
        {
            gm.color = Color.white;
            gm.sprite = p.m_sprSprite;
        }
    }
}

[System.Serializable]
class ShopSlot
{
    public int m_inCost;
    public PlayerSkinSettings m_scrSkin;
}
