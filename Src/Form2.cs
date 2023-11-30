using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TVStoreApp
{
    public partial class Form2 : TVStoreApp.Form1
    {
        private BindingSource masterBindingSource = new BindingSource();
        private BindingSource detailsBindingSource = new BindingSource();

        public Form2()
        {
            InitializeComponent();


            // Initialize connection to the database
            String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TVProductsDatabase.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);

            // Create a new DataSet
            DataSet tvProductsData = new DataSet();
            tvProductsData.Locale = System.Globalization.CultureInfo.InvariantCulture;

            // Add Products table to DataSet
            SqlDataAdapter masterDataAdapter = new
                SqlDataAdapter("select * from Products", connection);
            masterDataAdapter.Fill(tvProductsData, "Products");

            // Add ProductDetail table to DataSet
            SqlDataAdapter detailsDataAdapter = new
                SqlDataAdapter("select * from ProductDetail", connection);
            detailsDataAdapter.Fill(tvProductsData, "ProductDetail");

            // Create relation between tables
            DataRelation relation = new DataRelation("Products_ProductDetail",
                tvProductsData.Tables["Products"].Columns["ProduktId"],
                tvProductsData.Tables["ProductDetail"].Columns["ProduktId"]);
            tvProductsData.Relations.Add(relation);

            // Set binding source for Products grid
            masterBindingSource.DataSource = tvProductsData;
            masterBindingSource.DataMember = "Products";

            // Set binding source for ProductDetail grid
            detailsBindingSource.DataSource = masterBindingSource;
            detailsBindingSource.DataMember = "Products_ProductDetail";

            // Set data sources for grid controls
            productsGrid.DataSource = masterBindingSource;
            productDetailGrid.DataSource = detailsBindingSource;

        }
    }
}
