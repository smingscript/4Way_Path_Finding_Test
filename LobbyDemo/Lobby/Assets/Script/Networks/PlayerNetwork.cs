using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour
{
    #region outlets
    public static PlayerNetwork Instance;
    
    public string PlayerName { get; private set; }
    #endregion

    #region fields
    
    #endregion

    #region messages

    private void Awake()
    {
        Instance = this;

        PlayerName = "teamClue" + Random.Range(1000, 9999);
        
    }

    #endregion	

    #region methods
    
    #endregion
}
