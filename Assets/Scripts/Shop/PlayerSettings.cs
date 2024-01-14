using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Settings",menuName ="Create/New settings Skins")]
public class PlayerSettings : ScriptableObject
{
    public List<PlayerSkinSettings> m_lsSkins = new List<PlayerSkinSettings>();
}
