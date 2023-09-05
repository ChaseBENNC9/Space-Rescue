using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SceneManagement;

public class NewTestScript
{
    public GameObject Ball;
    public GameObject plane;
        [SetUp]
    public void Setup()
    {
        EditorSceneManager.OpenScene("Assets\\Scenes\\SampleScene.unity");
    }
    // A Test behaves as an ordinary method
    [Test]
    public void testBallObject()
    {
        Ball = GameObject.Find("Sphere");
        Assert.AreEqual("Sphere", Ball.name);

    }
    // A Test behaves as an ordinary method
    [Test]
    public void testPlaneObject()
    {
        plane = GameObject.Find("Plane");
        Assert.AreEqual("Plane", plane.name);

    }

}
