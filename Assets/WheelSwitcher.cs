using UnityEngine;

public class WheelColorChanger : MonoBehaviour
{
    public GameObject[] wheels; // Assign 4 wheels here
    public Material newWheelMaterial;

    public void ChangeWheelColor()
    {
        if (wheels == null || newWheelMaterial == null)
        {
            Debug.LogWarning("Missing wheels or material.");
            return;
        }

        foreach (GameObject wheel in wheels)
        {
            Renderer renderer = wheel.GetComponent<Renderer>();
            if (renderer != null)
                renderer.material = newWheelMaterial;
        }
    }
}
