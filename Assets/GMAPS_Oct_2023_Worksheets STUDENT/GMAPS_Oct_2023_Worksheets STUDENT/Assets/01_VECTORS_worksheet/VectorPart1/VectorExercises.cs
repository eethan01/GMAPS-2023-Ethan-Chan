using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;
        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
    }

    void Question2a()
    {
        
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        //Create a for loop that loops around the value of n
        for (int i = 0; i < n; i++){
            // Creates new random vector start and end points based of the game dimensions maxx and maxy
            startPt = new Vector2(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY));

            endPt = new Vector2(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY));

            //Draw out each value as lines.
            drawnLine = lineFactory.GetLine(
                startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        //For loop created for each number within n
        for (int i = 0; i < n; i++)
        {
            //Creates random end points for each arrow based upon max values of maxx and maxy
            endPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));


            //Draw out each arrow starting from origin
            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                new Vector3(endPt.x, endPt.y, endPt.y),
                // Your code here,
                Color.white,
                60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        //C is created by the sum of the two vectors a and b
        HVector2D c = a + b;    
        //Draw out all of the arrows
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), - b.ToUnityVector3(), Color.green, 60f);
        // Your code here
        // ...

        // Your code here

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of a = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of a = " + c.Magnitude().ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        
        HVector2D a = new HVector2D(3, 5);
        //Created b based of a scaled by 2 times and half of a
        HVector2D b = a * 2;
        //HVector2D b = a / 2;
        //Created an offset for arrow b
        float offset = 1.0f;
        //Drew the 2 arrows
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
        DebugExtension.DebugArrow(new Vector3(offset, 0, 0), b.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {

        HVector2D a = new HVector2D(3, 5);
        HVector2D aNormalize = new HVector2D(3, 5);
        //I created the normalized version of a
        aNormalize.Normalize();
        //Created an offset to properly display the vectors
        float offset = 1.0f;
        //Display the two arrows
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(offset, 0, 0), aNormalize.ToUnityVector3(), Color.green, 60f);
        Debug.Log("Magnitude of a normalized = " + aNormalize.Magnitude().ToString("F2"));

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        // Your code here

        //HVector2D //Your code here

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.white, 60f);
    }
}
