using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToe
{
	internal class GameConstructor
	{

		private char[] boardArr;
		private int player; //By default player is set  
		private int userChoice; //This is the UserChoice at User which position user want to mark   
		private int flag;  // The flag veriable checks who has won if it's value is 1 then some one has won the match if -1 then Match has Draw if 0 then match is still running  

		//This is Defualt PBoardArrameter we use in Constructor to check if they dont get pBoardArrameter to give them allready.
		private readonly char[] defaultBoardArr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //default I am providing 0-9 where no use of zero  
		private int defaultPlayer = 1;

		public GameConstructor() //We made Simply Constructor without Parameter
		{
			this.boardArr = defaultBoardArr;
			if (BoardArr == null)
			{
				this.boardArr = defaultBoardArr;
			}
			this.player = Player;
			if (Player == 0)
			{
				this.player = defaultPlayer;
			}
			this.userChoice = UserChoice;
			this.flag = Flag;

		}

		// Get and Set for all Variable
		public char[] BoardArr
		{
			get { return boardArr; }
			set { boardArr = value; }
		}
		public int Player
		{
			get { return player; }
			set { player = value; }
		}
		public int UserChoice
		{
			get { return userChoice; }
			set { userChoice = value; }
		}
		public int Flag
		{
			get { return flag; }
			set { flag = value; }
		}
		private void BoardDisplay()  // Board method which creats board  
		{

			Console.WriteLine("     |     |      ");
			Console.WriteLine("  {0}  |  {1}  |  {2}", BoardArr[1], BoardArr[2], BoardArr[3]);
			Console.WriteLine("_____|_____|_____ ");
			Console.WriteLine("     |     |      ");
			Console.WriteLine("  {0}  |  {1}  |  {2}", BoardArr[4], BoardArr[5], BoardArr[6]);
			Console.WriteLine("_____|_____|_____ ");
			Console.WriteLine("     |     |      ");
			Console.WriteLine("  {0}  |  {1}  |  {2}", BoardArr[7], BoardArr[8], BoardArr[9]);
			Console.WriteLine("     |     |      ");

		}

		private int CheckWin() //Checking that any player has won or not 

		{

			#region Horzontal Winning Condtion

			//Winning Condition For First Row   

			if (BoardArr[1] == BoardArr[2] && BoardArr[2] == BoardArr[3])

			{

				return 1;

			}

			//Winning Condition For Second Row   

			else if (BoardArr[4] == BoardArr[5] && BoardArr[5] == BoardArr[6])

			{

				return 1;

			}

			//Winning Condition For Third Row   

			else if (BoardArr[6] == BoardArr[7] && BoardArr[7] == BoardArr[8])

			{

				return 1;

			}

			#endregion



			#region vertical Winning Condtion

			//Winning Condition For First Column       

			else if (BoardArr[1] == BoardArr[4] && BoardArr[4] == BoardArr[7])

			{

				return 1;

			}

			//Winning Condition For Second Column  

			else if (BoardArr[2] == BoardArr[5] && BoardArr[5] == BoardArr[8])

			{

				return 1;

			}

			//Winning Condition For Third Column  

			else if (BoardArr[3] == BoardArr[6] && BoardArr[6] == BoardArr[9])

			{

				return 1;

			}

			#endregion



			#region Diagonal Winning Condition

			else if (BoardArr[1] == BoardArr[5] && BoardArr[5] == BoardArr[9])

			{

				return 1;

			}

			else if (BoardArr[3] == BoardArr[5] && BoardArr[5] == BoardArr[7])

			{

				return 1;

			}

			#endregion



			#region Checking For Draw 

			// If all the cells or values filled with X or O then any player has won the match  

			else if (BoardArr[1] != '1' && BoardArr[2] != '2' && BoardArr[3] != '3' && BoardArr[4] != '4' && BoardArr[5] != '5' && BoardArr[6] != '6' && BoardArr[7] != '7' && BoardArr[8] != '8' && BoardArr[9] != '9')

			{

				return -1;

			}

			#endregion

			#region else

			else

			{

				return 0;

			}
			#endregion
		}



		public void Main()
		{
			do

			{

				Console.Clear();// whenever loop will be again start then screen will be clear  

				Console.WriteLine("Player1:X and Player2:O");

				Console.WriteLine("\n");

				if (Player % 2 == 0)//checking the chance of the player  

				{

					Console.WriteLine("Player 2 (O) Chance");

				}

				else

				{

					Console.WriteLine("Player 1 (X) Chance");

				}

				Console.WriteLine("\n");

				BoardDisplay();// calling the board Function  
				Console.Write("Please UserChoice From Board :");
				UserChoice = int.Parse(Console.ReadLine());//Taking users UserChoice   




				// checking that position where user want to run is marked (with X or O) or not  

				if (BoardArr[UserChoice] != 'X' && BoardArr[UserChoice] != 'O')

				{

					if (Player % 2 == 0) //if chance is of player 2 then mark O else mark X  

					{

						BoardArr[UserChoice] = 'O';

						Player++;

					}

					else

					{

						BoardArr[UserChoice] = 'X';

						Player++;

					}

				}

				else //If there is any possition where user want to run and that is already marked then show message and load board again  

				{

					Console.WriteLine("Sorry the row {0} is already marked with {1}", UserChoice, BoardArr[UserChoice]);

					Console.WriteLine("\n");

					Console.WriteLine("Please wait 2 second board is loading again.....");

					Thread.Sleep(2000); // I use this Thread for hold Text about  Console.Writeline

				}

				Flag = CheckWin();// calling of check win  

			} while (Flag != 1 && Flag != -1);// This loof will be run until all cell of the grid is not marked with X and O or some player is not win  



			Console.Clear();// clearing the console  

			BoardDisplay();// getting filled board again  



			if (Flag == 1)// if flag value is 1 then some one has win or means who played marked last time which has win  

			{

				Console.WriteLine("Player {0} has won", BoardArr[UserChoice], (Player % 2) + 1);
				// We Use BoardArr[Choiice] to show at end Who's char name Won

			}

			else     // if flag value is -1 the match will be draw and no one is winner  
			{
				Console.WriteLine("Draw");
			}

			Console.ReadLine();
		}
	}
}
