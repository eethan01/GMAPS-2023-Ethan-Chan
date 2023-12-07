//// Uncomment this whole file.

using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        // Set the initial position based on the game object's position
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        //Translate(1, 1);
        Rotate(69);
        // Your code here
    }

    // Function to perform translation
    void Translate(float x, float y)
    {
        // Set up the translation matrix to move to the specified (x, y) coordinates
        toOriginMatrix.SetIdentity();
        toOriginMatrix.SetTranslationMat(x, y);
        //Update the combined transformMatrix
        transformMatrix = toOriginMatrix;
        //Update the translate to the pos vector
        pos = toOriginMatrix * pos;
        Transform();
    }
    // Function to perform rotation
    void Rotate(float angle)
    {
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();
        //We set up these matrices to rotate around a specific point
        rotateMatrix.SetTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y);
        //Rotate the matrix based on the angle given
        rotateMatrix.SetRotationMat(angle);

        // Set the combined transformation matrix to identity
        transformMatrix.SetIdentity();

        // Combine matrices for the complete transformation
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        Transform();
    }
    // Function to apply the transformation to the mesh
    private void Transform()
    {
        //get vertices of cloned mesh
        vertices = meshManager.clonedMesh.vertices;
        //apply transform to the mesh
        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }
        // Update the mesh vertices with the transformed vertices
        meshManager.clonedMesh.vertices = vertices;
    }
}
