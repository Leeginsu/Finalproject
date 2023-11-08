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
        // Photon ���� ���� ����
        //PhotonNetwork.ConnectUsingSettings();
        Texture2D qrCodeTexture = GenerateQRCode("02. LobbyScene");
        qrCodeImage.texture = qrCodeTexture;
    }

    private void Update()
    {
        if (!isConnected)
        {
            // Photon ������ ���� ������� �ʾҴٸ� QR �ڵ带 �����ϰ� ȭ�鿡 ǥ��
            string serverAddress = PhotonNetwork.ServerAddress;
            if (!string.IsNullOrEmpty(serverAddress))
            {
                Texture2D qrCodeTexture = GenerateQRCode(serverAddress);
                qrCodeImage.texture = qrCodeTexture;

                connectionStatusText.text = "��ĵ�Ͽ� �����ϼ���";
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
    //    connectionStatusText.text = "�� ���� ����";
    //}
}
