using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private int probability;

    public int Probability { get => probability; set => probability = value; }

}
