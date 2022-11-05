namespace Lab6Starter;

/**
 * 
 * Name: Brady Braun and James Last
 * Date: 2022/11/5
 * Description: The Player class, tightly woven into the fabric of TicTacToeGame.
 * Bugs: I couldn't find any bugs here, or more accurately the bugs that were present in the program were fixed by editing elsewhere!
 * Reflection: See MainPage reflection.
 * 
 */


/// <summary>
/// A Player is either an X, O, Nobody, or Both
/// </summary>
enum Player :int
{
    X = 1, O = 0, Nobody = 100, Both = 500
}