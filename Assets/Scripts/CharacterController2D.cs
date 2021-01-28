using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private float initDelayToStop;
    private float _delayToStop;
    
    
    private LevelManager _lvlManager;
    private float _xVelocity;
    // -1:Lose; 0:Idle; 1:Walk  
    private int _state;
    private Animator _animator;
    public bool canMove;
    // Start is called before the first frame update
    internal void Start()
    {
        this._lvlManager = Object.FindObjectOfType<LevelManager>();
        this._animator = GetComponent<Animator>();
        this._delayToStop = this.initDelayToStop;
    }

    // Update is called once per frame
    private void Update()
    {
        if(!this._lvlManager.gameOver)
        {
            if (!(Input.GetButton(Inputs.Freeze) || Input.touchCount > 0 || Input.GetMouseButton(0)))
            {
                if (this.canMove || this._delayToStop > 0)
                {
                    this._state = 1;
                    this.background.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(Time.deltaTime / this.background.transform.localScale.x, 0);
                    if (!this.canMove)
                        this._delayToStop -= Time.deltaTime;
                    else
                        this._delayToStop = this.initDelayToStop;
                }
                else
                {
                    this._state = -1;
                    this._lvlManager.gameOver = true;
                }
            }
            else
            {
                this._state = 0;
            }
        }
        this._animator.SetInteger(AnimatorVars.PlayerState,this._state);
    }
}
