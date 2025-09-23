using UnityEngine;

public class linetoggle : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider2D BC2D;
    public bool AfterKey;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        BC2D = GetComponent<BoxCollider2D>();
    }

    public void setHasKey(bool value) {
        sr.enabled = value ^ AfterKey;
        BC2D.enabled = sr.enabled;
    }
}
