using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharaterBaseSO", menuName = "ChaBaseSO/Base", order = 0)]
//ĳ���� ������ Ʋ ���Ҹ� StatHandler������ ���ο� SO��ü�� ������ ��ü���� ���� ������ ������ �Ұ�
public class CharactersSO : ScriptableObject
{
    [Header("BasicStat")]
    public float speed;
    public float s2;//�׽�Ʈ�� �ǹ̾��� ����
    public float s3;//�׽�Ʈ�� �ǹ̾��� ����
}
