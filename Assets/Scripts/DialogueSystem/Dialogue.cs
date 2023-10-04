using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    public string CharacterName;
    public string Text;
    public Sprite Sprite;

}

public class Dialogue : MonoBehaviour
{
    public List<Interaction> interactions;
}
