using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRender : MonoBehaviour
{
    public MeshRenderer mesh;

    private void Start()
    {
        mesh.sortingOrder = 100;
    }
}
