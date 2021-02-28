using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class CardPicture : MonoBehaviour
{    
    private Texture2D texture;

    private string url;

    private int pictureWidth;
    private int pictureHeight;

    private void Awake()
    {

        pictureWidth = Mathf.RoundToInt(transform.GetComponent<RectTransform>().sizeDelta.x);
        pictureHeight = Mathf.RoundToInt(transform.GetComponent<RectTransform>().sizeDelta.y);

        url = $"https://picsum.photos/{pictureWidth}/{pictureHeight}";

        StartCoroutine(SetImageFromUrl(url));
    }

    IEnumerator SetImageFromUrl(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                texture = DownloadHandlerTexture.GetContent(uwr);
                transform.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            }
        }
    }
}
