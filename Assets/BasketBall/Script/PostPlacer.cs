using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class PostPlacer : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] ARRaycastManager m_ARRaycastManager;
    [SerializeField] ARPlaneManager m_ARPlaneManager;
    [SerializeField] Transform targetPoint;
    [SerializeField] Transform BasketballPost_Prefab;

    public Action OnPostPlaced;

    Vector2 screenCenter;
    public List<ARRaycastHit> m_RaycastHitList = new List<ARRaycastHit>();

    ARRaycastHit hittedRay;
    bool isHitConfirm = false;

    private void Start()
    {
        screenCenter = new Vector2(Screen.width / 2 , Screen.height / 2);
    }
    private void Update()
    {
        if (m_ARRaycastManager.Raycast(screenCenter, m_RaycastHitList))
        {
            hittedRay = default(ARRaycastHit);
            isHitConfirm = false;

            foreach(ARRaycastHit hit in m_RaycastHitList)
            {
                if(hit.hitType == UnityEngine.XR.ARSubsystems.TrackableType.Planes)
                {
                    hittedRay = hit;
                    isHitConfirm = true;
                    break;
                }
            }
            if (!isHitConfirm)
            {

                targetPoint.gameObject.SetActive(false);
                return;
            }

            Debug.Log($"hit type {hittedRay.hitType}");
            if (!targetPoint.gameObject.activeSelf)
                targetPoint.gameObject.SetActive(true);
            targetPoint.position = hittedRay.pose.position;
        }
        else
        {
            isHitConfirm = false;
            targetPoint.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        targetPoint.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isHitConfirm)
        {
            Transform basketBallPost = Instantiate<Transform>(BasketballPost_Prefab);
            basketBallPost.position = hittedRay.sessionRelativePose.position;
            basketBallPost.transform.LookAt(Camera.main.transform.position);
            Vector3 euler = basketBallPost.localEulerAngles;
            euler.x = 0;
            basketBallPost.localEulerAngles = euler;

            OnPostPlaced?.Invoke();
        }
    }

}
