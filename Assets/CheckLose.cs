using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class CheckLose : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            Manager.InGame.OnLose();
        }
    }
}