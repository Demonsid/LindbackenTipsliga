using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string[] gamesOb = new string[13];
    public List<Game> Games = new List<Game>();
    Game game = new Game();

    protected void Page_Load(object sender, EventArgs e)
    {

        
    }

    public List<Game> GetGames()
    {
        return Games;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        API api = new API();
        api.GetApiData(false);

        //string[] gamesOb = new string[13];

        if (api.games != null)
        {
            if (api.games.draws.Length > 0)
            {
                if (api.games.draws[0].events.Length > 0)
                {
                    for (int i = 0; i < api.games.draws[0].events.Length; i++)
                    {
                        gamesOb[i] = api.games.draws[0].events[i].description;
                    }
                }
            }
            //else
            //{
            //    MessageBox.Show("Ingen matchdata finns tillgänglig");
            //}
        }

        Label1.Text = gamesOb[0];
        Label2.Text = gamesOb[1];
        Label3.Text = gamesOb[2];
        Label4.Text = gamesOb[3];
        Label5.Text = gamesOb[4];
        Label6.Text = gamesOb[5];
        Label7.Text = gamesOb[6];
        Label8.Text = gamesOb[7];
        Label9.Text = gamesOb[8];
        Label10.Text = gamesOb[9];
        Label11.Text = gamesOb[10];
        Label12.Text = gamesOb[11];
        Label13.Text = gamesOb[12];
    }
}