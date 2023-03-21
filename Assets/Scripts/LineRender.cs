using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    public GameObject RayCastObj;
    private float DistanceObj;
    public Material mat;
    public GameObject currentHitObject;
    private float currentHitDistance;
    private Vector3 origin;
    private Vector3 direction;
    public float maxDistance;

    void Start()
    {

    }

    void Update()
    {

        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            currentHitDistance = hit.distance;

            //lineRenderer.enabled = true;
            //lineRenderer.SetPosition(0, origin);
            //lineRenderer.SetPosition(1, hit.point);

            //cross.SetActive(true); // unhide cross
            //cross.transform.position = hit.point;
            //cross.transform.forward = hit.normal;
        }
        else
        {
            //lineRenderer.enabled = false;
            currentHitDistance = maxDistance;
            currentHitObject = null;
            //cross.SetActive(false); // hide cross
        }

        OnPostRender();
    }

    void OnPostRender()
    {
        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Vertex(origin);
        GL.Vertex(origin + direction * currentHitDistance);
        mat.SetPass(0);
        GL.End();
        GL.PopMatrix();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawIcon(origin + direction * currentHitDistance, "CrossIcon");
        //Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
