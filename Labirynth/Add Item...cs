using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirynth
{
    public partial class Add_Item : Form
    {
        ProjectManager Master;
        Item Target;

        public Add_Item(ProjectManager master)
        {
            InitializeComponent();
            Master = master;

            foreach(Item i in Master.ItemContainer)
            {
                if (i.GetType() != typeof(Area))
                {
                    listBox1.Items.Add(i.Name);
                }
            }
            listBox1.SelectedIndex = 0;

            Target = null;
        }

        private void radioButton_Agent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Agent.Checked)
            {
                label4.Text = "Speed";
                label4.Enabled = true;
                numericUpDown1.Enabled = true;
            }
            if (radioButton_Flag.Checked)
            {
                label4.Enabled = false;
                numericUpDown1.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if (radioButton_Agent.Checked)
            {
                if (checkBox_ToSelected.Checked)
                {
                    foreach (Item i in Master.Selection)
                    {
                        Agent a = new Agent(i.Position);
                        a.Speed = (float)numericUpDown1.Value;

                        if (textBox1.Text != "")
                            a.Name = textBox1.Text;
                        else
                            a.Name = "Item" + (Master.ItemContainer.Count + 1).ToString();

                        if (Target == null)
                            Master.AddItem(a);
                        else
                            Master.AddItem(Target,a);
                    }
                }
                else
                {
                    Point pos = new Point((int)numeric_X.Value, (int)numeric_Y.Value);
                    Agent a = new Agent(pos);
                    a.Speed = (float)numericUpDown1.Value;

                    if (textBox1.Text != "")
                        a.Name = textBox1.Text;
                    else
                        a.Name = "Item" + (Master.ItemContainer.Count + 1).ToString();

                    if (Target == null)
                        Master.AddItem(a);
                    else
                        Master.AddItem(Target, a);
                }
            }
            if (radioButton_Flag.Checked)
            {
                if (checkBox_ToSelected.Checked)
                {
                    foreach (Item i in Master.Selection)
                    {
                        Flag a = new Flag(i.Position);

                        if (textBox1.Text != "")
                            a.Name = textBox1.Text;
                        else
                            a.Name = "Item" + (Master.ItemContainer.Count + 1).ToString();

                        if (Target == null)
                            Master.AddItem(a);
                        else
                            Master.AddItem(Target, a);
                    }
                }
                else
                {
                    Point pos = new Point((int)numeric_X.Value, (int)numeric_Y.Value);
                    Flag a = new Flag(pos);

                    if (textBox1.Text != "")
                        a.Name = textBox1.Text;
                    else
                        a.Name = "Item" + (Master.ItemContainer.Count + 1).ToString();

                    if (Target == null)
                        Master.AddItem(a);
                    else
                        Master.AddItem(Target, a);
                }
            }

            Close();
            Dispose();
        }

        private void checkBox_ToSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ToSelected.Checked)
            {
                numeric_X.Enabled = false;
                numeric_Y.Enabled = false;
            }
            else
            {
                numeric_X.Enabled = true;
                numeric_Y.Enabled = true;
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Target = Master.GetItem((string)((ListBox)sender).SelectedItem);
        }
    }
}
