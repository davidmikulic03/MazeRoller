using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] int points;
    public int Points { get { return points; } }

    public Trigger(int points)
    {
        this.points = points;
    }
}
