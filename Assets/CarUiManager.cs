using UnityEngine;

public class CarUIManager : MonoBehaviour
{
    public void ColorCar1()
    {
        if (TapToPlaceCar.activeCar1 != null)
        {
            var customizer = TapToPlaceCar.activeCar1.GetComponent<CarCustomizer>();
            if (customizer != null) customizer.ApplyColor();
        }
    }

    public void ColorCar2()
    {
        if (TapToPlaceCar.activeCar2 != null)
        {
            var customizer = TapToPlaceCar.activeCar2.GetComponent<CarCustomizer>();
            if (customizer != null) customizer.ApplyColor();
        }
    }
}
