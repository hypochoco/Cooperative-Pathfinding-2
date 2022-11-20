// using UnityEngine;
// using System.IO;
// using System.Collections.Generic;
// using System;

// public class ReadWriteFile: MonoBehaviour {

//     private void Update() {
//         if (Input.GetKeyDown("m")) {
//             WriteCoordiantes();
//         }
//     }

//     // Write a list of coordinates into a file
//     public static void WriteCoordiantes() { // List<List<float>> coordinates

//         string path = "Assets/Scripts/Grid/test.txt";
//         StreamWriter writer = new StreamWriter(path, true);

//         List<Double> test = new List<double>() {
//             1,2,3,4
//         };

//         writer.WriteLine();
        
//         writer.Close();
//     }

// }

//     // public class RuntimeText: MonoBehaviour {
//     //     public static void WriteString() {
//     //         string path = Application.persistentDataPath + "/test.txt";
//     //        StreamWriter writer = new StreamWriter(path, true);

//     //        writer.WriteLine("Test");

//     //         writer.Close();

//     //        StreamReader reader = new StreamReader(path);

//     //        //Print the text from the file

//     //        Debug.Log(reader.ReadToEnd());

//     //        reader.Close();

//     //     }

//     //    public static void ReadString()

//     //    {

//     //        string path = Application.persistentDataPath + "/test.txt";

//     //        //Read the text from directly from the test.txt file

//     //        StreamReader reader = new StreamReader(path);
//     //         // reader.
//     //        Debug.Log(reader.ReadToEnd());

//     //        reader.Close();

//     //    }

//     // }

