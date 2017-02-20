using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLine : IEquatable<SpellLine>
{
    private static float offset = 0.5f;

    public SpellButton Start;
    public SpellButton End;
    public Vector3 LineVector { get { return End.Position - Start.Position; } }
    public int Count { get { return LinesRendered.Count; } }
    public List<GameObject> LinesRendered;

    public SpellLine()
    {
        LinesRendered = new List<GameObject>();
    }

    public SpellLine(SpellButton start, SpellButton end)
    {
        Start = start;
        End = end;

        LinesRendered = new List<GameObject>();
    }
    /// <summary>
    /// Draw lines to spell grid
    /// <param name="lineMaterial">Material used for line renderer</param>
    /// <param name="lineCount">Number of existing lines</param>
    /// </summary>
    public void DrawLines(Material lineMaterial, int lineCount)
    {
        if (lineCount == 0)
        {
            
            GameObject line = CreateLine(lineMaterial, Start.transform.position,
            End.transform.position, Vector3.zero);
            LinesRendered.Add(line);
            
        }
        else if (lineCount == 1)
        {
            Vector3 offsetVector = GetOffset(Start.transform.position, End.transform.position);
            GameObject line1 = CreateLine(lineMaterial, Start.transform.position, End.transform.position,
            offsetVector * offset);
            GameObject line2 = CreateLine(lineMaterial, Start.transform.position, End.transform.position,
            -offsetVector * offset);
            LinesRendered.Add(line1);
            LinesRendered.Add(line2);
        }
    }

    /// <summary>
    /// Create and return new game object with line renderer component
    /// </summary>
    /// <param name="lineMaterial">Material used for line renderer</param>
    /// <param name="startPosition">Starting position of the line in global coordinats</param>
    /// <param name="endPosition">Ending position of the line in global coordinates</param>
    /// <param name="offset">Line offset</param>
    /// <returns>GameObject</returns>
    private GameObject CreateLine(Material lineMaterial, Vector3 startPosition,
     Vector3 endPosition, Vector3 offset)
    {
        GameObject line = new GameObject();
        line.transform.position = (Vector2)Start.transform.position ;
        line.AddComponent<LineRenderer>();
        LineRenderer lr = line.GetComponent<LineRenderer>();
        lr.materials = new Material[] { lineMaterial, lineMaterial, lineMaterial };
        lr.startColor = Color.red;
        lr.endColor = Color.red;
        lr.startWidth = 1.2f;
        lr.endWidth = 1.2f;
        lr.SetPosition(0, (Vector2)Start.transform.position + (Vector2)offset);
        lr.SetPosition(1, (Vector2)End.transform.position + (Vector2)offset);
        //lr.useWorldSpace = false;
        return line;
    }

    /// <summary>
    /// Destroy all rendered lines
    /// </summary>
    public void DestroyRenderedLines()
    {
        foreach (GameObject line in LinesRendered)
        {
            MonoBehaviour.Destroy(line);
        }
    }

    /// <summary>
    /// Calculate perpendicular offset unit vector for a line (counter-clockwise rotation)
    /// </summary>
    /// <param name="Start">Start position of the line</param>
    /// <param name="End">End position of the line</param>
    /// <returns>Vector3</returns>
    private Vector3 GetOffset(Vector3 Start, Vector3 End)
    {
        Vector3 line = End - Start;
        Vector3 lineUnit = line / line.magnitude;
        Vector3 offsetVector = new Vector3(-lineUnit.y, lineUnit.x, 0);
        return offsetVector; // counter-clockwise rotation
    }

    /// <summary>
    /// Overrides the default equality comparer. Takes no account of line direction
    /// </summary>
    /// <param name="line">Line to be compared</param>
    /// <returns></returns>
    public bool Equals(SpellLine line)
    {
        if(Start.Position.x == line.Start.Position.x &&
            Start.Position.y == line.Start.Position.y &&
            End.Position.x == line.End.Position.x &&
            End.Position.y == line.End.Position.y) { return true; } // Equal start and end positions
        else if(Start.Position.x == line.End.Position.x &&
            Start.Position.y == line.End.Position.y &&
            End.Position.x ==   line.Start.Position.x &&
            End.Position.y == line.Start.Position.y) { return true; } // Reversed start and end positions
        return false; // Not equal!
    }
}
