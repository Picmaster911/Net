namespace TodoListPlus
{
    partial class EditeListElementForms
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
            EditeTodoListTextLabel = new Label();
            EditeTodoListTextBox = new TextBox();
            EditeTodoListTextButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 15);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 0;
            label1.Text = "EditeTodoListTextBox";
            // 
            // EditeTodoListTextLabel
            // 
            EditeTodoListTextLabel.AutoSize = true;
            EditeTodoListTextLabel.Location = new Point(61, 142);
            EditeTodoListTextLabel.Name = "EditeTodoListTextLabel";
            EditeTodoListTextLabel.Size = new Size(157, 15);
            EditeTodoListTextLabel.TabIndex = 1;
            EditeTodoListTextLabel.Text = "Item name cannot be empty";
            // 
            // EditeTodoListTextBox
            // 
            EditeTodoListTextBox.Location = new Point(17, 42);
            EditeTodoListTextBox.Name = "EditeTodoListTextBox";
            EditeTodoListTextBox.Size = new Size(235, 23);
            EditeTodoListTextBox.TabIndex = 2;
            // 
            // EditeTodoListTextButton
            // 
            EditeTodoListTextButton.Location = new Point(84, 75);
            EditeTodoListTextButton.Name = "EditeTodoListTextButton";
            EditeTodoListTextButton.Size = new Size(99, 51);
            EditeTodoListTextButton.TabIndex = 3;
            EditeTodoListTextButton.Text = "Edite List";
            EditeTodoListTextButton.UseVisualStyleBackColor = true;
            EditeTodoListTextButton.Click += EditeTodoListTextButton_Click;
            // 
            // EditeListElementForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 167);
            Controls.Add(EditeTodoListTextButton);
            Controls.Add(EditeTodoListTextBox);
            Controls.Add(EditeTodoListTextLabel);
            Controls.Add(label1);
            Name = "EditeListElementForms";
            Text = "EditeListElementForms";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label EditeTodoListTextLabel;
        private TextBox EditeTodoListTextBox;
        private Button EditeTodoListTextButton;
    }
}