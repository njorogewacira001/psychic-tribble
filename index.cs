using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        private List<string> tasks;

        public MainForm()
        {
            InitializeComponent();
            tasks = new List<string>();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string newTask = taskTextBox.Text;
            
            if (!string.IsNullOrEmpty(newTask))
            {
                tasks.Add(newTask);
                UpdateTaskListBox();
                taskTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = taskListBox.SelectedIndex;

            if (selectedIndex != -1)
            {
                string updatedTask = Interaction.InputBox("Edit Task", "Enter the updated task:", tasks[selectedIndex]);

                if (!string.IsNullOrEmpty(updatedTask))
                {
                    tasks[selectedIndex] = updatedTask;
                    UpdateTaskListBox();
                }
            }
            else
            {
                MessageBox.Show("Please select a task to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = taskListBox.SelectedIndex;

            if (selectedIndex != -1)
            {
                tasks.RemoveAt(selectedIndex);
                UpdateTaskListBox();
            }
            else
            {
                MessageBox.Show("Please select a task to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTaskListBox()
        {
            taskListBox.Items.Clear();
            taskListBox.Items.AddRange(tasks.ToArray());
        }
    }
}
