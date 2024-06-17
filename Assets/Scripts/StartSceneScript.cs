using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class StartSceneScript : MonoBehaviour
{
    public TMP_InputField inputPlayerName;
    public TMP_InputField privateKey;
    public Image image;
    public Image image1;
    public Image image2;
    public TMP_Text room_id;
    public PlayerInfo player;
    public Button createUser;
    public Button public_room;
    public Button private_room;
    public Button join_room;
    public Button create_room;
    public int roomType;

    void Awake()
    {
        roomType = 0;
        privateKey.gameObject.SetActive(false);
        HidePublicId();
        HideButtons();
        
    }
    void Update()
    {
        if (roomType != 0 && (inputPlayerName.text == "" || !IsNameValid(inputPlayerName.text)))
        {
            createUser.interactable = false;
        }
        else
        {
            createUser.interactable = true;
        }
    }

    private bool IsNameValid(string name)
    {
        return Regex.IsMatch(name, @"^[a-zA-Z]{1,5}$");
    }

    public void ButtonCreateUser()
    {    
        player.CreatePlayer(inputPlayerName.text);
        SceneManager.LoadScene(1);
    } 

    public void HideButtons()
    {
        join_room.gameObject.SetActive(false);
        create_room.gameObject.SetActive(false);
    }
    public void ShowButtons()
    {
        join_room.gameObject.SetActive(true);
        create_room.gameObject.SetActive(true);
    }
    public void HidePublicId()
    {
        room_id.enabled = false;
        image1.enabled = false;
        image.enabled = false;
    }
    public void ShowPublicId(string id)
    {
        room_id.enabled = true;
        image1.enabled = true;
        image.enabled = true;
        room_id.text = id; 
    }
    public void PublicButton()
    {
        privateKey.gameObject.SetActive(false);
        roomType = 1;
        HideButtons();
        ShowPublicId("123"); // TUTAJ NALEZY PODAC ID PUBLICZNE Z SERWERA
    }
    public void PrivateButton()
    {
        roomType = 0;
        ShowButtons();
        HidePublicId();
    }
    public void CreateRoom()
    {
        roomType = 2;
        privateKey.gameObject.SetActive(true);
    }
    public void JoinRoom()
    {
        roomType = 3;
        privateKey.gameObject.SetActive(true);

    }
}
