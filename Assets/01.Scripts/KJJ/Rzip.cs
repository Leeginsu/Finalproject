using System.IO;
using System.IO.Compression;
using UnityEngine;

public class Rzip : MonoBehaviour
{
    public string zipFilePath; // 압축 파일의 경로
    public string extractionPath; // 압축을 해제할 경로

    private void Start()
    {
        // 알집의 위치 + 이름
        zipFilePath = Application.dataPath + "/screenshot.zip";
        // 압출풀 위치 + 폴더이름
        extractionPath = Application.dataPath + "/Resources";
        // 압축 풀기 함수 호출
        Unzip(zipFilePath, extractionPath);
    }

    void Unzip(string zipPath, string extractionPath)
    {
        try
        {
            // 압축 파일을 지정된 경로에서 추출
            ZipFile.ExtractToDirectory(zipPath, extractionPath);
            Debug.Log("압축 파일이 성공적으로 해제되었습니다.");
        }
        catch (IOException e)
        {
            Debug.LogError("압축 파일을 해제하는 중에 오류 발생: " + e.Message);
        }
    }
}