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
        _decelerationSpeed = _walkSpeed * 2; // чтобы персонаж остановился за пол секунды, требуется чтобы скорость замедления была в 2 раза больше скорости игрока
    }
}
