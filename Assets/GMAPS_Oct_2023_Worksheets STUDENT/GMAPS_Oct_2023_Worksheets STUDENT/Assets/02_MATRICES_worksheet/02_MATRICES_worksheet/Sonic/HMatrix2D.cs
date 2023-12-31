// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        SetIdentity();
    }
    //This is a constuctor that takes a 3x3 sized array. we create a for loop for 3 horizontal and 3 vertical
    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[x, y] = x == y ? 1.0f : 0.0f;
            }
        }
    }
    //We are taking each individual element from the matrix
    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }
    //Addition operator of matrix
    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D(
            left.Entries[0, 0] + right.Entries[0, 0], left.Entries[0, 1] + right.Entries[0, 1], left.Entries[0, 2] + right.Entries[0, 2],
            left.Entries[1, 0] + right.Entries[1, 0], left.Entries[1, 1] + right.Entries[1, 1], left.Entries[1, 2] + right.Entries[1, 2],
            left.Entries[2, 0] + right.Entries[2, 0], left.Entries[2, 1] + right.Entries[2, 1], left.Entries[2, 2] + right.Entries[2, 2]
        );
    }
    //Subtraction operator of matrix
    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D(
            left.Entries[0, 0] - right.Entries[0, 0], left.Entries[0, 1] - right.Entries[0, 1], left.Entries[0, 2] - right.Entries[0, 2],
            left.Entries[1, 0] - right.Entries[1, 0], left.Entries[1, 1] - right.Entries[1, 1], left.Entries[1, 2] - right.Entries[1, 2],
            left.Entries[2, 0] - right.Entries[2, 0], left.Entries[2, 1] - right.Entries[2, 1], left.Entries[2, 2] - right.Entries[2, 2]
        );
    }
    //Scalar multiplication of matrix where i created a for loop to multiply each element to the scalar value
    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                result.Entries[row, col] = left.Entries[row, col] * scalar;
            }
        }

        return result;
    }

    // Note that the second argument is a HVector2D object
    //Multiplication operator but with a HVector where i code each multiplication
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D(
        left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y + left.Entries[0, 2] * right.h,
        left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * right.h
        );

    }

    // Note that the second argument is a HMatrix2D object
    //multiplication of 2 matrices operator
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

            /* 
                00 01 02    xx xx 02
                xx xx xx    xx xx 12
                xx xx xx    xx xx 22
            */
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            /* 
                xx xx xx    00 xx xx
                10 11 12    10 xx xx
                xx xx xx    20 xx xx
            */
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],

            /* 
                xx xx xx    xx 01 xx
                10 11 12    xx 11 xx
                xx xx xx    xx 21 xx
            */
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            /* 
                00 00 00    xx xx 02
                10 11 12    xx xx 12
                xx xx xx    xx xx 22
            */
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],
            /* 
                xx xx xx    00 xx xx
                xx xx xx    10 xx xx
                20 21 22    20 xx xx
            */
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            /* 
                xx xx xx    xx 01 xx
                xx xx xx    xx 11 xx
                20 21 22    xx 21 xx
            */
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            /* 
                xx xx xx    xx xx 02
                xx xx xx    xx xx 12
                20 21 22    xx xx 22
            */
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
    );
    }
    //Checking if the two matrices are equivalent.
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (left.Entries[row, col] != right.Entries[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }
    //Checking if the two matrices are not equivalent.
    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (left.Entries[row, col] != right.Entries[row, col])
                {
                    return true;
                }
            }
        }
        return false;
    }


    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}

    //public float GetDeterminant()
    //{
    //    return // your code here
    //}

    // Set the matrix to the identity matrix
    public void SetIdentity()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[x, y] = (x == y) ? 1.0f : 0.0f;
            }
        }
        //    for (int y = 0; y < 3; y++)
        //    {
        //        for (int x = 0; x < 3; x++)
        //        {
        //            if (x == y)
        //            {
        //                Entries[x, y] = 1;
        //            }
        //            else
        //            {
        //                Entries[x, y] = 0;  
        //            }
        //        }
    }
    //Set the matrix to a translation matrix
    public void SetTranslationMat(float transX, float transY)
    {
        //SetIdentity;
        Entries[0,2] = transX;
        Entries[1,2] = transY;
    }
    //Set the matrix to a rotation matrix
    public void SetRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;

        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = -Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    //public void SetScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}
    //Here we can print the matrix entries
    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
