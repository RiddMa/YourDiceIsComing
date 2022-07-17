using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}