using UnityEngine;
using System.Collections;
using UnityEditor;

public class TestMethodMenu : Editor {
    [MenuItem("Window/TestMethod #g")]
    static void TestMethod() {
        Debug.LogError("TestMethod");
    }
}
