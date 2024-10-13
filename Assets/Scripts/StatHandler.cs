using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    //틀(SO)를 이용해 개체 고유의 SO를 만듦
    [SerializeField] CharactersSO baseSO;

    //다른 cs에서 스텟을 읽기만 하고 변형은 불가능
    public CharactersSO currentSO { get; private set; }

    private void Awake()
    {
        SOInstantiate();
    }
    private void SOInstantiate()
    {
        currentSO = Instantiate(baseSO);

        //currentSO = new CharactersSO();시 Instantiate하라고 유니티가 경고한다
        //currentSO = new CharactersSO();시에는 일일이 필드를 초기화해야한다
        //Instantiate는 그대로 찍혀 나온다 이게 더 편하다 닝-겐
        //Debug.Log(currentSO.speed);
        //Debug.Log(currentSO.s2);
        //Debug.Log(currentSO.s3);
    }
}
