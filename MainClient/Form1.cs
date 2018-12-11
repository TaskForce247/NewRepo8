using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Forms.Integration;

using ControlsLibrary;
using Panel = System.Windows.Forms.Panel;

namespace MainClient
{
    public partial class Form1 : Form
    {
        private Panel panelEmployee, panelTabs, panelMain;
        private UserControl2 ctrlTabs;
        private UserControl3 ctrlMain;
        private UserControl1 ctrlEmp;
        public Form1()
        {
            InitializeComponent();
            SplitTheScreen();
            BringForthTheInterfaces();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshMain(ctrlTabs.openedTab);   
        }

        private void SplitTheScreen()
        {
            
            panelEmployee = new Panel();
            panelTabs = new Panel();
            panelMain = new Panel();

            panelEmployee.Location = new Point(0, 0);
            panelEmployee.Name = "panelEmployee";
            panelEmployee.Size = new Size(900, 100);
            panelEmployee.TabIndex = 0;
            panelEmployee.TabStop = false;

            panelTabs.Location = new Point(0, 100);
            panelTabs.Name = "panelTabs";
            panelTabs.Size = new Size(250, 500);
            panelTabs.TabIndex = 1;
            panelTabs.TabStop = false;

            panelMain.Location = new Point(250, 100);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(650, 500);
            panelMain.TabIndex = 2;
            panelMain.TabStop = false;

            this.Controls.Add(panelEmployee);
            this.Controls.Add(panelTabs);
            this.Controls.Add(panelMain);
            
        }

        private void BringForthTheInterfaces()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            ctrlTabs = new UserControl2();
            ctrlEmp = new UserControl1();
            ctrlMain = new UserControl3();
            panelEmployee.Controls.Add(ctrlEmp);
            panelTabs.AutoScroll = true;
            panelTabs.Controls.Add(ctrlTabs);
            panelMain.Controls.Add(ctrlMain);
        }

        private void RefreshMain(int tab)
        {
            ctrlMain.Refresh(tab);

        }

        public static void MandatoryfieldsWarning()
        {
            MessageBox.Show("All fields are mandatory!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
