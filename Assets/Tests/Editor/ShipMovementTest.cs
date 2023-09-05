using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SceneManagement;
public class ShipMovementTest
{
    public GameObject player;

    [SetUp]
    public void Setup()
    {
        EditorSceneManager.OpenScene("Assets\\Scenes\\Main Scene.unity");
    }

    //Testing that the player's tag is "Player"
    //Should return true
    [Test]
    public void PlayerTagTrue()
    {
        player = GameObject.Find("Player");
        Assert.AreEqual("Player", player.tag);
    }

    //Testing that the player's tag is not "Player"
    //should return false
    [Test]
    public void PlayerTagFalse()
    {
        player = GameObject.Find("Player");
        Assert.AreNotEqual("Player", player.tag);
    }
}
