namespace Assignment_3;

public class KeyValuePair
{
    public string Key { get; }

    public string Value { get; }

    public KeyValuePair(string key, string value)
    {
        Key = key;
        Value = value;
    }
}

public class LinkedListNode
{
    public KeyValuePair Pair { get; }
        
    public LinkedListNode Next { get; set; }

    public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
    {
        Pair = pair;
        Next = next;
    }
}

public class LinkedList
{
    private LinkedListNode _first;

    public void Add(KeyValuePair pair)
    {
        if (_first == null)
        {
            _first = new LinkedListNode(pair);
            _first.Next = null;
        }
        else
        {
            while (_first.Next != null)
            {
                _first = _first.Next;
            }
            LinkedListNode convertedPair = new LinkedListNode(pair);
            _first.Next = convertedPair;
        }
    }

    public void RemoveByKey(string key)
    {
        if (_first.Pair.Key == key) _first = _first.Next;
    }

    public KeyValuePair GetItemWithKey(string key)
    {
        LinkedListNode current = _first;
        while (current != null)
        {
            if(current.Pair.Key == key) return current.Pair;
            current = current.Next;
        }

        return null;

    }

    public LinkedListNode RecieveFirst()
    {
        return _first;
    }
}

