using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float waveSpeed = 1.0f; // Скорость волны
    public float waveHeight = 0.5f; // Высота волны
    public float waveLength = 2.0f; // Длина волны

    private MeshFilter meshFilter;
    private Mesh mesh;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
    }

    void Update()
    {
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            // Изменяем высоту вершин в соответствии с синусоидальной функцией
            float x = vertices[i].x;
            float z = vertices[i].z;
            float y = Mathf.Sin((Time.time * waveSpeed) + (x / waveLength) + (z / waveLength)) * waveHeight;
            vertices[i] = new Vector3(x, y, z);
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals(); // Пересчитываем нормали для корректного отображения света
    }
}
