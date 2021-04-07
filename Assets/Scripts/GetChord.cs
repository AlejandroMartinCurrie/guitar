using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetChord : MonoBehaviour
{
    public int numberEntered;
    public string chorNameGot;
    public int selectionChord;
    public bool pressedSelection;
  
 
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();

    }

    public void OnMouseDown()
    {
        numberEntered = PlayerPrefs.GetInt("Chord"+ selectionChord);
        chorNameGot = PlayerPrefs.GetString("Chord1Name");
        ListControllers chordList = FindObjectOfType<ListControllers>();
        chordList.chordOrder[selectionChord] = numberEntered;
        GetComponentInChildren<TextMeshPro>().text = chorNameGot;
        print(numberEntered);
        saveChords();

    }



    public void saveChords()
    {
        switch (selectionChord)
        {
            case 0:
                PlayerPrefs.SetInt("Chord" + selectionChord, numberEntered);
                PlayerPrefs.Save();
                break;
            case 1:
                PlayerPrefs.SetInt("Chord" + selectionChord, numberEntered);
                PlayerPrefs.Save();
                break;
            case 2:
                PlayerPrefs.SetInt("Chord" + selectionChord, numberEntered);
                PlayerPrefs.Save();
                break;
            case 3:
                PlayerPrefs.SetInt("Chord" + selectionChord, numberEntered);
                PlayerPrefs.Save();
                break;

        }
    }







    private void OnTriggerEnter2D(Collider2D enteredSelection)
    {
        if(enteredSelection.gameObject.tag =="SelectedChored")
        {

            ChordController chordentered = enteredSelection.gameObject.GetComponent<ChordController>();
            numberEntered = chordentered.chordID;
            chorNameGot = chordentered.currentChord.chordName;
            GetComponentInChildren<TextMeshPro>().text = chorNameGot;
            //print(numberEntered);
            //print(selectionChord);
            ListControllers chordList = FindObjectOfType<ListControllers>();


            chordList.chordOrder[selectionChord] = numberEntered;
            //if(selectionChord == 0)
            //{
            //PlayerPrefs.SetInt("Chord" + selectionChord, numberEntered);
            //}
            //else if (selectionChord == 1)
            //{
            //    PlayerPrefs.SetInt("ChorOrder1", chordList.chordOrder[selectionChord] = numberEntered);
            //    PlayerPrefs.Save();
            //}
            ////////////////////

            //print(chordList.chordOrder.Length);

            saveChords();
          




        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
