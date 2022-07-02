using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CenterRay : MonoBehaviour
{
    JSONSave jsonData;

    public float MouseXDex;
    public float MouseYDex;
    float inputX;
    float inputY;
    float mAngle;
    Vector3 horizontalVector;

    public Text targetName;
    public Camera mCam;
    public float rayLength;
    Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen

    // Start is called before the first frame update
    void Start()
    {
        jsonData = new JSONSave();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Mouse X");
        inputY = Input.GetAxis("Mouse Y");

        mAngle += inputY * MouseYDex;
        //Debug.Log(mAngle);
        if (mAngle > 45.0f) mAngle = 45.0f;
        if (mAngle < -45.0f) mAngle = -45.0f;

        horizontalVector = transform.forward;
        mCam.transform.forward = horizontalVector;

        transform.Rotate(Vector3.up * MouseXDex * inputX);
        mCam.transform.Rotate(-mAngle, 0.0f, 0.0f);

        // actual Ray
        RayFunc();
        MouseCtrl();

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("PPP");
            PlayerData.hp -= 10;
            PlayerData.mp += 11;
            PlayerData.lv += 1;
        }
    }

    void RayFunc()
    {
        Ray ray = mCam.ViewportPointToRay(rayOrigin);
        // debug Ray
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            // our Ray intersected a collider
            //Debug.Log(hit.collider.gameObject.name);
            targetName.text = hit.collider.gameObject.name;
            //objName = targetName.text;
            if (Input.GetMouseButtonUp(0))
            {
                //if (TagName(hit.collider.transform.parent.gameObject) == "TransPort")
                //{
                //Debug.Log("00000000000000000000000");
                //    //Debug.Log($"FLYYYY");
                //    //Debug.Log(hit.collider.transform.parent.Find("GoTo"));
                //    if (FindChildWithTag(hit.collider.transform.parent.gameObject, "GoTo"))
                //    {
                //        Debug.Log("GOGO");
                //        //Debug.Log(hit.collider.transform.parent.Find("Level2").tag);
                //        //Debug.Log(FindChildWithTag(hit.collider.transform.parent.gameObject, "GoTo").name);
                //        ChangeScene(hit.collider.gameObject.name);
                //        Debug.Log("WTF");
                //    }
                //    else
                //    {
                //        Debug.Log("NO");
                //    }
                //}
                //Debug.Log($"This is {hit.collider.transform.parent.gameObject.tag}");
                //Debug.Log($"This name is {objName}");

            }
        }
    }

    void MouseCtrl()
    {
        //if (Input.GetMouseButtonDown(0))
            //Debug.Log("Pressed primary button.");
        //if (Input.GetMouseButtonUp(0))
            //Debug.Log("UP primary button.");
    }

    public string TagName(GameObject target)
    {
        string theTag;
        theTag = target.tag;
        return theTag;
    }
    GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }


    public void ChangeScene(string sName)
    {
        SceneManager.LoadScene(sName, LoadSceneMode.Single);
    }

}
