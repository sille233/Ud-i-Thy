using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeInPanel : MonoBehaviour {

    public Vector3 startMarker = new Vector3 (-100, 120, 0);
    public Vector3 endMarker = new Vector3 (48, 120, 0);
    public float smoothing = 1f;

    private void OnDisable()
    {
        transform.position = startMarker;
    }

    private void OnEnable()
    {
        //StartCoroutine(FadeIn(smoothing));
        transform.position = endMarker;
    }

    private IEnumerator FadeIn(float fadeTime)
    {
        while (Vector3.Distance(startMarker, endMarker) > 0.05f)
        {
            transform.position = Vector3.Lerp(startMarker, endMarker, fadeTime * Time.deltaTime);

            yield return null;
        }
        print("Reached the target.");

        yield return new WaitForSeconds(3f);

        print("MyCoroutine is now finished.");
    }
}
