using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS : MonoBehaviour
{
    public float mMoveSpeed;
    public Camera mTPSCamera;
    public Transform mLookPt;
    public float mMinLookDistance;
    public float mCurrentLookDistance;
    public float mLookUpLimit;
    public float mLookDownLimit;
    private Vector3 mHorizontalVector;
    private float mTotalRotateVertical;
    private Vector3 mSmoothVel = Vector3.zero;
    public LayerMask mLayers;
    
    // Start is called before the first frame update
    void Start()
    {
        mTotalRotateVertical = 0.0f;
        mHorizontalVector = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        float fH = Input.GetAxis("Horizontal");
        float fV = Input.GetAxis("Vertical");

        Vector3 vTempR2 = Vector3.Cross(Vector3.up, mHorizontalVector);
        vTempR2.Normalize();
        Vector3 vForward = mHorizontalVector * fV + vTempR2 * fH;
        float fMoveStrength = vForward.magnitude*mMoveSpeed;
        if (fMoveStrength > 0)
        {
            transform.forward = Vector3.RotateTowards(transform.forward, vForward, 0.1f, 0.1f);
            transform.position = transform.position + transform.forward * fMoveStrength * Time.deltaTime ;
        }

        float fMX = Input.GetAxis("Mouse X") * 3.5f;
        float fMY = - Input.GetAxis("Mouse Y") * 3.5f;

        // horizontal rotate
        mHorizontalVector = Quaternion.AngleAxis(fMX, Vector3.up)*mHorizontalVector;
        mHorizontalVector.Normalize();

        // vertical rotate
        Vector3 vTempR = Vector3.Cross(Vector3.up, mHorizontalVector);
        mTotalRotateVertical += fMY;

        //Debug.Log("mTotalRotateVertical: "+ mTotalRotateVertical );

        if (mTotalRotateVertical > mLookDownLimit)
        {
            mTotalRotateVertical = mLookDownLimit;
        }
        else if(mTotalRotateVertical < -mLookUpLimit)
        {
            mTotalRotateVertical = -mLookUpLimit;
        }
        Vector3 vRotateVector = Quaternion.AngleAxis(mTotalRotateVertical, vTempR) * mHorizontalVector;
        vRotateVector.Normalize();

     //  Debug.Log("BBB " + mTPSCamera.transform.position);
      //  Vector3 vFrameVector = transform.position - mTPSCamera.transform.position;
        //float fFrameDistance = vFrameVector.magnitude;
       // Debug.Log("fFrameDistance " + fFrameDistance + ":" + mCurrentLookDistance);
        //   float fDistance = Mathf.Lerp(fFrameDistance, mCurrentLookDistance, 0.2f);
        //   Debug.Log("fDistance " + fDistance);
        Vector3 vCamMoveTarget = mLookPt.position - vRotateVector * mCurrentLookDistance;
        RaycastHit rh;
        if(Physics.SphereCast(mLookPt.position, 0.2f, -vRotateVector, out rh, mCurrentLookDistance, mLayers))
        {
            vCamMoveTarget = mLookPt.position - vRotateVector * rh.distance;
        }

        mTPSCamera.transform.position = vCamMoveTarget;//Vector3.Lerp(mTPSCamera.transform.position, vCamMoveTarget, 0.1f);
        //mTPSCamera.transform.position = Vector3.SmoothDamp(mTPSCamera.transform.position, vCamMoveTarget, ref mSmoothVel, 0.05f) ;
        //Vector3.Lerp(mTPSCamera.transform.position, vCamMoveTarget, 0.1f);
        //Debug.Log("mTPSCamera.transform.position: " + mTPSCamera.transform.position);
        mTPSCamera.transform.forward = mLookPt.position - mTPSCamera.transform.position;
    }
}
