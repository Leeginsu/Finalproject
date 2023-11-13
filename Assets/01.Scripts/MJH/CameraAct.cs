using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class CameraAct : MonoBehaviourPunCallbacks
{
    public GameObject cameraGroup;
    public GameObject controllerGroup;
    //public GameObject selectGroup;

    public RawImage cameraViewImage;
    public Text resultText;

    private WebCamTexture camTexture;
    private Rect screenRect;
    private bool isScanning = false;
    //private bool isConnected = false;

    void Start()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
    }

    void Update()
    {
        if(NetworkManager.instance.isMoblie)
        {
            if(Input.GetKeyDown(KeyCode.F1))
            {
                //resultText.text = "QR Code Scanned: " + result.Text;
                isScanning = false;

                //selectGroup.SetActive(true);
                controllerGroup.SetActive(false);
                cameraGroup.SetActive(false);
                //PhotonNetwork.Instantiate("Player_Photon", LobbyManager.instance.readyPlayer[LobbyManager.instance.idx].position, Quaternion.identity);
                //LobbyManager.instance.GameScene(titleText);

                PhotonNetwork.JoinRoom("11");
            }
        }
        if (isScanning == true)
        {
            //print("스캐닝 중");
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);

            if (result != null)
            {
                Debug.Log("QR Code Scanned: " + result.Text);
                resultText.text = "QR Code Scanned: " + result.Text;
                isScanning = false;

                //selectGroup.SetActive(true);
                controllerGroup.SetActive(false);
                cameraGroup.SetActive(false);
                //PhotonNetwork.Instantiate("Player_Photon", LobbyManager.instance.readyPlayer[LobbyManager.instance.idx].position, Quaternion.identity);
                //LobbyManager.instance.GameScene(titleText);
                
                PhotonNetwork.JoinRoom(result.Text);
                //PhotonNetwork.LoadLevel("TemaScene");

                //if (result.Text == "02. LobbyScene")
                //{
                //    //SceneManager.LoadScene("02. LobbyScene");
                //    PhotonNetwork.Instantiate("Player_Photon", LobbyManager.instance.readyPlayer[LobbyManager.instance.idx].position, Quaternion.identity);
                //} 
                //if (!isConnected)
                //{
                //    ConnectToPhotonServer(result.Text);
                //    isConnected = true;
                //}
            }
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        PhotonNetwork.LoadLevel("TemaScene");
    }

        public void StartScanning()
    {
        print("22");
        isScanning = true;
    }

    //void ConnectToPhotonServer(string serverAddress)
    //{
    //    // Photon 서버 연결 로직 작성
    //    PhotonNetwork.ConnectUsingSettings();
    //}

    //public void OnConnectedToMaster()
    //{
    //    PhotonNetwork.JoinLobby();
    //}

    //public void OnJoinedLobby()
    //{
    //    // Photon 로비에 참가한 후 게임 룸에 입장할 수 있음.
    //}

    public void CameraOn()
    {
        controllerGroup.SetActive(false);
        cameraGroup.SetActive(true);

        // 카메라 권환 확인
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }

        if (WebCamTexture.devices.Length == 0)
        {
            Debug.Log("No Camera!");
            return;
        }

        WebCamDevice[] devices = WebCamTexture.devices;
        int selectedCameraIndex = -1;

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                selectedCameraIndex = i;
                break;
            }
        }

        if (selectedCameraIndex >= 0)
        {
            camTexture = new WebCamTexture(devices[selectedCameraIndex].name);
            camTexture.requestedFPS = 30;

            cameraViewImage.texture = camTexture;
            camTexture.Play();
            StartScanning();
        }

        
    }

    public void CameraOff()
    {
        cameraGroup.SetActive(false);
        controllerGroup.SetActive(true);

        if (camTexture != null)
        {
            camTexture.Stop();
            WebCamTexture.Destroy(camTexture);
            camTexture = null;
        }
    }
}
