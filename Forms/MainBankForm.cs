using System.Windows.Forms;

namespace lab_1
{
    public partial class MainBankForm : Form
    {
        private readonly int ADD = 0;
        private readonly int EDIT = 1;

        private readonly string ASC_SORT = "ASC";
        private readonly string DESC_SORT = "DESC";

        private SortingType sortedBy = SortingType.notSorted;

        public MainBankForm()
        {
            InitializeComponent();

            listBox1.Items.Add(new Person(
                33355, "Alena", new DateTime(2003, 5, 6)
            ));
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add button logic
            AddEditPersonForm addingForm = new AddEditPersonForm(ADD, null, sortedBy);
            DialogResult dr = addingForm.ShowDialog(this);

            if (dr == DialogResult.Yes)
            {
                listBox1.Items.Add(addingForm.person);
            }
            addingForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Edit button logic
            if (listBox1.SelectedItems.Count == 1)
            {
                for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    Person person = (Person)listBox1.SelectedItems[i];
                    AddEditPersonForm editingForm = new AddEditPersonForm(EDIT, person, sortedBy);
                    DialogResult dr = editingForm.ShowDialog(this);

                    if (dr == DialogResult.Yes || dr == DialogResult.Cancel)
                    {
                        editingForm.Close();
                    }
                    // Replace person
                    listBox1.Items.Remove(person);
                    listBox1.Items.Add((Person)editingForm.person);
                }
            }
            else
            {
                MessageBox.Show(Text = "Select one item to edit it");
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            // Delete button logic
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show(Text = "Select item to delete it");
                return;
            }
            if (MessageBox.Show("Are you really want to delete person data?", "Confirm your actions", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void SortByName_Click(object sender, EventArgs e)
        {
            List<Person> items = listBox1.Items.OfType<Person>().ToList();
            var sortingType = sortType.Text.ToString();

            if (sortingType == ASC_SORT)
            {
                items.Sort((person1, person2) => person1.Name.CompareTo(person2.Name));
            }
            else if (sortingType == DESC_SORT)
            {
                items.Sort((person1, person2) => person2.Name.CompareTo(person1.Name));
            }

            listBox1.Items.Clear();
            foreach (Person person in items)
            {
                listBox1.Items.Add(person);
            }
            sortedBy = SortingType.byName;
        }

        private void SortByCard_Click(object sender, EventArgs e)
        {
            List<Person> items = listBox1.Items.OfType<Person>().ToList();
            var sortingType = sortType.Text.ToString();

            if (sortingType == ASC_SORT)
            {
                items.Sort((person1, person2) => person1.CardNumber.CompareTo(person2.CardNumber));
            }
            else if (sortingType == DESC_SORT)
            {
                items.Sort((person1, person2) => person2.CardNumber.CompareTo(person1.CardNumber));
            }

            listBox1.Items.Clear();
            foreach (Person person in items)
            {
                listBox1.Items.Add(person);
            }
            sortedBy = SortingType.byCardNumber;
        }

        private void SortByAge_Click(object sender, EventArgs e)
        {
            List<Person> items = listBox1.Items.OfType<Person>().ToList();
            var sortingType = sortType.Text.ToString();

            if (sortingType == ASC_SORT)
            {
                items.Sort((person1, person2) => person1.Birthday.CompareTo(person2.Birthday));
            }
            else if (sortingType == DESC_SORT)
            {
                items.Sort((person1, person2) => person2.Birthday.CompareTo(person1.Birthday));
            }

            listBox1.Items.Clear();
            foreach (Person person in items)
            {
                listBox1.Items.Add(person);
            }
            sortedBy = SortingType.byBirthday;
        }

        private void sortType_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}