using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAreaBehaviour : MonoBehaviour
{
    private Building building;
    public Building AssociatedBuilding { get => building; }

    [SerializeField]
    private BuildingEnums.AreaType area;
    public BuildingEnums.AreaType Area { get => area; }

    void Awake()
    {
        building = GetComponentInParent<Building>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other + " enters " + this);
        Civilian civilian = other.GetComponent<Civilian>();
        if(civilian)
        {
            civilian.EnterArea(area, building);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Debug.Log(other + " exits " + this);
        
        Civilian civilian = other.GetComponent<Civilian>();
        if(civilian)
        {
            civilian.ExitArea(area, building);
        }
    }

    private void OnDrawGizmos() {
        DrawBox(transform.position, transform.rotation, transform.localScale, Color.black);
    }

    public void DrawBox(Vector3 pos, Quaternion rot, Vector3 scale, Color c)
    {
        // create matrix
        Matrix4x4 m = new Matrix4x4();
        m.SetTRS(pos, rot, scale);

        var point1 = m.MultiplyPoint(new Vector3(-0.5f, -0.5f, 0.5f));
        var point2 = m.MultiplyPoint(new Vector3(0.5f, -0.5f, 0.5f));
        var point3 = m.MultiplyPoint(new Vector3(0.5f, -0.5f, -0.5f));
        var point4 = m.MultiplyPoint(new Vector3(-0.5f, -0.5f, -0.5f));

        var point5 = m.MultiplyPoint(new Vector3(-0.5f, 0.5f, 0.5f));
        var point6 = m.MultiplyPoint(new Vector3(0.5f, 0.5f, 0.5f));
        var point7 = m.MultiplyPoint(new Vector3(0.5f, 0.5f, -0.5f));
        var point8 = m.MultiplyPoint(new Vector3(-0.5f, 0.5f, -0.5f));

        Debug.DrawLine(point1, point2, c);
        Debug.DrawLine(point2, point3, c);
        Debug.DrawLine(point3, point4, c);
        Debug.DrawLine(point4, point1, c);

        Debug.DrawLine(point5, point6, c);
        Debug.DrawLine(point6, point7, c);
        Debug.DrawLine(point7, point8, c);
        Debug.DrawLine(point8, point5, c);

        Debug.DrawLine(point1, point5, c);
        Debug.DrawLine(point2, point6, c);
        Debug.DrawLine(point3, point7, c);
        Debug.DrawLine(point4, point8, c);
    }
}
