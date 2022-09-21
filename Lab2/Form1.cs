namespace Lab2
{
    public partial class Form1 : Form
    {
        string filepath;
        readonly Serializable serializable;
        Dogs? dogs;

        public Form1()
        {
            InitializeComponent();
            serializable = new Serializable();
        }

        // Открытие XML
        private void button1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog? ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xml";
            ofd.Filter = "XML Files (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
            {
                textBox1.Text = ofd.FileName;
                filepath = ofd.FileName;
                using (StreamReader reader = new StreamReader(filepath))
                {
                    richTextBox1.Text = reader.ReadToEnd();
                }
            }
        }

        // Преобразоание XML
        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox1.Text) == "")
            {
                MessageBox.Show("Откройте файл.", "Ошибка");
                return;
            }
            try
            {
                dogs = serializable.deserialize(filepath);
                for (int i = 0; i < dogs.dog.Count; ++i)
                {
                    DOG? dog = dogs.dog[i];
                    ListViewItem element = new ListViewItem();
                    element.SubItems.Add(new ListViewItem.ListViewSubItem(element, dog.dogName));
                    element.SubItems.Add(new ListViewItem.ListViewSubItem(element, dog.dogWeight));
                    element.SubItems.Add(new ListViewItem.ListViewSubItem(element, dog.dogColor));
                    listView1.Items.Add(element);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
            }
        }
    }
}