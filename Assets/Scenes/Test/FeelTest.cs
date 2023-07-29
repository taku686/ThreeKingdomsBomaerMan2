using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class FeelTest : MonoBehaviour
{
    [SerializeField] private MMF_Player feel;

    private void Awake()
    {
        feel.Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            feel.PlayFeedbacks();
        }
    }
}