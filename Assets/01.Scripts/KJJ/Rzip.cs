using System.IO;
using System.IO.Compression;
using UnityEngine;

public class Rzip : MonoBehaviour
{
    public string zipFilePath; // ���� ������ ���
    public string extractionPath; // ������ ������ ���

    private void Start()
    {
        
        
    }
    private void Update()
    {
        // ���� �̸��� ���� ���
        string[] fileName = Directory.GetFiles(Application.dataPath);

        // ���� ã��
        for (int i = 0; i < fileName.Length; i++)
        {
            // ���� .zip�� �̸��� ���� ������ �ִٸ�
            if (fileName[i].Contains(".zip"))
            {
                print(fileName[i]);
                // �����ڴ�.
                //RUnZip(fileName[i]);
            }
        }
    }

    void RUnZip(string zip)
    {
        // ������ ��ġ + �̸�
        zipFilePath = Application.persistentDataPath + "/" + zip;
        // ����Ǯ ��ġ + �����̸�
        extractionPath = Application.dataPath + "/Resources";
        // ���� Ǯ�� �Լ� ȣ��
        Unzip(zipFilePath, extractionPath);
        File.Delete(zipFilePath);
    }

    void Unzip(string zipPath, string extractionPath)
    {
        try
        {
            // ���� ������ ������ ��ο��� ����
            ZipFile.ExtractToDirectory(zipPath, extractionPath);
            Debug.Log("���� ������ ���������� �����Ǿ����ϴ�.");
        }
        catch (IOException e)
        {
            Debug.LogError("���� ������ �����ϴ� �߿� ���� �߻�: " + e.Message);
        }
    }
}