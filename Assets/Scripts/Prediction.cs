using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prediction : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _dotPrefab;
    [SerializeField] private GameObject _gameBox;
    [SerializeField] private int _frameCount = 50;

    private List<GameObject> _dotList = new List<GameObject>();
    private GameObject _ballInPhysicsScene;
    private PhysicsScene _physicsScene;
    private GameObject _gameBoxInPhysicsScene;
    
    private void Start()
    {
        for (int i = 0; i < _frameCount; i++)
        {
            GameObject newDot = Instantiate(_dotPrefab);
            _dotList.Add(newDot);
        }

        Scene predictionScene = SceneManager.CreateScene("PredictionScene", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        _physicsScene = predictionScene.GetPhysicsScene();
        _ballInPhysicsScene = Instantiate(_ball);
        _gameBoxInPhysicsScene = Instantiate(_gameBox);
        _ballInPhysicsScene.GetComponent<Rigidbody>().isKinematic = false;
        SceneManager.MoveGameObjectToScene(_ballInPhysicsScene, predictionScene);
        SceneManager.MoveGameObjectToScene(_gameBox, predictionScene);
    }

    private void Update()
    {
        _ballInPhysicsScene.transform.position = _ball.transform.position;
        _ballInPhysicsScene.transform.rotation = _ball.transform.rotation;
        _ballInPhysicsScene.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _ballInPhysicsScene.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        for (int i = 0; i < _frameCount; i++)
        {
            _dotList[i].transform.position = _ballInPhysicsScene.transform.position;
            _physicsScene.Simulate(Time.fixedDeltaTime);
        }
    }
}
