using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharaterBaseSO", menuName = "ChaBaseSO/Base", order = 0)]
public class CharactersSO : ScriptableObject
{
    [Header("BasicStat")]
    public float speed;
}
