using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserDetails : MonoBehaviour {

	static string userName = "";
	static int userXP = 0;
	static int userHighscore = 0;
	static List<Player> players = new List<Player>();

	public void UpdateUserXP(int xp)
	{
		userXP += xp;
	}

	public int SendUserXP()
	{
		return userXP;
	}

	public string SendUserName()
	{
		return userName;
	}

	public void UpdateUserName(string name)
	{
		userName = name;
	}

	public int SendUserHighscore()
	{
		return userHighscore;
	}

	public void UpdateHighscore(int Highscore)
	{
		if (Highscore > userHighscore) 
		{
			userHighscore = Highscore;
		}
	}

	public void LogToPlayer()
	{
		bool playerFound = false;

		foreach (Player p in players) 
		{
			if (p.Username == userName) 
			{
				p.XP = userXP;
				if (p.Highscore < userHighscore)
					p.Highscore = userHighscore;
				playerFound = true;
				break;
			}
		}

		if(!playerFound)
		{
			players.Add (new Player (userName, userXP, userHighscore));
		}
	}

	public void LoadUser()
	{
		bool userFound = false;

		foreach (Player p in players) 
		{
			if (p.Username == userName) 
			{
				userXP = p.XP;
				userHighscore= p.Highscore;
				userFound = true;
			}
		}

		if (!userFound) 
		{
			userXP = 0;
			userHighscore = 0;
		}
	}
}

public class Player
{
	public string Username;
	public int XP;
	public int Highscore;

	public Player(string username, int xp, int highscore)
	{
		Username = username;
		XP = xp;
		Highscore = highscore;
	}
}
