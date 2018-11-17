using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    public enum sides
    {
        top,
        right,//positive x north 
        bottom,
        left //negative x south
    }
    private int speed;
    private int weight;

    public sides currentSide = 0;
    public Dictionary<sides, bool> marked= new Dictionary<sides, bool>();
    public Vector3 position;
    public bool AllUsed = false;

    private void Start()
    {
        marked.Add(sides.top, false);
        marked.Add(sides.right, false);
        marked.Add(sides.bottom, false);
        marked.Add(sides.left, false);
        position = gameObject.transform.position;

    }
    private void Update()
    {
        if (AllUsed == false)
        {
            rayCasts();
        }
        //foreach (KeyValuePair<sides,bool> item in marked)
        //{
        //    int counter=0;
        //    if(item.Value == true)
        //    {
        //        counter++;
        //    }
        //    if(counter==4)
        //    {
        //        AllUsed = true;
        //    }
        //}
    }
    public void changeSide()
    {
        if(currentSide == sides.left)
        {
            currentSide = 0;
            return;
        }
        currentSide++;
    }
    public void changeSideBack()
    {
        if (currentSide == sides.top)
        {
            currentSide = sides.left;
            return;
        }
            currentSide--;
    }
    public void markSide(sides side)
    {
        marked[side]= true;
    }

    public void rayCasts()
    {

        RaycastHit2D[] hit = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(position, transform.TransformDirection(Vector3.down) / 2f, hit);
        if (hit[1].collider != null && hit[1].collider.name != "Tiles_Floor_Coll")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit[1].distance, Color.yellow);
            markSide(sides.bottom);
           
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down)/2f, Color.white);
          //  Debug.Log("Did not Hit");
        }
        RaycastHit2D[] hit2 = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(position, transform.TransformDirection(Vector3.up) / 2f, hit2);
        if (hit2[1].collider != null && hit2[1].collider.name != "Tiles_Floor_Coll" )
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit2[1].distance, Color.yellow);
            markSide(sides.top);
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) / 2f, Color.white);
            //Debug.Log("Did not Hit");
        }
        RaycastHit2D[] hit3 = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(position, transform.TransformDirection(Vector3.right) / 2f, hit3);
        if (hit3[1].collider != null && hit3[1].collider.name != "Tiles_Floor_Coll" )
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit3[1].distance, Color.yellow);           
            markSide(sides.right);
          
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) / 2f, Color.white);
           // Debug.Log("Did not Hit");
        }
        RaycastHit2D[] hit4 = new RaycastHit2D[2];
            Physics2D.RaycastNonAlloc(position, transform.TransformDirection(Vector3.left) / 2f, hit4);
        if (hit4[1].collider != null && hit4[1].collider.name != "Tiles_Floor_Coll")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit4[1].distance, Color.yellow);
            markSide(sides.left);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) / 2f, Color.white);
           // Debug.Log("Did not Hit");
        }
        if (hit[1].collider != null && hit2[1].collider != null && hit3[1].collider != null && hit4[1].collider != null
            && hit[1].collider.name != "Tiles_Floor_Coll" && hit2[1].collider.name != "Tiles_Floor_Coll"
            && hit3[1].collider.name != "Tiles_Floor_Coll" && hit4[1].collider.name != "Tiles_Floor_Coll")
        {
            Debug.Log("all are used");
            AllUsed = true;
        }

    }
}
//Collider[] hitColliders = Physics.OverlapSphere(position, 1f);
//if (hitColliders.Length >= 6)
//{
//    Debug.Log(hitColliders.Length);
//    AllUsed = true;
//}