using Microsoft.VisualBasic;

namespace DesignPatterns.di_12_06;

public class Room
{
    private Dictionary<string, IRoom> _roomsElements = new  Dictionary<string, IRoom>();
    
    private Me _me = new Me();
    
    public void Add(string elName, IInHand room)
    {
        _roomsElements.Add(elName, room);
    }

    public Room()
    {
        init();
    }
    
    
    public void LightOn()
    {
        Console.WriteLine("Light is on");
        if (_roomsElements.ContainsKey("lamp"))
        {
            Console.WriteLine("Lamp is on");
        }
        else
        {
            IRoom lamp = Lamp.Instance;
            _roomsElements.Add("lamp", lamp);
            Console.WriteLine("Lamp was added to the room");
        }
    }

    public void init()
    {
        _roomsElements.Add("kbt", new KeyBoard());
        _roomsElements.Add("mou", new Mouse());
    }
    
    public void run()
    {
        // Console.WriteLine("You are in the room");
        // Console.WriteLine("You can see:");
        // foreach (var el in _roomsElements)
        // {
        //     Console.WriteLine(el.Key);
        // }
        //
        // Console.WriteLine("What do you want to take?");
        // var elName = Console.ReadLine();
        //
        // if (_roomsElements.ContainsKey(elName))
        // {
        //     _me.setHand(_roomsElements[elName]);
        //     Console.WriteLine($"You took {elName}");
        // }
        // else
        // {
        //     Console.WriteLine("There is no such element in the room");
        // }

    }
    
}