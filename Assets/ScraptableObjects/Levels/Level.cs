using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Level" , menuName ="Levels")]
public class Level : ScriptableObject
{
    public int _lvlIndex;
    public string _lvlName;
    public string _lvlDescription;
    public Object _lvlScene;
    public Sprite _lvlImage;
}
