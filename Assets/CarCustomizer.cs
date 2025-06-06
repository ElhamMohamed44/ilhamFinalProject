using UnityEngine;

public class CarCustomizer : MonoBehaviour
{
    public Material colorMaterial;
    private Renderer[] allRenderers;

    void Awake()
    {
        allRenderers = GetComponentsInChildren<Renderer>(true);
    }

    public void ApplyColor()
    {
        if (colorMaterial == null)
        {
            Debug.LogWarning("⚠️ Color material not assigned!");
            return;
        }

        foreach (Renderer renderer in allRenderers)
        {
            Material[] newMats = new Material[renderer.materials.Length];
            for (int i = 0; i < newMats.Length; i++)
            {
                newMats[i] = colorMaterial;
            }
            renderer.materials = newMats;
        }

        Debug.Log("✅ Full color applied to: " + gameObject.name);
    }
}
