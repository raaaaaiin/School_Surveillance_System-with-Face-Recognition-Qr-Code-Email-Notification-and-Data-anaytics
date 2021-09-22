﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class previlages : Form
    {
        bool[] isPressed = {false,false,false,false,false,false,false,false};
        bool isResetable = false;
        
        menu _main;
        function _func = new function();
        public previlages(menu ths)
        {
            InitializeComponent();
            _main = ths;
            bunifuPictureBox1.BorderRadius = 25;


        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            lightup(panelbooks);

            if (isPressed[0] == false)
            {

                _main.hide();
                _func.loadDataBook();
                reset();
                _main.showMenu2("Book");
                isPressed[0] = true;


            }
            
            
        }
        private void lightup(System.Windows.Forms.Panel Lit)
        {
            panelbooks.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneladd.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneledit.BackColor = Color.FromArgb(100, 32, 32, 32);
            panelrecord.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneledit.BackColor = Color.FromArgb(100, 32, 32, 32);
            Lit.BackColor = Color.Gold;

        }
        private void lightup()
        {
            panelbooks.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneladd.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneledit.BackColor = Color.FromArgb(100, 32, 32, 32);
            panelrecord.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneledit.BackColor = Color.FromArgb(100, 32, 32, 32);

        }

        private void previlages_Load(object sender, EventArgs e)
        {
            lightup();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            _func.loadDataStud();
            lightup(paneladd);
            if (isPressed[1] == false)
            {
                _main.reset();
                reset();
                _main.addstud();
                isPressed[1] = true;
                

            }

        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            lightup(paneledit);
            if (isPressed[2] == false)
            {
                _main.reset();
                reset();
                _main.addbook();
                isPressed[2] = true;
                
            }
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuTileButton8_Click(object sender, EventArgs e)
        {
            lightup(panelbooks);
            if (isPressed[4] == false)
            {
                _main.hide();
                _func.loadDataBook();
                reset();
                _main.showMenu2("STD");
                isPressed[4] = true;


            }
            lightup(panelrecord);
        }

        private void Return_Click(object sender, EventArgs e)
        {
         
        }

        private void Profile_Click(object sender, EventArgs e)
        {
       
        }


        private void Logout_Click_1(object sender, EventArgs e)
        {
           
        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void reset()
        {
           for (int i = 0; i != isPressed.Length; i++)
            {
                isPressed[i] = false;
            }
        }

        private void Records_Click(object sender, EventArgs e)
        {
            _main.showRecord();
        }
    }
}
