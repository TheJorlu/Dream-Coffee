using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ImageSwitcher : MonoBehaviour
{
    [System.Serializable]
    public struct SpriteInfo
    {
        public string name;
        public Sprite sprite;
    }

    public Image image;
    public SpriteInfo[] sprites;

    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    [YarnCommand("setImage")]
    public void SetImageSprite(string spriteName)
    {
        Sprite s = null;
        foreach (var info in sprites)
        {
            if (info.name == spriteName)
            {
                s = info.sprite;
                break;
            }
        }

        if (s == null)
        {
            Debug.LogErrorFormat("Can't find sprite named {0}!", spriteName);
            return;
        }

        anim.PlayNormal(.75f);
        image.sprite = s;
    }
}


