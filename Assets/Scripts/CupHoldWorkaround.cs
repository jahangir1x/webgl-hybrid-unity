using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHoldWorkaround : MonoBehaviour
{
    [SerializeField] private Animator cupHoldAnimator;

    public void PlayPickAnimation()
    {
        cupHoldAnimator.Play("pick item", -1, 0f);
    }
}