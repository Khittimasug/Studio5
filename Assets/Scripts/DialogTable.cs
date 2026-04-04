using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class DialogTable
{
    public List<Sprite> characterProfile = new List<Sprite>();
    public List<string> characterName = new List<string>();
    public UnityEvent eventActive;
    public List<DialogAndEventActive> dialogAndEventActive;
}
