using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPoint;

    public void FireBallAttack()
    {
        Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
    }
}
