using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        Texture2D tex = Resources.Load("Piece_0") as Texture2D;
        
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
        sr.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        //string texturePath = AssetDatabase.GetAssetPath(Selection.activeObject);

        //TextureImporter textureImporter = AssetImporter.GetAtPath(texturePath) as TextureImporter;

        //if (textureImporter != null)
        //{
        //    // Texture Type을 Sprite로 설정합니다.
        //    textureImporter.textureType = TextureImporterType.Sprite;

        //    // 변경된 설정을 저장합니다.
        //    AssetDatabase.ImportAsset(texturePath);
        //}

        //else
        //{
        //    Debug.LogError("선택한 오브젝트는 텍스처가 아닙니다.");
        //}

    }
}
