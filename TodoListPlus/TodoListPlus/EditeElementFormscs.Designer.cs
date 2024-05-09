namespace TodoListPlus
{
    partial class EditeElementFormscs
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
            EditeElementButton = new Button();
            EditeTodoItemBox = new TextBox();
            label2 = new Label();
            editeNewTodoItemErrorLabel = new Label();
            SuspendLayout();
            // 
            // EditeElementButton
            // 
            EditeElementButton.Location = new Point(85, 80);
            EditeElementButton.Name = "EditeElementButton";
            EditeElementButton.Size = new Size(93, 48);
            EditeElementButton.TabIndex = 0;
            EditeElementButton.Text = "Edite";
            EditeElementButton.UseVisualStyleBackColor = true;
            EditeElementButton.Click += EditeElementButton_Click;
            // 
            // EditeTodoItemBox
            // 
            EditeTodoItemBox.Location = new Point(17, 38);
            EditeTodoItemBox.Name = "EditeTodoItemBox";
            EditeTodoItemBox.Size = new Size(230, 23);
            EditeTodoItemBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 10);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 3;
            label2.Text = "EditeTodoItemTextBox";
            // 
            // editeNewTodoItemErrorLabel
            // 
            editeNewTodoItemErrorLabel.AutoSize = true;
            editeNewTodoItemErrorLabel.ForeColor = Color.Red;
            editeNewTodoItemErrorLabel.Location = new Point(59, 143);
            editeNewTodoItemErrorLabel.Name = "editeNewTodoItemErrorLabel";
            editeNewTodoItemErrorLabel.Size = new Size(157, 15);
            editeNewTodoItemErrorLabel.TabIndex = 4;
            editeNewTodoItemErrorLabel.Text = "Item name cannot be empty";
            // 
            // EditeElementFormscs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 167);
            Controls.Add(editeNewTodoItemErrorLabel);
            Controls.Add(label2);
            Controls.Add(EditeTodoItemBox);
            Controls.Add(EditeElementButton);
            Name = "EditeElementFormscs";
            Text = "EditeElementFormscs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EditeElementButton;
        private TextBox EditeTodoItemBox;
        private Label label2;
        private Label editeNewTodoItemErrorLabel;
    }
}