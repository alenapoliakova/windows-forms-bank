using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace lab_1
{
    public partial class AddEditPersonForm : Form
    {
        private int action;
        public Person person;

        private int BANK_CARD_LENGTH = 5;
        private readonly string NO_DATA = "";
        private readonly int ADD = 0;
        private readonly int EDIT = 1;

        private readonly Color DEFAULT_FORM_COLOR = Color.FromArgb(192, 192, 255);
        private readonly Color CHANGED_FORM_COLOR = Color.FromArgb(255, 192, 255);

        private List<AuthorizationForm> authorizedForms = new();
        private bool authorized = false;

        private Thread tr;

        public AddEditPersonForm(int action, Person pers, SortingType sortType)
        {
            InitializeComponent();
            this.action = action;
            this.person = pers;
            this.BackColor = DEFAULT_FORM_COLOR;

            if (action == EDIT)
            {
                dateTimePicker1.Enabled = false;
                textBox3.Enabled = false;
                textBox1.Text = this.person.Name;
                dateTimePicker1.Value = this.person.Birthday;
                textBox3.Text = this.person.CardNumber.ToString();
                label2.Text = "Edit person";
            }
            else if (action == ADD) {
                label2.Text = "Create person";
            }

            var firstLabelLocation = new Point(206, 128);
            var secondLabelLocation = new Point(206, 168);
            var thirdLabelLocation = new Point(206, 203);

            var firstTextLocation = new Point(318, 128);
            var secondTextLocation = new Point(318, 168);
            var thirdTextLocation = new Point(318, 203);

            if (sortType == SortingType.byName)
            {
                label1.Location = firstLabelLocation;
                label3.Location = secondLabelLocation;
                label4.Location = thirdLabelLocation;

                textBox1.Location = firstTextLocation;
                dateTimePicker1.Location = secondTextLocation;
                textBox3.Location = thirdTextLocation;
            }
            else if (sortType == SortingType.byBirthday && action == EDIT)
            {
                label1.Location = secondLabelLocation;
                label3.Location = firstLabelLocation;
                label4.Location = thirdLabelLocation;

                textBox1.Location = secondTextLocation;
                dateTimePicker1.Location = firstTextLocation;
                textBox3.Location = thirdTextLocation;
            }
            else if (sortType == SortingType.byCardNumber && action == EDIT)
            {
                label1.Location = secondLabelLocation;
                label3.Location = thirdLabelLocation;
                label4.Location = firstLabelLocation;

                textBox1.Location = secondTextLocation;
                dateTimePicker1.Location = thirdTextLocation;
                textBox3.Location = firstTextLocation;
            }

            this.tr = new Thread(checkLogins);
            tr.Start();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            // Apply
            var name = textBox1.Text;
            var cardNumber = textBox3.Text;
            var date = dateTimePicker1.Value.Date;
            if (action == ADD)
            {
                if (name != NO_DATA && cardNumber.Length == BANK_CARD_LENGTH && date <= new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day))
                {
                    int card;
                    if (int.TryParse(cardNumber, out card))
                    {
                        person = new Person(card, name, date);
                        DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        MessageBox.Show(Text = "No valid data");
                    }
                }
                else
                {
                    MessageBox.Show(Text = "No valid data");
                }
            }
            else if (action == EDIT) {
                if (authorized && name != NO_DATA && cardNumber.Length == BANK_CARD_LENGTH && date <= DateTime.Now)
                {
                    int card;
                    if (int.TryParse(cardNumber, out card))
                    {
                        if (card == person.CardNumber)
                        {
                            person = new Person(card, name, date);
                            DialogResult = DialogResult.Yes;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Text = "No valid data");
                    }
                }
                else if (!authorized & name != NO_DATA)
                {
                    person = new Person(person.CardNumber, name, person.Birthday);
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show(Text = "No valid data");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cancel
            this.Hide();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (action == EDIT)
            {
                if (e.Control && e.Shift && e.KeyCode == Keys.L)
                {
                    AuthorizationForm authorizedForm = new AuthorizationForm();
                    authorizedForm.Show();
                    authorizedForms.Add(authorizedForm);
                }
            }
        }

        private void checkLogins()
        {
            while (true)
            {
                foreach (AuthorizationForm form in authorizedForms)
                {
                    if (form.status && action == EDIT)
                    {
                        try
                        {
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    this.BackColor = CHANGED_FORM_COLOR;
                                    dateTimePicker1.Enabled = true;
                                    textBox3.Enabled = true;
                                    authorized = true;
                                }));
                                return;
                            }
                        }
                        catch (Exception ex) { }
                    }
                }
                
                if (this.InvokeRequired && action == EDIT)
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            this.BackColor = DEFAULT_FORM_COLOR;
                            dateTimePicker1.Enabled = false;
                            textBox3.Enabled = false;
                        }));
                    }
                    catch (Exception ex) { }

                }
                Thread.Sleep(2);
            }
        }

        private void start_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void Form2_Load(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            var name = textBox1.Text;
            var cardNumber = textBox3.Text;
            var date = dateTimePicker1.Value.Date;

            Random rand = new Random();

            var x = button1.Location.X;
            var y = button1.Location.Y;

            var width = this.Size.Width;
            var height = this.Size.Height;

            var spaceX = rand.Next(15);
            var spaceY = rand.Next(15);

            if (action == EDIT && authorized && name != NO_DATA && cardNumber.Length == BANK_CARD_LENGTH && date <= new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day))
            {
                int card;
                if (int.TryParse(cardNumber, out card))
                {
                    if (card != person.CardNumber)
                    {
                        if ((Math.Abs(x) - e.X) < Math.Abs(x - width) || (Math.Abs(y) - e.Y) < (Math.Abs(y - height)) 
                            || (Math.Abs(x) + e.X) < Math.Abs(x + width) || (Math.Abs(y) + e.Y) < (Math.Abs(y + height))) 
                        {
                            button1.Location = new Point(button1.Location.X + e.X - spaceX, button1.Location.Y + e.Y - spaceY);
                            if (x < 0)
                            {
                                button1.Location = new Point(width, button1.Location.Y);
                            }
                            if (button1.Location.X > width)
                            {
                                button1.Location = new Point(0, button1.Location.Y);
                            }
                            if (button1.Location.Y < 0)
                            {
                                button1.Location = new Point(button1.Location.X, height);
                            }
                            if (button1.Location.Y > 426)
                            {
                                button1.Location = new Point(button1.Location.X, 0);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(Text = "No valid data");
                }
            }
        }

        private void Form2_Deactivate(object sender, EventArgs e) { }
    }
}
