using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    public static nColor[] ListOfColors;
}

[System.Serializable]
public struct nColor
{
    public string Name;
    public Color color;

}

