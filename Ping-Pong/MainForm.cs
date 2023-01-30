/*
 * Created by SharpDevelop.
 * User: Artem
 * Date: 20.06.2018
 * Time: 14:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ping_Pong
{
	
	public partial class MainForm : Form
	{
		Graphics graphics;
		Timer timer = new Timer();
		
		int FPS = 144;
		int player1y;
		int player2y;
		
		int ballx;
		int bally;
		int ballspdx = 3;
		int ballspdy = 3;
		
		//-------------------------------	
		public MainForm()
		{
			InitializeComponent();
			
			timer.Enabled = true;
        	timer.Interval = 1000 / FPS;
        	timer.Tick += new EventHandler(TimerCallback);
        	
        	ballx = this.Width / 2 - 10;
        	bally = this.Height / 2 - 10;
		}
		
		//Graphics
		void DrawRectangle(int x, int y, int w, int h, SolidBrush Color){
			graphics.FillRectangle(Color, new Rectangle(x,y,w,h));
			
		}
		
		void UpdateBall(){
			ballx += ballspdx;
			bally += ballspdy;
			
			if (IsCollided())
			{
				ballspdx = -ballspdx;
			}
			
			if (ballx <= 0 || ballx + 40 >= this.Width){
				label1.Visible = true;
				timer.Stop();
			}

			if(bally <= 0 || bally + 20 >= this.ClientSize.Height){
				ballspdy = -ballspdy;
			}
			
		}
		
		bool IsCollided(){
			if(ballx <= 20 && bally >= player1y && bally <= player1y + 130){
				return true;
			} else if (ballx >= this.ClientSize.Width - 40 && bally >= player2y && bally <= player2y + 130)
            {
				return true;
            }
			else
			{
				return false;
			}
			
		}

		
		
		void TimerCallback(object sender, EventArgs e)
	    {
			DrawRectangle(0,player1y,20,130,new SolidBrush(Color.Blue));
			DrawRectangle(this.ClientSize.Width - 20, player2y,this.ClientSize.Width,130,new SolidBrush(Color.GreenYellow));
			DrawRectangle(ballx,bally,20,20,new SolidBrush(Color.Orange));
			UpdateBall();
			
	        this.Invalidate();
	        return;
	    }
		
		//Control
		void MainFormPaint(object sender, PaintEventArgs e)
		{
			graphics =  CreateGraphics();
			DrawRectangle(0,player1y,20,130,new SolidBrush(Color.Blue));
			DrawRectangle(this.ClientSize.Width - 20, player2y,this.ClientSize.Width, 130,new SolidBrush(Color.GreenYellow));
			DrawRectangle(ballx,bally,20,20,new SolidBrush(Color.Orange));
		}
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			//MessageBox.Show(Convert.ToString(e.KeyValue));
			int key = e.KeyValue;
			if(key ==  83){
				player1y -= 5;
			}

			if(key ==  88){
				player1y += 5;
			}
			
			if(key ==  38){
				player2y -= 5;
			}

			if(key == 40){
				player2y += 5;
			}
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
