using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class ShopManagerUi : MonoBehaviour
{
    public GameObject[] m_mgmObject = new GameObject[5];
    [SerializeField]
    private float m_flDuration = 1;

    private bool m_bLeft = false;
    public void Swipeleft(UnityAction Callback = default)
    {
        if (m_bLeft) return;
        m_bLeft = true;
        var PosLL = m_mgmObject[0].transform.position;
        var PosL = m_mgmObject[1].transform.position;
        var PosM = m_mgmObject[2].transform.position;
        var PosR = m_mgmObject[3].transform.position;
        var PosRR = m_mgmObject[4].transform.position;

        var ScaleM = m_mgmObject[2].transform.localScale;
        var ScaleR = m_mgmObject[3].transform.localScale;

        var obLL = m_mgmObject[0];
        var obL = m_mgmObject[1];
        var obM = m_mgmObject[2];
        var obR = m_mgmObject[3];
        var obRR = m_mgmObject[4];

        GameObject[] all = m_mgmObject;

        obLL.SetActive(true);
        obLL.transform.DOMove(PosL,m_flDuration);
        obL.transform.DOMove(PosM,m_flDuration);
        obL.transform.DOScale(ScaleM, m_flDuration);
        obM.transform.DOScale(ScaleR, m_flDuration);
        obM.transform.DOMove(PosR,m_flDuration);
        obR.transform.DOMove(PosRR,m_flDuration).OnComplete(() =>
        {
            var t = new GameObject[5];
            obR.SetActive(false);
            for (int i = 0; i < all.Length;i++)
            {
                int c = i + 1;
                if (c >= all.Length) c = 0;
                t[c] = all[i];
            }

            m_mgmObject = t;
            m_bLeft = false;
            Callback?.Invoke();
        });
        obRR.transform.position = PosLL;

    }
    public void SwipeRight(UnityAction Callback = default)
    {
        if (m_bLeft) return;
        m_bLeft = true;
        var PosLL = m_mgmObject[0].transform.position;
        var PosL = m_mgmObject[1].transform.position;
        var PosM = m_mgmObject[2].transform.position;
        var PosR = m_mgmObject[3].transform.position;
        var PosRR = m_mgmObject[4].transform.position;

        var ScaleM = m_mgmObject[2].transform.localScale;
        var ScaleR = m_mgmObject[3].transform.localScale;

        var obLL = m_mgmObject[0];
        var obL = m_mgmObject[1];
        var obM = m_mgmObject[2];
        var obR = m_mgmObject[3];
        var obRR = m_mgmObject[4];

        GameObject[] all = m_mgmObject;

        obM.transform.DOMove(PosL,m_flDuration);
        obM.transform.DOScale(ScaleR,m_flDuration);
        obL.transform.DOMove(PosLL,m_flDuration);
        obR.transform.DOScale(ScaleM,m_flDuration);
        obR.transform.DOMove(PosM,m_flDuration);
        obRR.SetActive(true);
        obRR.transform.DOMove(PosR, m_flDuration);


        obL.transform.DOMove(PosLL, m_flDuration).OnComplete(() =>
        {
            var t = new GameObject[5];
            obL.SetActive(false);
            for (int i = 0; i < all.Length; i++)
            {
                int c = i - 1;
                if (c < 0) c = all.Length-1;
                t[c] = all[i];
            }

            m_mgmObject = t;
            m_bLeft = false;
            Callback?.Invoke();
        });
        obLL.transform.position = PosRR;

    }
}
