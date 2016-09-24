using UnityEngine;
using System.Collections;
using System.IO;

public class FileLoader : MonoBehaviour
{
    static FileLoader instance;

    public static bool isLoadingURL;
    public static bool URLLoadSuccess=true;

    Stream f;

    byte[] b;

    BitArray currentBitArray;
    int currentBitArrayIndex=0;
    WWW www;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadFile(@"C:\Users\Stalhandske\Dropbox\Pictures\useless.jpg");
        //NextBit(); NextBit(); NextBit(); NextBit(); NextBit(); NextBit(); NextBit(); NextBit();
        //NextBit(); NextBit(); NextBit(); NextBit(); NextBit(); NextBit(); NextBit(); NextBit();
    }

    public static byte[] LoadAndGetFile(string path)
    {
        return File.ReadAllBytes(path);
    }

    public static void LoadFile(string path)
    {
        instance.LoadFilePrivate(path);
    }

    void LoadFilePrivate(string path)
    {
        if (f != null)
        {
            f.Close();
        }
        f = new FileStream(path, FileMode.Open);

    }

    public static void LoadFileIn(string path)
    {
        string[] files = Directory.GetFiles(path);
        if (files.Length > 0)
            LoadFile(files[Random.Range(0, files.Length)]);
    }

    public static void LoadURL(string url)
    {
        instance.LoadURLPrivate(url);
    }

    void LoadURLPrivate(string url)
    {
        StartCoroutine(LoadURLCo(url));
    }

    IEnumerator LoadURLCo(string url)
    {
        isLoadingURL = true;
        www = new WWW(url);
        yield return www;
        if (www.error != null)
        {
            Debug.Log(www.error);
            URLLoadSuccess = false;
        }
        else
        {
            Debug.Log("FINISHED LOADING DATA");
            f = new MemoryStream(www.bytes);
            URLLoadSuccess = true;
        }
        isLoadingURL = false;
    }

    public static byte NextByte()
    {
        return instance.NextBytePrivate();
    }

    byte NextBytePrivate()
    {
        //if (f.Position % 3000 == 0)
        //    Debug.Log(f.Position + "/" + f.Length);

        if (f.Position >= f.Length)
            f.Position = 0;

        return (byte)f.ReadByte();
    }

    public static bool NextBit()
    {
        return instance.NextBitPrivate();
    }

    bool NextBitPrivate()
    {

        if (currentBitArray == null || currentBitArrayIndex >= 8)
        {
            currentBitArray = new BitArray(new byte[] { (byte)f.ReadByte() });
            currentBitArrayIndex = 0;
        }
       
        return currentBitArray.Get(currentBitArrayIndex++);
    }

    public static Vector3 NextVector3()
    {
        return instance.NextVector3Private();
    }

    Vector3 NextVector3Private()
    {
        return new Vector3(NextByte(), NextByte(), NextByte());
    }

    public static Color NextColor()
    {
        return instance.NextColorPrivate();   
    }

    Color NextColorPrivate()
    {
        return new Color(NextByte() / 255f, NextByte() / 255f, NextByte() / 255f);
    }

    public static float NextFloat()
    {
        return instance.NextFloatPrivate();
    }

    float NextFloatPrivate()
    {
        return System.BitConverter.ToSingle(new byte[] { NextByte(), NextByte(), NextByte(), NextByte()}, 0);
    }
}
