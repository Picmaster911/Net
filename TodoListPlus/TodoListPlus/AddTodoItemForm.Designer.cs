namespace TodoListPlus
{
    partial class AddTodoItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            addNewTodoItemTextBox = new TextBox();
            addNewTodoItemBtn = new Button();
            addNewTodoItemErrorLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 18);
            label1.Name = "label1";
            label1.Size = new Size(136, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter name of new item:";
            // 
            // addNewTodoItemTextBox
            // 
            addNewTodoItemTextBox.Location = new Point(10, 46);
            addNewTodoItemTextBox.Margin = new Padding(3, 2, 3, 2);
            addNewTodoItemTextBox.Name = "addNewTodoItemTextBox";
            addNewTodoItemTextBox.Size = new Size(244, 23);
            addNewTodoItemTextBox.TabIndex = 1;
            // 
            // addNewTodoItemBtn
            // 
            addNewTodoItemBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            addNewTodoItemBtn.Location = new Point(94, 81);
            addNewTodoItemBtn.Margin = new Padding(3, 2, 3, 2);
            addNewTodoItemBtn.Name = "addNewTodoItemBtn";
            addNewTodoItemBtn.Size = new Size(66, 41);
            addNewTodoItemBtn.TabIndex = 2;
            addNewTodoItemBtn.Text = "Add";
            addNewTodoItemBtn.UseVisualStyleBackColor = true;
            addNewTodoItemBtn.Click += AddTodoItemtBtn_Click;
            // 
            // addNewTodoItemErrorLabel
            // 
            addNewTodoItemErrorLabel.AutoSize = true;
            addNewTodoItemErrorLabel.ForeColor = Color.Red;
            addNewTodoItemErrorLabel.Location = new Point(54, 136);
            addNewTodoItemErrorLabel.Name = "addNewTodoItemErrorLabel";
            addNewTodoItemErrorLabel.Size = new Size(157, 15);
            addNewTodoItemErrorLabel.TabIndex = 3;
            addNewTodoItemErrorLabel.Text = "Item name cannot be empty";
            // 
            // AddTodoItemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 167);
            Controls.Add(addNewTodoItemErrorLabel);
            Controls.Add(addNewTodoItemBtn);
            Controls.Add(addNewTodoItemTextBox);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTodoItemForm";
            ShowIcon = false;
            Text = "Add new todo item";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox addNewTodoItemTextBox;
        private Button addNewTodoItemBtn;
        private Label addNewTodoItemErrorLabel;
    }
}