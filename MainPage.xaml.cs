namespace Lab6Starter;
/**
 * 
 * Name: Brady Braun and James Last
 * Date: 2022/11/5
 * Description: Drives the UI and calls upon TicTacToeGame for game logic.
 * Bugs: None that can be found.
 * Reflection: Overall lab reflection - fun lab, although there was confusion on who was to do what in that Brady ended up implementing score and winning messages. Otherwise a nice little project and
 * very educational in regards to GitHub.
 * 
 */

using Lab6Starter;


/// <summary>
/// The MainPage, this is a 1-screen app
/// </summary>
public partial class MainPage : ContentPage
{
    TicTacToeGame ticTacToe; // model class
    Button[,] grid;          // stores the buttons


    /// <summary>
    /// initializes the component
    /// </summary>
    public MainPage()
    {
        InitializeComponent();
        ticTacToe = new TicTacToeGame();
        grid = new Button[TicTacToeGame.GRID_SIZE, TicTacToeGame.GRID_SIZE] { { Tile00, Tile01, Tile02 }, { Tile10, Tile11, Tile12 }, { Tile20, Tile21, Tile22 } };
        ResetGame();
    }

    /// <summary>
    /// Handles button clicks - changes the button to an X or O (depending on whose turn it is)
    /// Checks to see if there is a victory - if so, invoke 
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleButtonClick(object sender, EventArgs e)
    {
        Player victor;
        Player currentPlayer = ticTacToe.CurrentPlayer;

        Button button = (Button)sender;
        int row;
        int col;

        FindTappedButtonRowCol(button, out row, out col);
        if (button.Text.ToString() != "")
        { // if the button has an X or O, bail
            DisplayAlert("Illegal move", "Fill this in with something more meaningful", "OK");
            return;
        }
        button.Text = currentPlayer.ToString();
        Boolean gameOver = ticTacToe.ProcessTurn(row, col, out victor);

        if (gameOver)
        {
            CelebrateVictory(victor);

        }
    }

    /// <summary>
    /// Returns the row and col of the clicked row
    /// There used to be an easier way to do this ...
    /// </summary>
    /// <param name="button"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private void FindTappedButtonRowCol(Button button, out int row, out int col)
    {
        row = -1;
        col = -1;

        for (int r = 0; r < TicTacToeGame.GRID_SIZE; r++)
        {
            for (int c = 0; c < TicTacToeGame.GRID_SIZE; c++)
            {
                if(button == grid[r, c])
                {
                    row = r;
                    col = c;
                    return;
                }
            }
        }
        
    }


    /// <summary>
    /// Celebrates victory, displaying a message box and resetting the game
    /// </summary>
    private void CelebrateVictory(Player victor)
    {
        if (victor == Player.X)
        {
            CelebratoryMessage.Text = "Player X " + WinningMessage();
            ticTacToe.XScore += 1;
        }
        else if (victor == Player.O)
        {
            CelebratoryMessage.Text = "Player O " + WinningMessage();
            ticTacToe.OScore += 1;
        }
        else
        {
            CelebratoryMessage.Text = "This game was a tie. Let's see how the next one goes!";
        }

        XScoreLBL.Text = String.Format("X's Score: {0}", ticTacToe.XScore);
        OScoreLBL.Text = String.Format("O's Score: {0}", ticTacToe.OScore);

        ResetGame();
    }

    /// <summary>
    /// Resets the grid buttons so their content is all ""
    /// </summary>
    private void ResetGame()
    {
        Tile00.Text = "";
        Tile01.Text = "";
        Tile02.Text = "";
        Tile10.Text = "";
        Tile11.Text = "";
        Tile12.Text = "";
        Tile20.Text = "";
        Tile21.Text = "";
        Tile22.Text = "";

        ChangeColor();

        ticTacToe.ResetGame();
    }

    private String WinningMessage()
    {
        string[] winningMessages = { "crushed their opponent!", "had the easiest win ever!", 
        "has won!", "rules at tic-tac-toe!", "has won, onto the next!", "is a tic-tac-toe LEGEND!"};

        Random rand = new Random();
        int index = rand.Next(winningMessages.Length);
        string message = winningMessages[index];
        return message;
    }

    /// <summary>
    /// Changes the color of the board. Board is all one color for visibility's sake.
    /// </summary>
    private void ChangeColor()
    {
        Random rand = new Random();
        int colorDetermine = rand.Next(7);
        Microsoft.Maui.Graphics.Color color;
        switch (colorDetermine)
        {
            case 0:
                color = Microsoft.Maui.Graphics.Color.Parse("Pink");
                break;
            case 1:
                color = Microsoft.Maui.Graphics.Color.Parse("Orange");
                break;
            case 2:
                color = Microsoft.Maui.Graphics.Color.Parse("Yellow");
                break;
            case 3:
                color = Microsoft.Maui.Graphics.Color.Parse("NavajoWhite");
                break;
            case 4:
                color = Microsoft.Maui.Graphics.Color.Parse("Salmon");
                break;
            case 5:
                color = Microsoft.Maui.Graphics.Color.Parse("Khaki");
                break;
            default:
                color = Microsoft.Maui.Graphics.Color.Parse("Thistle");
                break;
        }

        Tile00.BackgroundColor = color;
        Tile01.BackgroundColor = color;
        Tile02.BackgroundColor = color;
        Tile10.BackgroundColor = color;
        Tile11.BackgroundColor = color;
        Tile12.BackgroundColor = color;
        Tile20.BackgroundColor = color;
        Tile21.BackgroundColor = color;
        Tile22.BackgroundColor = color;
    }
}



