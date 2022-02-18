using System.Security.Cryptography;
using System.Text;

namespace Assignment_3;

public class StringsDictionary
{
    private const int InitialSize = 10; // change to 1000 at finish

    private LinkedList[] _buckets = new LinkedList[InitialSize];

    private static int occupied;
    private double loadFactor = occupied / InitialSize; // must not exceed 1.25
    
        
    public void Add(string key, string value)
    {
            
    }

    public void Remove(string key)
    {
            
    }

    public string Get(string key)
    {
        return key;
    }


    public static int CalculateHash(string key)
    {
        MD5 md5Hasher = MD5.Create();
        var hash = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(key));
        int hashedKey = BitConverter.ToInt32(hash, 0);
        return hashedKey;
    }
    
}