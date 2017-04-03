using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        setToOrigin();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setToOrigin()
    {
        transform.localPosition = new Vector3(
            Camera.main.orthographicSize * Camera.main.aspect,
            Camera.main.orthographicSize,
            transform.localPosition.z
        );

    }

    /// <summary>
    /// Total width of cameras view in game units
    /// </summary>
    public float ScreenWidth
    {
        get
        {
            return (2 * Camera.main.orthographicSize * Camera.main.aspect);
        }
    }

    /// <summary>
    /// Total height of cameras view in game units
    /// </summary>
    public float ScreenHeight
    {
        get
        {
            return (2 * Camera.main.orthographicSize);
        }
    }

}
