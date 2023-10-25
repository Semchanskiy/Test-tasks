using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;

public class PlayerView : MonoBehaviour
{
    [HideInInspector] public bool _isFacingRight = true;

    [HideInInspector] public Animator Animator;
    [HideInInspector] private Transform _transform;

    void Awake()
    {
        Animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    

    public void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _transform.Rotate(.0f,180f,.0f);
    }

    public void ChangeScale(float value) //изменение размера пероснажа в зависимости от того отдаляется он или приближается
    {
        UnityEngine.Vector3 scalevalue = new UnityEngine.Vector3(0.3f,0.3f,0.3f) * -value;
        _transform.DOScale(_transform.localScale + scalevalue, 1f);
    }
}
