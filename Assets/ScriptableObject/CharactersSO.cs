using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharaterBaseSO", menuName = "ChaBaseSO/Base", order = 0)]
//캐릭터 스텟의 틀 역할만 StatHandler를통해 새로운 SO객체를 생성해 개체마다 고유 스텟을 가지게 할것
public class CharactersSO : ScriptableObject
{
    [Header("BasicStat")]
    public float speed;
    public float s2;//테스트용 의미없는 스텟
    public float s3;//테스트용 의미없는 스텟
}
