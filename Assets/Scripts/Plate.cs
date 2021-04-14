using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [Header("Change Ball color from")]
    public Material BallColor;
    [Header("To")]
    public Material NewBallColor;

    public void OnTriggerEnter(Collider hit)
    {
        MeshRenderer mr = hit.gameObject.GetComponent<MeshRenderer>();
        if (hit.gameObject.tag.Equals("Player") && mr.material.color == BallColor.color)
        {
            mr.material = NewBallColor;
        }
    }


}
