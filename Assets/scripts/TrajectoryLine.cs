using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [Header("Line renderer veriables")]
    public LineRenderer line;
    [Range(2, 30)]
    public int resolution;

    [Header("Formula variables")]
    public Vector3 velocity;
    public float yLimit;
    private float g;

    [Header("Linecast variables")]
    [Range(2, 30)]
    public int linecastResolution;
    public LayerMask Ground;
    dragmove d;
    public GameObject landingAni;
   
    //====================================================================>
   
    //=====================================================================>
    private void Start()
    {
        g = Mathf.Abs(Physics.gravity.y);
        d = GetComponent<dragmove>();
       
 
    }

    private void Update()
    {
        
        RenderArc();
    }

 
   
    private void RenderArc()
    {
        line.positionCount = resolution + 1;
        line.SetPositions(CalculateLineArray());

    }
 

    private Vector3[] CalculateLineArray()
    {
        Vector3[] lineArray = new Vector3[resolution + 1];

        var lowestTimeValueX = MaxTimeX() / resolution;
        var lowestTimeValueZ = MaxTimeZ() / resolution;
        var lowestTimeValue = lowestTimeValueX > lowestTimeValueZ ? lowestTimeValueZ : lowestTimeValueX;

        for (int i = 0; i < lineArray.Length; i++)
        {
            var t = lowestTimeValue * i;
            lineArray[i] = CalculateLinePoint(t);
            //=========================================================================================>
           
        }

        return lineArray;
    }
   
    private Vector3 HitPosition()
    {
        var lowestTimeValue = MaxTimeY() / linecastResolution;

        for (int i = 0; i < linecastResolution + 1; i++)
        {
            RaycastHit rayHit;

            var t = lowestTimeValue * i;
            var tt = lowestTimeValue * (i + 1);

            if (Physics.Linecast(CalculateLinePoint(t), CalculateLinePoint(tt), out rayHit, Ground))
            {
                // Debug.Log(rayHit.point);
                landingAni.transform.position = rayHit.point + new Vector3(0,0.02f,0);
                return rayHit.point;
            }
        }

        return CalculateLinePoint(MaxTimeY());
    }
    
    //===========================================================>
    
    //=================================================================<
    private Vector3 CalculateLinePoint(float t)
    {
        velocity = -( d.velo)/38;
        float x = velocity.x * t;
        float z = velocity.z * t;
        float y = (velocity.y/2 * t) - (g * Mathf.Pow(t, 2) / 2);
        return new Vector3(x + transform.position.x, y + transform.position.y, z + transform.position.z);
    }

    private float MaxTimeY()
    {
        var v = velocity.y / 4;
        var vv = v * v;

        var t = (v + Mathf.Sqrt(vv + 2 * g * (transform.position.y - yLimit))) / g;
        return t;
    }

    private float MaxTimeX()
    {
        if (IsValueAlmostZero(velocity.x))
            SetValueToAlmostZero(ref velocity.x);

        var x = velocity.x;

        var t = (HitPosition().x - transform.position.x) / x;
        return t;
    }

    private float MaxTimeZ()
    {
        if (IsValueAlmostZero(velocity.z))
            SetValueToAlmostZero(ref velocity.z);

        var z = velocity.z;

        var t = (HitPosition().z - transform.position.z) / z;
        return t;
    }

    private bool IsValueAlmostZero(float value)
    {
        return value < 0.00001f && value > -0.00001f;
    }

    private void SetValueToAlmostZero(ref float value)
    {
        value = 0.0001f;
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }
}