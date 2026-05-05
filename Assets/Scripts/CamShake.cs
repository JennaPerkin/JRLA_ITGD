using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public static CamShake instance;
    private Vector3 originPos;
    public bool isShaking;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

    }

    public void ShakeCamera(float duration, float intensity)
    {
        StartCoroutine(CameraShake(duration, intensity));
    }

    IEnumerator CameraShake(float duration, float intensity)
    {
        originPos = transform.localPosition;
        float elapsed = 0;
        while(elapsed < duration)
        {
            float xPos = Random.Range(-intensity, intensity);
            float yPos = Random.Range(-intensity, intensity);
            transform.localPosition = originPos + new Vector3(xPos, yPos, 0);
            elapsed += Time.deltaTime;
            isShaking = true;
            yield return new WaitForEndOfFrame();
        }
        isShaking = false;
        transform.localPosition = originPos;
    }
}
