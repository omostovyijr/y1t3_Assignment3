using System.Security.Cryptography;
using System.Text;

namespace Assignment_3;

public class StringsDictionary
{
    private static int _initialSize = 100000; //Need to implement resizing, for now it have bugs(

    private LinkedList[] _buckets = new LinkedList[_initialSize];

    private static int _occupied = 0;
    private double loadFactor = _occupied / _initialSize;
    private double allowedLoadFactor = 1.25;
    
        
    public void Add(string key, string value)
    {
        int hash = CalculateHash(key);
        int index = hash % _initialSize;
        KeyValuePair toAdd = new KeyValuePair(key, value);
        LinkedList first = _buckets[index];
        if (first == null)
        {
            _buckets[index] = new LinkedList();
            _buckets[index].Add(toAdd);
            _occupied += 1;
        }
        else
        {
            _buckets[index].Add(toAdd);
            _occupied += 1;
        }

        CheckLoadFactor();
    }

    public void Remove(string key)
    {
        int hash = CalculateHash(key);
        int index = hash % _initialSize;
        LinkedList first = _buckets[index];
        if(first == null) return;
        first.RemoveByKey(key);
    }

    public string Get(string key)
    {
        int hash = CalculateHash(key);
        int index = hash % _initialSize;
        LinkedList first = _buckets[index];
        if (first == null) return "Error|Not found";
        if (first.ReceiveFirst != null)
        {
            LinkedListNode currentElement = first.ReceiveFirst();
            while (currentElement.Pair.Key != key)
            {
                currentElement = currentElement.Next;
                if(currentElement == null) break;
            }

            if (currentElement.Pair.Key == key)
            {
                return currentElement.Pair.Value;
            }
                
        }
        return "Error|Not found";
    }


    private static int CalculateHash(string key)
    {
        MD5 md5Hasher = MD5.Create();
        var hash = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(key));
        int hashedKey = BitConverter.ToInt32(hash, 0);
        return Math.Abs(hashedKey);
    }

    private void CheckLoadFactor()
    {
        if (loadFactor >= allowedLoadFactor)
        {
            int newSize = _initialSize * 2;
            _initialSize = newSize;
            LinkedList[] newBuckets = new LinkedList[newSize];
            foreach(var element in _buckets)
            {
                if(element == null) continue;
                LinkedListNode currentElement = element.ReceiveFirst();
                while (currentElement != null)
                {
                    int hash = CalculateHash(currentElement.Pair.Key);
                    int index = hash / _initialSize;
                    KeyValuePair toAdd = currentElement.Pair;
                    LinkedList first = _buckets[index];
                    if (first == null)
                    {
                        newBuckets[index] = new LinkedList();
                        newBuckets[index].Add(toAdd);
                        _occupied += 1;
                    }
                    else
                    {
                        newBuckets[index].Add(toAdd);
                        _occupied += 1;
                    }
                }
            }
            _buckets = newBuckets;
            _occupied = 0;
        }
    }
    
}