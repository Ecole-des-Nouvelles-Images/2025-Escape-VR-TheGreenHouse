using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PortalController : MonoBehaviour
{
    public static  Action<Transform, Transform,Transform> OnTriggerEntered;
    public static Action< Transform,Transform> OnPortalSwaped;

    [SerializeField]
    Camera m_PlayerCamera;
    [SerializeField]
    Camera m_PortalCamera;

    [SerializeField]
    Transform m_InPortal, m_OutPortal;

    private Transform m_CameraTransform;
    private void Start()
    {
        m_CameraTransform = m_PortalCamera.transform;

        m_PortalCamera.fieldOfView = m_PlayerCamera.fieldOfView;
        m_PortalCamera.nearClipPlane = m_PlayerCamera.nearClipPlane;
        m_PortalCamera.farClipPlane = m_PlayerCamera.farClipPlane;
    }
    
    private void OnEnable()
    {
        OnTriggerEntered += PortalEntered;
        OnPortalSwaped += ChangePortals;
    }

    private void OnDisable()
    {
        OnTriggerEntered -= PortalEntered;
        OnPortalSwaped -= ChangePortals;
    }

    private void Update()
    {
        m_CameraTransform.position = m_PlayerCamera.transform.position;
        m_CameraTransform.rotation = m_PlayerCamera.transform.rotation;

        if (!m_OutPortal && m_InPortal) return;
      
        // Position the camera behind the other portal.
        Vector3 relativePos = m_InPortal.InverseTransformPoint(m_CameraTransform.position);
        relativePos = Quaternion.Euler(0.0f, 180.0f, 0.0f) * relativePos;
        m_CameraTransform.position = m_OutPortal.transform.TransformPoint(relativePos);

        // Rotate the camera to look through the other portal.
        Quaternion relativeRot = Quaternion.Inverse(m_InPortal.rotation) * m_CameraTransform.rotation;
        relativeRot = Quaternion.Euler(0.0f, 180.0f, 0.0f) * relativeRot;
        m_CameraTransform.rotation = m_OutPortal.rotation * relativeRot;
    }
    
    
    private void PortalEntered(Transform player, Transform newInPortal, Transform newOutPortal)
    {
        
        var offset = player.position - m_InPortal.transform.position;
        player.position = m_OutPortal.transform.position + offset;
        Debug.Log("player colliding");
        m_OutPortal.GetComponentInChildren<PortallTrigger>().IsActive = false;

        ChangePortals(newInPortal,newOutPortal);
     
    }

    private void ChangePortals(Transform newInPortal, Transform newOutPortal)
    {
        m_InPortal = newInPortal;
        m_OutPortal = newOutPortal;
    }

}
