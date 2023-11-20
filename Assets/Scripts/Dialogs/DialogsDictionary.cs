using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogs
{
    public string NameCharacter;
    public string NameImageCharacter;
    public string Text;
    public int NextDialog;
}
public class DialogNumber
{
    public int DialogIdStart;
    public int DialogIdEnd;
}

public class DialogsDictionary : MonoBehaviour
{
    static Dictionary<int, DialogNumber> DicDialogsNumber()
    {
        Dictionary<int, DialogNumber> dialogs = new Dictionary<int, DialogNumber>();
        dialogs.Add(1, new DialogNumber() { DialogIdStart = 0, DialogIdEnd = 3 });
        dialogs.Add(2, new DialogNumber() { DialogIdStart = 4, DialogIdEnd = 9 });
        return dialogs;
    }
   static Dictionary<int, Dialogs> DicDialogs()
    {
        Dictionary<int , Dialogs> dialogs = new Dictionary<int , Dialogs>();
        dialogs.Add(0, new Dialogs() { NameCharacter = "You", NameImageCharacter = "You", Text = "Excuse me, I've lost my ticket. Can I still go in?", NextDialog = 0 });
        dialogs.Add(1, new Dialogs() { NameCharacter = "Mysterious Stranger", NameImageCharacter = "Mysterious Stranger", Text = "Without a ticket, entry is not permitted. But if you find it by completing a few tasks, you'll be allowed through.", NextDialog = 1 });
        dialogs.Add(2, new Dialogs() { NameCharacter = "You", NameImageCharacter = "You", Text = "What do I need to do?", NextDialog = 2 });
        dialogs.Add(3, new Dialogs() { NameCharacter = "Mysterious Stranger", NameImageCharacter = "Mysterious Stranger", Text = "Explore the theater and unravel its mysteries. Your tasks are intertwined with the magic of this place. Good luck finding your ticket!", NextDialog = 3 });
        dialogs.Add(4, new Dialogs() { NameCharacter = "You", NameImageCharacter = "You", Text = "I found the ticket! It was hidden among the theater's mysteries, just like you said.", NextDialog = 4 });
        dialogs.Add(5, new Dialogs() { NameCharacter = "Mysterious Stranger", NameImageCharacter = "Mysterious Stranger", Text = "Ah, splendid! Your diligence has paid off. The magic of this theater is not just in its performances, but also in the journey it takes to experience them.", NextDialog = 5 });
        dialogs.Add(6, new Dialogs() { NameCharacter = "You", NameImageCharacter = "You", Text = "It was an incredible adventure. I never expected to go through such challenges just to find a ticket.", NextDialog = 6 });
        dialogs.Add(7, new Dialogs() { NameCharacter = "Mysterious Stranger", NameImageCharacter = "Mysterious Stranger", Text = "That's the beauty of this place. Every visit is an adventure, every performance a journey. Now, you may enter and enjoy the show. May the magic of the theater enlighten your evening.", NextDialog = 7 });
        dialogs.Add(8, new Dialogs() { NameCharacter = "You", NameImageCharacter = "You", Text = "Thank you. I'm looking forward to the experience. This whole quest has already made my visit unforgettable.", NextDialog = 8 });
        dialogs.Add(9, new Dialogs() { NameCharacter = "Mysterious Stranger", NameImageCharacter = "Mysterious Stranger", Text = "Remember, every moment in the theater is a part of the performance. Enjoy every second. Have a magical evening!", NextDialog = 9 });
        return dialogs;
    }
    public Dictionary<int, Dialogs> dicDialogs = DicDialogs();
    public Dictionary<int, DialogNumber> dicDialogsNumber = DicDialogsNumber();
}
