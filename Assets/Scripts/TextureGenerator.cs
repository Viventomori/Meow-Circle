using UnityEngine;

public class TextureGenerator : MonoBehaviour
{
    [SerializeField] public Texture2D textures;
    [SerializeField] private Sprite mySprite;
    [SerializeField] private int _resolution;
    [SerializeField] private FilterMode _filterMode;
    [SerializeField] private TextureWrapMode texturesWrapMode;

    void Start()
    {

        mySprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        textures = mySprite.texture;
        textures = new Texture2D(_resolution, _resolution);
            GetComponent<Renderer>().material.mainTexture = textures;
       
        if(textures.width != _resolution)
        {
            textures.Reinitialize(_resolution, _resolution);
        }

        textures.filterMode = _filterMode;
        textures.wrapMode = TextureWrapMode.Clamp;

        float step = 1f / _resolution;

        for(int y = 0; y < _resolution; y++)
        {
            for(int x = 0; x < _resolution; x++)
            {
                textures.SetPixel(x, y, new Color(x * step, y * step, 0f, 1f));
            }
        }
        textures.Apply();
    }
    
 
}
