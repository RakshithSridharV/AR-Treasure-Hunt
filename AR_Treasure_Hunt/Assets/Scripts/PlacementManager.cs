using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PlacementManager : MonoBehaviour
{
    public static PlacementManager Instance;

    public GameObject placementPrefab;
    public ARRaycastManager raycastManager;
    public Camera arCamera;

    private bool hasPlacedObject = false;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (hasPlacedObject) return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;

                    if (placementPrefab != null)
                    {
                        Instantiate(placementPrefab, hitPose.position, hitPose.rotation);
                        hasPlacedObject = true;

                        UIManager.Instance?.ShowMessage("First clue placed! Begin your hunt.");
                    }
                }
            }
        }
    }

    public void ResetPlacement()
    {
        hasPlacedObject = false;
    }
}
