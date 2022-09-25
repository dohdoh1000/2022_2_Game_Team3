using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image fadeImage;    // UGUI�� Image ������Ʈ ���� ����.
    public Player player;

    public void FadeFunc()
    {
        StartCoroutine(FadeInStart());
    }

    IEnumerator FadeInStart()
    {
        fadeImage.gameObject.SetActive(true);
        float fadetime = 0f;
        while (fadetime < 1.0f)
        {
            //Debug.Log(fadetime);
            fadetime += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0, 0, 0, fadetime);
        }

        yield return new WaitForSeconds(2.0f);
        StartCoroutine(FadeOutStart());
    }

    IEnumerator FadeOutStart()
    {
        float fadetime = 1.0f;
        while(fadetime >= 0f)
        {
            fadetime -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0, 0, 0, fadetime);
        }

        fadeImage.gameObject.SetActive(false);
        player.isLoading = false;
    }
}
