using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMarkers : MonoBehaviour
{
    [SerializeField] Transform[] _paths;
    public Transform[] getPaths { get { return _paths; } }
}
