﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject credits;

    public void HideCredits()
    {
        credits.SetActive(false);
    }
}
