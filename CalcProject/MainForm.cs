using System;
using System.Windows.Forms;

public class MainForm : Form
{
   private TextBox display;
   private Button[] numberButtons;
   private Button subtractButton;
   private Button multiplyButton;
   private Button divideButton;
   private Button additionButton;
   private Button clearButton;
   private Button squareButton;
   private Label resultLabel;
   private Label operationResultLabel;
   private double firstNumber;
   private double secondNumber;
   private string operation;
   private bool isSecondNumber;

   public MainForm()
   {
      // Set the size of the form
      this.Size = new System.Drawing.Size(1000, 1000);

      display = new TextBox { Location = new System.Drawing.Point(100, 15), Width = 800, ReadOnly = true, TextAlign = HorizontalAlignment.Right };
      numberButtons = new Button[10];
      for (int i = 0; i < 10; i++)
      {
         numberButtons[i] = new Button { Text = i.ToString(), Width = 50, Height = 50 };
         numberButtons[i].Click += NumberButton_Click;
      }

      subtractButton = new Button { Text = "Subtract", Width = 70, Height = 50 };
      multiplyButton = new Button { Text = "Multiply", Width = 70, Height = 50 };
      divideButton = new Button { Text = "Divide", Width = 70, Height = 50 };
      additionButton = new Button { Text = "Add", Width = 70, Height = 50 };
      clearButton = new Button { Text = "Clear", Width = 70, Height = 50 };
      squareButton = new Button { Text = "Square", Width = 70, Height = 50 };
      resultLabel = new Label { Location = new System.Drawing.Point(15, 350), Width = 950 };
      operationResultLabel = new Label { Location = new System.Drawing.Point(15, 425), Width = 950 };

      subtractButton.Click += OperationButton_Click;
      multiplyButton.Click += OperationButton_Click;
      divideButton.Click += OperationButton_Click;
      additionButton.Click += OperationButton_Click;
      clearButton.Click += ClearButton_Click;
      squareButton.Click += OperationButton_Click;

      Controls.Add(display);
      for (int i = 0; i < 10; i++)
      {
         int row = (i == 0) ? 3 : (i - 1) / 3;
         int col = (i == 0) ? 1 : (i - 1) % 3;
         numberButtons[i].Location = new System.Drawing.Point(15 + col * 60, 45 + row * 60);
         Controls.Add(numberButtons[i]);
      }
      subtractButton.Location = new System.Drawing.Point(15, 300);
      multiplyButton.Location = new System.Drawing.Point(90, 300);
      divideButton.Location = new System.Drawing.Point(165, 300);
      additionButton.Location = new System.Drawing.Point(240, 300);
      clearButton.Location = new System.Drawing.Point(315, 300);
      squareButton.Location = new System.Drawing.Point(390, 300);

      Controls.Add(subtractButton);
      Controls.Add(multiplyButton);
      Controls.Add(divideButton);
      Controls.Add(additionButton);
      Controls.Add(clearButton);
      Controls.Add(squareButton);
      Controls.Add(resultLabel);
      Controls.Add(operationResultLabel);
   }

   private void NumberButton_Click(object sender, EventArgs e)
   {
      Button button = sender as Button;
      display.Text += button.Text;
   }

   private void OperationButton_Click(object sender, EventArgs e)
   {
      Button button = sender as Button;
      if (!isSecondNumber)
      {
         if (button == squareButton)
         {
            firstNumber = double.Parse(display.Text);
            secondNumber = double.Parse(display.Text);
            operation = button.Text;
            PerformOperation();
            isSecondNumber = false;
         }
         else
         {
            firstNumber = double.Parse(display.Text);
            operation = button.Text;
            display.Clear();
            isSecondNumber = true;
         }
      }
      else
      {
         secondNumber = double.Parse(display.Text);
         PerformOperation();
         isSecondNumber = false;
      }
   }

   private void ClearButton_Click(object sender, EventArgs e)
   {
      display.Clear();
      resultLabel.Text = string.Empty;
      operationResultLabel.Text = string.Empty;
      firstNumber = 0;
      secondNumber = 0;
      operation = string.Empty;
      isSecondNumber = false;
   }

   private void PerformOperation()
   {
      switch (operation)
      {
         case "Subtract":
            Subtraction subtraction = new Subtraction();
            resultLabel.Text = "Result: " + subtraction.Subtract(firstNumber, secondNumber);
            break;
         case "Square":
            SquareOperation square = new SquareOperation();
            resultLabel.Text = "Result: " + square.Square(firstNumber);
            break;
         case "Multiply":
            Multiplication multiplication = new Multiplication();
            resultLabel.Text = "Result: " + multiplication.Multiply(firstNumber, secondNumber);
            break;
         case "Divide":
            Division division = new Division();
            try
            {
               resultLabel.Text = "Result: " + division.Divide(firstNumber, secondNumber);
            }
            catch (DivideByZeroException ex)
            {
               resultLabel.Text = "Error: " + ex.Message;
            }
            break;
         case "Add":
            Addition addition = new Addition();
            resultLabel.Text = "Result: " + addition.Add(firstNumber, secondNumber);
            break;
      }
      operationResultLabel.Text = "Operation: " + operation + " " + firstNumber + " and " + secondNumber;
      display.Clear();
   }

   [STAThread]
   public static void Main()
   {
      Application.EnableVisualStyles();
      Application.Run(new MainForm());
   }
}