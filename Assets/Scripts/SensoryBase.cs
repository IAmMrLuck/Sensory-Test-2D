using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensoryBase : MonoBehaviour
{
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private float growthTime = 1.0f;

    private IEnumerator GrowCircle(GameObject circleInstance, int targetScale)
    {
        float elapsedTime = 0f;
        Vector3 originalScale = circleInstance.transform.localScale;
        Vector3 scaleSize = originalScale * targetScale;

        while (elapsedTime < growthTime)
        {
            circleInstance.transform.localScale = Vector3.Lerp(originalScale, scaleSize, elapsedTime / growthTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        circleInstance.transform.localScale = scaleSize; 
    }

    public void CreateCircle(int targetScale)
    {
        GameObject circleInstance = Instantiate(circlePrefab, this.transform.position, Quaternion.identity);
        StartCoroutine(GrowCircle(circleInstance, targetScale));
    }

}
