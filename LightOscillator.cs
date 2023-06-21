                                        //#Credit By NofeuXe 21/06/23
using UnityEngine;

public class LightOscillator : MonoBehaviour
{
    private Light lightComponent;
    private float nextChangeTime;
    [SerializeField]
    private float minInterval = 0.1f;
    [SerializeField]
    private float maxInterval = 0.5f;
    public bool enableDebugLog = true;

    private void Start()
    {
        lightComponent = GetComponent<Light>();

        if (lightComponent == null)
        {
            Debug.LogError("Aucun composant Light trouvé sur l'objet !");
        }

        SetNextChangeTime();
    }

    private void Update()
    {
        if (lightComponent != null)
        {
            if (Time.time >= nextChangeTime)
            {
                float intensity = GetRandomIntensity();
                lightComponent.intensity = intensity;
                
                if (enableDebugLog)
                {
                    Debug.Log("La valeur de l'intensité est : " + intensity);
                }

                SetNextChangeTime();
            }
        }
    }

    private float GetRandomIntensity()
    {
        return Random.value < 0.5f ? 0f : 1.5f;
    }

    private void SetNextChangeTime()
    {
        float interval = Random.Range(minInterval, maxInterval);
        nextChangeTime = Time.time + interval;
    }
}