using System.Data;
using System.Data.SqlClient;

namespace AdoWinFormsDataSetApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM books";
                SqlDataAdapter adapter = new(sqlQuery, connection);
                DataSet dataSet = new();
                adapter.Fill(dataSet);

                gridViewBooks.DataMember = dataSet.Tables[0].TableName;
                gridViewBooks.DataSource = dataSet;
            }
        }
    }
}