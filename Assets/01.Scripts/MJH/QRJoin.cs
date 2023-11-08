using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using Photon.Pun;
using Photon.Realtime;

public class QRJoin : MonoBehaviour
{
    public RawImage qrCodeImage;
    public Text connectionStatusText;

    private bool isConnected = false;

    private void Start()
    {
        // Photon 서버 연결 설정
        //PhotonNetwork.ConnectUsingSettings();
        Texture2D qrCodeTexture = GenerateQRCode("02. LobbyScene");
        qrCodeImage.texture = qrCodeTexture;
    }

    private void Update()
    {
        if (!isConnected)
        {
            // Photon 서버에 아직 연결되지 않았다면 QR 코드를 생성하고 화면에 표시
            string serverAddress = PhotonNetwork.ServerAddress;
            if (!string.IsNullOrEmpty(serverAddress))
            {
                Texture2D qrCodeTexture = GenerateQRCode(serverAddress);
                qrCodeImage.texture = qrCodeTexture;

                connectionStatusText.text = "스캔하여 연결하세요";
                isConnected = true;
            }
        }
        
    }

    public Texture2D GenerateQRCode(string data)
    {
        Texture2D qrCodeTexture = new Texture2D(256, 256);
        Color32[] pixels = new Color32[256 * 256];
        var encoded = new BarcodeWriter();
        encoded.Format = BarcodeFormat.QR_CODE;
        encoded.Options = new QrCodeEncodingOptions
        {
            Width = 256,
            Height = 256
        };
        var color32 = encoded.Write(data);
        qrCodeTexture.SetPixels32(color32);
        qrCodeTexture.Apply();
        return qrCodeTexture;
    }

    //public void OnPhotonJoinRoomFailed()
    //{
    //    connectionStatusText.text = "방 참가 실패";
    //}
}
