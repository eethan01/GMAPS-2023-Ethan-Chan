using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    // Start is called before the first frame update
    void Start()
    {
        //mat.SetIdentity();
        mat.Print();
        Question2();
    }

    void Question2()
    {
        // Create matrices for testing
        HMatrix2D matrixA = new HMatrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
        HMatrix2D matrixB = new HMatrix2D(9, 8, 7, 6, 5, 4, 3, 2, 1);

        // Test addition
        HMatrix2D resultAddition = matrixA + matrixB;
        Debug.Log("Matrix Addition Result:");
        resultAddition.Print();

        // Test subtraction
        HMatrix2D resultSubtraction = matrixA - matrixB;
        Debug.Log("Matrix Subtraction Result:");
        resultSubtraction.Print();

        // Test scalar multiplication
        float scalar = 2.0f;
        HMatrix2D resultScalarMultiplication = matrixA * scalar;
        Debug.Log("Matrix Scalar Multiplication Result:");
        resultScalarMultiplication.Print();

        // Test vector multiplication
        HVector2D VectorA = new HVector2D(5, 4);
        HVector2D resultVectorMultiplication = matrixA * VectorA;
        Debug.Log($"Result Vector: ({resultVectorMultiplication.x}, {resultVectorMultiplication.y})");

        // Test matrix multiplication
        HMatrix2D resultMatrixMultiplication = matrixA * matrixB;
        Debug.Log("Matrix Multiplication Result:");
        resultMatrixMultiplication.Print();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
