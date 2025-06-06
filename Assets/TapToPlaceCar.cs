using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class TapToPlaceCar : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public static GameObject activeCar1;
    public static GameObject activeCar2;
    private int currentCarIndex = 0;

    private ARRaycastManager raycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 screenPos = Input.mousePosition;

            if (raycastManager.Raycast(screenPos, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (currentCarIndex == 0)
                {
                    if (activeCar1 != null)
                        Destroy(activeCar1);

                    activeCar1 = Instantiate(carPrefabs[0], hitPose.position, Quaternion.identity);
                    activeCar1.transform.localScale = Vector3.one * 0.2f;
                    Debug.Log("✅ Car 1 placed at: " + hitPose.position);
                }
                else if (currentCarIndex == 1)
                {
                    if (activeCar2 != null)
                        Destroy(activeCar2);

                    activeCar2 = Instantiate(carPrefabs[1], hitPose.position, Quaternion.identity);
                    activeCar2.transform.localScale = Vector3.one * 0.2f;
                    Debug.Log("✅ Car 2 placed at: " + hitPose.position);
                }
            }
        }
    }

    public void SelectCar0() { currentCarIndex = 0; }
    public void SelectCar1() { currentCarIndex = 1; }
}
