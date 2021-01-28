#region USING

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class LevelManager : MonoBehaviour
{
	#region ATTRIBUTS

	[SerializeField] private Canvas gameOverMenu;
	[SerializeField] private Canvas freezeCanvas;
	public bool gameOver;
	private float _timeBeforeFreeze;
	private CharacterController2D _player;
	private float _freezeShowTime;
	private float _timeRemaining;

	#endregion

	#region MÉTHODES

	// Start is called before the first frame update
	private void Start()
	{
		this.gameOverMenu.gameObject.SetActive(false);
		this.freezeCanvas.gameObject.SetActive(false);
		this._freezeShowTime = 1.5f;
		this._timeRemaining = this._freezeShowTime;
		this._player = Object.FindObjectOfType<CharacterController2D>();
		this.gameOver = false;
		ResetTimer();
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetButtonDown(Inputs.Exit))
			SceneManager.LoadScene(Scenes.MainMenu);
		this._player.canMove = this._timeBeforeFreeze > 0;
		if (!(Input.GetButton(Inputs.Freeze) || Input.touchCount > 0 || Input.GetMouseButton(0)) && this._timeBeforeFreeze >= 0)
			this._timeBeforeFreeze -= Time.deltaTime;

		if (this._timeBeforeFreeze <= 0)
			this.freezeCanvas.gameObject.SetActive(true);

		if (this.freezeCanvas.gameObject.activeSelf)
		{
			this._timeRemaining -= Time.deltaTime;
			if(Input.GetButton(Inputs.Freeze) || Input.touchCount > 0 || Input.GetMouseButton(0))
				ResetTimer();
		}

		this.gameOverMenu.gameObject.SetActive(this.gameOver);
		if (this._timeRemaining <= 0)
		{
			this.freezeCanvas.gameObject.SetActive(false);
			this._timeRemaining = this._freezeShowTime;
		}

		if (this.gameOverMenu.gameObject.activeSelf)
			this.freezeCanvas.gameObject.SetActive(false);
	}

	private void ResetTimer()
	{
		this._timeBeforeFreeze = Global.RandomInt(3, 16);
	}

	public void Replay()
	{
		Start();
		this._player.Start();
	}

	#endregion
}