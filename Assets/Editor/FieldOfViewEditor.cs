using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]
public class FieldOfViewEditor : Editor {
    
    void OnSceneGUI() {
		FieldOfView fow = (FieldOfView)target;
		Handles.color = Color.white;
		Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
		Vector3 viewAngleA = fow.DirFromAngle (-fow.viewAngle / 2, false);
		Vector3 viewAngleB = fow.DirFromAngle (fow.viewAngle / 2, false);

		Handles.DrawLine (fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
		Handles.DrawLine (fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fow.visibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }

        //OnPostRender();
    }

    //public Material mat;

    //void OnPostRender()
    //{
    //    FieldOfView fow = (FieldOfView)target;
        //if (!mat)
        //{
        //    Debug.LogError("Please Assign a material on the inspector");
        //    return;
        //}
    //    GL.Begin(GL.LINES);
    //    mat.SetPass(0);
    //    foreach (Transform visibleTarget in fow.visibleTargets)
    //    {
    //        GL.PushMatrix();
    //        GL.LoadOrtho();
    //        GL.Vertex(fow.transform.position);
    //        GL.Vertex(fow.transform.position + visibleTarget.position * 5);
    //        GL.End();
    //        GL.PopMatrix();
    //    }
    //}

    //private void OnDrawGizmos()
    //{
    //    FieldOfView fow = (FieldOfView)target;
    //    Gizmos.color = Color.red;
    //    foreach (Transform visibleTarget in fow.visibleTargets)
    //    {
    //        Gizmos.DrawLine(fow.transform.position, visibleTarget.position);
    //        Gizmos.DrawIcon(fow.transform.position+ visibleTarget.position,"CrossIcon");
    //    }
    //}

}
