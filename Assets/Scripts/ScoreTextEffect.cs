// Made by: Irmin Verhoeff
// Version: 1.0.0

// This script handles the effect for the score numbers, which happens after a point is scored.
// It enlarges and fades away the score number, then returns it to it's original size and resets it's opacity



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextEffect : MonoBehaviour
{
    GameObject player1Score;
    GameObject player2Score;
    TextMeshProUGUI player1TMPGUI;
    TextMeshProUGUI player2TMPGUI;

    [SerializeField] float _scoreTextMaxSize;
    float scoreDefaultSize;
    [SerializeField] float _fontSizeChangeValue;
    [SerializeField] float alphaChangeValue;

    //ParticleSystem[] _playerScoreParticeSystems;

    BallMovement ballMovement;

    int[] _playersScore = {0, 0};

    // Start is called before the first frame update
    void Start()
    {

        // First, i get the playerscore gameobjects which store the score number
        player1Score = GameObject.Find("Player1Score");
        player2Score = GameObject.Find("Player2Score");
        Debug.Log($"player 1 score: {player1Score.name}");
        Debug.Log($"player 2 score: {player2Score.name}");

        /* This was an idea to use a particle system somewhere, but i think it's unecessary 
        _playerScoreParticeSystems = new ParticleSystem[2];

        if (!player1Score.TryGetComponent<ParticleSystem>(out _playerScoreParticeSystems[0]) && 
            !player2Score.TryGetComponent<ParticleSystem>(out _playerScoreParticeSystems[1]))
        {
            _playerScoreParticeSystems[0] = player1Score.AddComponent<ParticleSystem>();
            _playerScoreParticeSystems[1] = player2Score.AddComponent<ParticleSystem>();
            Debug.Log($"Particle systems added to TMPro score elements of player 1 and player 2");
        }
        */

        // Then i get their components
        if (!player1Score.TryGetComponent<TextMeshProUGUI>(out player1TMPGUI))
        {
            Debug.Log($"Couldn't find player 1 score text, Text Mesh Pro component");
        }
        
        if (!player2Score.TryGetComponent<TextMeshProUGUI>(out player2TMPGUI))
        {
            Debug.Log($"Couldn't find player 2 score text, Text Mesh Pro component");
        }

        if (player1TMPGUI.fontSize == player2TMPGUI.fontSize)
        {
            scoreDefaultSize = player1TMPGUI.fontSize;
        }
        else
        {
            Debug.Log($"Player one score text and player 2 score text have two different sizes, if this is intended" +
                $" the score effect script needs to be changed - Irmin Verhoeff");
        }

        // I also need the Ballmovement script, because this is where i detect a point being scored
        ballMovement = FindObjectOfType<BallMovement>();

        // I store the score values locally in this script
        // This way, when there is a change, we can deduce a point has been scored
        // You can also see this in FixedUpdate
        _playersScore[0] = ballMovement.playerScoreNumber[0];
        _playersScore[1] = ballMovement.playerScoreNumber[1];
    }

    // Update is called once per frame
    void Update()
    {
        //playEffect(false);
    }

    private void FixedUpdate()
    {
        if (_playersScore[0] != ballMovement.playerScoreNumber[0])
        {
            Debug.Log("change detected play false");

            StartCoroutine(PlayEffect(false));
            _playersScore[0] = ballMovement.playerScoreNumber[0];
        }

        if (_playersScore[1] != ballMovement.playerScoreNumber[1])
        {
            Debug.Log("change detected, play true");

            StartCoroutine(PlayEffect(true));
            _playersScore[1] = ballMovement.playerScoreNumber[1]; 
        }
        //Debug.Log($"_playerScore {_playersScore[0]}");
        //Debug.Log($"ballmovement {ballMovement.playerScoreNumber[0]}");
    }

    // BEHOLD! the mighty Coroutine,
    // With this i make it so my effect can run syncronously with other processes, and time it perfectly.

    // yield return new WaitForSeconds(time) is used to time the effect

    // false is to play the effect for player 1, true is for player 2
    IEnumerator PlayEffect(bool whichPlayerScored)
    {
        if (whichPlayerScored)
        {
            while (player2TMPGUI.fontSize < _scoreTextMaxSize || player2TMPGUI.alpha > 0)
            {
                player2TMPGUI.fontSize += _fontSizeChangeValue;
                player2TMPGUI.alpha -= alphaChangeValue;
                Debug.Log($"alpha: {player2TMPGUI.alpha}");

                yield return new WaitForSeconds(0.001f);
            }
        }

        if (!whichPlayerScored)
        {
            while (player1TMPGUI.fontSize < _scoreTextMaxSize || player1TMPGUI.alpha > 0)
            {
                player1TMPGUI.fontSize += _fontSizeChangeValue;
                player1TMPGUI.alpha -= alphaChangeValue;
                Debug.Log($"alpha: {player1TMPGUI.alpha}");

                yield return new WaitForSeconds(0.001f);
            }
        }

        // Here i return the alpha and the fontsize back to their default values
        // 1 is completely visible
        // 0 is invisible
        player1TMPGUI.alpha = 1;
        player2TMPGUI.alpha = 1;
        // I declared scoreDefaultSize at the start of the script
        player1TMPGUI.fontSize = scoreDefaultSize;
        player2TMPGUI.fontSize = scoreDefaultSize;

        // Now the Coroutine can stop, (i don't know if i need to use StopCoroutine)
        StopCoroutine("PlayEffect");
        yield return null;
    }
}
