using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    //Ʋ(SO)�� �̿��� ��ü ������ SO�� ����
    [SerializeField] CharactersSO baseSO;

    //�ٸ� cs���� ������ �б⸸ �ϰ� ������ �Ұ���
    public CharactersSO currentSO { get; private set; }

    private void Awake()
    {
        SOInstantiate();
    }
    private void SOInstantiate()
    {
        currentSO = Instantiate(baseSO);

        //currentSO = new CharactersSO();�� Instantiate�϶�� ����Ƽ�� ����Ѵ�
        //currentSO = new CharactersSO();�ÿ��� ������ �ʵ带 �ʱ�ȭ�ؾ��Ѵ�
        //Instantiate�� �״�� ���� ���´� �̰� �� ���ϴ� ��-��
        //Debug.Log(currentSO.speed);
        //Debug.Log(currentSO.s2);
        //Debug.Log(currentSO.s3);
    }
}
