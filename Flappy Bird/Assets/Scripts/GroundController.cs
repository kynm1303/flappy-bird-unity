﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController: MonoBehaviour
{
    private GroundCollider groundCollider;
    private void Awake()
    {
        this.groundCollider = new GroundCollider(gameObject);
    }
}