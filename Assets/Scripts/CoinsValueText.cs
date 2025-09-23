using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CoinsValueText : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();

        text.text = "x " + CoinManager.m_inCoin.ToString();

        CoinManager.m_evValueCh += OnCoinCh;
    }
    public void OnDestroy()
    {
        CoinManager.m_evValueCh -= OnCoinCh;
    }
    public void OnCoinCh(int c)
    {
        text.text = "x " + c.ToString();
    }
}
