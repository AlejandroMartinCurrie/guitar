using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChordController : MonoBehaviour
{
    public Chords currentChord;
    private TextMeshProUGUI chordName;
    
    
    private string namesupplay;
    public string chordnameGot;


    private bool isDragging;
    public bool selectionPressed;

    public int chordID;
    private int clickCounter;
    public int selectionNUmber;


    private Vector3 startPosition;
    public GameObject selectionController;
    public Color currentColor;

   




    // Start is called before the first frame update
    void Start()
    {
        namesupplay = currentChord.chordName;
        GetComponentInChildren<TextMeshPro>().text = namesupplay;
        startPosition = transform.position;
        currentColor = selectionController.GetComponentInChildren<SpriteRenderer>().color;
       
    }


    public void ChangePosition()
    {
        transform.position = startPosition;
    }

    public void OnMouseDown()
    {
        isDragging = true;
        clickCounter++;
        if (clickCounter == 1 )
        {
           foreach(SpriteRenderer sp in selectionController.GetComponentsInChildren<SpriteRenderer>())
            {
                
                
                    sp.color = Color.red;
                    PlayerPrefs.SetInt("Chord", selectionNUmber);
                    PlayerPrefs.SetString("Chord1Name", currentChord.chordName);
                    PlayerPrefs.Save();
                
                
            }
            
            print(currentChord);
        }
        else
        {
            foreach (SpriteRenderer sp in selectionController.GetComponentsInChildren<SpriteRenderer>())
            {
                sp.color = currentColor;
            }
            clickCounter = 0;
            
        }

    }
    public void OnMouseUp()
    {
        isDragging = false;
        
        ChangePosition();
    }

    public void DragginObject()
    {
        if(isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //print(isDragging);
        DragginObject();
        
        
    }
}
