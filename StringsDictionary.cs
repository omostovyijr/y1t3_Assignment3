using System.Security.Cryptography;
using System.Text;

namespace Assignment_3;

public class StringsDictionary
{
    private static int InitialSize = 10; // change to 1000 at finish

    private LinkedList[] _buckets = new LinkedList[InitialSize];

    private static int occupied;
    private double loadFactor = occupied / InitialSize;
    private double allowedLoadFactor = 1.25;
    
        
    public void Add(string key, string value)
    {
        int hash = CalculateHash(key);
        int index = hash / InitialSize;
        KeyValuePair toAdd = new KeyValuePair(key, value);
        LinkedList first = _buckets[index];
        if (first == null)
        {
            _buckets[index] = new LinkedList();
            _buckets[index].Add(toAdd);
            occupied += 1;
        }
        else
        {
            _buckets[index].Add(toAdd);
            occupied += 1;
        }

        CheckLoadFactor();
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

    private void CheckLoadFactor()
    {
        if (loadFactor >= allowedLoadFactor)
        {
            int newSize = InitialSize * 2;
            InitialSize = newSize;
            LinkedList[] newBuckets = new LinkedList[newSize];
            foreach(var element in _buckets)
            {
                if(element == null) continue;
                LinkedListNode currentElement = element.RecieveFirst();
                while (currentElement != null)
                {
                    int hash = CalculateHash(currentElement.Pair.Key);
                    int index = hash / InitialSize;
                    KeyValuePair toAdd = currentElement.Pair;
                    LinkedList first = _buckets[index];
                    if (first == null)
                    {
                        newBuckets[index] = new LinkedList();
                        newBuckets[index].Add(toAdd);
                        occupied += 1;
                    }
                    else
                    {
                        newBuckets[index].Add(toAdd);
                        occupied += 1;
                    }
                }
            }
            _buckets = newBuckets;
            occupied = 0;
        }
    }
    
}