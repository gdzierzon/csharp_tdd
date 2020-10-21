using System;
using System.Data.SqlClient;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Database.Tests
{
    [TestFixture]
    public class CategoryTests
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=true;min pool size=2;";
        private SqlConnection connection;
        private SqlTransaction transaction;

        [OneTimeSetUp]
        public void Initialize()
        {
            connection = new SqlConnection(connectionString);
        }

        [SetUp]
        public void Setup()
        {
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            transaction.Rollback();
            connection.Close();

        }
        

        [Test]
        public void Insert_NameOnly()
        {
            // Arrange
            var insert = "INSERT INTO Categories (CategoryName) VALUES ('New Category')";
            var command = new SqlCommand(insert, connection, transaction);

            var select = "SELECT * FROM Categories WHERE CategoryName = 'New Category'";
            var selectCommand = new SqlCommand(select, connection, transaction); 

            // Act
            int numberInserted = command.ExecuteNonQuery();
            var reader = selectCommand.ExecuteReader();

            // Assert

            int counter = 0;
            while (reader.Read())
            {
                counter++;
                Console.WriteLine(reader.GetInt32(0));
                Console.WriteLine(reader.GetString(1));
                Assert.That(reader.GetString(1), Is.EqualTo("New Category"));
            }
            Assert.AreEqual(1, counter);

            reader.Close();
            


        }
    }
}