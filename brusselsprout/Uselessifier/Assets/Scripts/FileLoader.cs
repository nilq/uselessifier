using UnityEngine;
using System.Collections;
using System.IO;

public class FileLoader : MonoBehaviour
{
    static FileLoader instance;

    FileStream f;

    byte[] b;

    BitArray currentBitArray;
    int currentBitArrayIndex=0;

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
}
