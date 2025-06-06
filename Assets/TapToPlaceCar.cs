using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlaceCar : MonoBehaviour
{
    public GameObject[] carPrefabs; // Assign Car 1 and Car 2 in Inspector
    private int currentCarIndex = 0;
    private GameObject placedCar; // Keeps track of the current car

    private ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = Input.mousePosition;

            if (raycastManager.Raycast(screenPos, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                // Remove previously placed car
                if (placedCar != null)
                {
                    Destroy(placedCar);
                }

                // Instantiate the selected car prefab at plane position with no rotation
                placedCar = Instantiate(carPrefabs[currentCarIndex], hitPose.position, Quaternion.identity);

                // Apply fixed rotation: keep upright (Y-up) and match plane's Y angle
                placedCar.transform.rotation = Quaternion.Euler(0f, hitPose.rotation.eulerAngles.y, 0f);

                // Apply consistent scale
                placedCar.transform.localScale = Vector3.one * 0.2f; // adjust this scale to fit your real size
            }
        }
    }

    // UI Button → Car 1
    public void SelectCar0()
    {
        currentCarIndex = 0;
    }

    // UI Button → Car 2
    public void SelectCar1()
    {
        currentCarIndex = 1;
    }
}
