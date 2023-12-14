using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerTextHandler : MonoBehaviour
{
    private const float _leftLimit = -1400;
    private const float _rightLimit = 1600;

    [SerializeField] private RectTransform[] bannerText;
    [SerializeField] private float scrollSpeed = 0.5f;
    
    
    // Update is called once per frame
    private void Update()
    {
        foreach (RectTransform r in bannerText)
        {
            Vector3 rPos = r.localPosition;
            rPos.x -= scrollSpeed * Time.deltaTime;
            rPos.x = rPos.x <= _leftLimit ? _rightLimit : rPos.x;
            r.localPosition = new Vector3(rPos.x - 10 * Time.deltaTime, rPos.y, rPos.z);
        }
    }
}
