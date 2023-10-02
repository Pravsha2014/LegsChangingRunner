using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public void SetSkybox(Material material)
    {
        RenderSettings.skybox = material;
    }
}
