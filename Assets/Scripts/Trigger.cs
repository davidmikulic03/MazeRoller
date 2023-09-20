using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] uint points;
    public uint Points { get { return points; } }

    public Trigger(uint points)
    {
        this.points = points;
    }
}
