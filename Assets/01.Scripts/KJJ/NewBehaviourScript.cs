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
        //    // Texture Type�� Sprite�� �����մϴ�.
        //    textureImporter.textureType = TextureImporterType.Sprite;

        //    // ����� ������ �����մϴ�.
        //    AssetDatabase.ImportAsset(texturePath);
        //}

        //else
        //{
        //    Debug.LogError("������ ������Ʈ�� �ؽ�ó�� �ƴմϴ�.");
        //}

    }
}
