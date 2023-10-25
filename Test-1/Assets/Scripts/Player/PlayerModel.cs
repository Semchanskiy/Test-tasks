using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public string itemInHand;
    public string currentQuest;

    public float _walkSpeed;
    public int _numberCurrentLine;
    [HideInInspector] public float _decelerationSpeed;

    void Awake()
    {
        _numberCurrentLine = 2;
        _decelerationSpeed = _walkSpeed * 2; // ����� �������� ����������� �� ��� �������, ��������� ����� �������� ���������� ���� � 2 ���� ������ �������� ������
    }
}
