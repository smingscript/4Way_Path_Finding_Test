using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    #region outlets
    
    #endregion

    #region fields
    private Animator animator;
    #endregion

    #region messages

    void Start()
    {
        animator = GetComponent<Animator>();
        if (!animator)
        {
            Debug.LogError("PlayerAnimatorManager is Missing Animator Component",this);
        }
    }

    void Update()
    {
        if (!animator)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if( v < 0 )
        {
            v = 0;
        }

        if(animator.gameObject.activeSelf)
            animator.SetFloat( "Speed", h*h+v*v );
    }
    #endregion	

    #region methods
    
    #endregion
}
