using NUnit.Framework; 
using EvolentTest;
using EvolentTest.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using EvolentTest.DAL.Model;
using EvolentTest.Controllers;
using EvolentTest.DAL.Repository;
using EvolentTest.Contract;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;


namespace EvolentUnitTestProject
{
    public class EvolentUnitTest
    {

        private readonly string SqliteDBName = "Data Source=EvolentHealth.db";

        [SetUp]
        public void SetTestData()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite(SqliteDBName)
                .Options;

            using (var RepositoryContext = new RepositoryContext(options))
            {
                RepositoryContext.Database.EnsureCreated();

                IRepositoryWrapper repository = new RepositoryWrapper(RepositoryContext);

                var controller = new ContactController(repository);

                var contactFound = repository.Contact.GetContactByFirstAndLastName("Update", "Admin");
                if (contactFound == null)
                {
                    Contact newContact = new Contact
                    {
                        FirstName = "Update",
                        LastName = "Admin",
                        Email = "updateUser@gmail.com",
                        PhoneNumber = "9988776655",
                        Status = true
                    };

                    controller.Post(newContact);
                }

                var contactalreadyExist = repository.Contact.GetContactByFirstAndLastName("Delete", "Admin");
                if (contactalreadyExist == null)
                {
                    Contact deleteContact = new Contact
                    {
                        FirstName = "Delete",
                        LastName = "Admin",
                        Email = "deleteUser@gmail.com",
                        PhoneNumber = "9988776655",
                        Status = true
                    };

                    controller.Post(deleteContact);
                }
            }
        }


        [TearDown]
        public void ClearTestData()
        {

            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite(SqliteDBName)
                .Options;

            // Create the schema in the database
            using (var RepositoryContext = new RepositoryContext(options))
            {
                RepositoryContext.Database.EnsureCreated();

                IRepositoryWrapper repository = new RepositoryWrapper(RepositoryContext);

                var controller = new ContactController(repository);

                //Clear Added User
                var newContact = repository.Contact.GetContactByFirstAndLastName("AddUser", "TestAdmin");
                if(newContact != null)
                    controller.Delete(newContact.ID);

                //Clear Updated User
                var editContact = repository.Contact.GetContactByFirstAndLastName("EditUser", "EditAdmin");
                if (editContact != null)
                    controller.Delete(editContact.ID);               
            }
        }

        [Test]
        public void GetContacts_ShouldReturnAllContacts()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite(SqliteDBName)
                .Options;

            // Create the schema in the database
            using (var RepositoryContext = new RepositoryContext(options))
            {
                RepositoryContext.Database.EnsureCreated();

                IRepositoryWrapper repository = new RepositoryWrapper(RepositoryContext);

                var controller = new ContactController(repository);
                var result = controller.Get();

                Assert.IsInstanceOf<OkObjectResult>(result);
            }
        }

        [Test]
        public void AddContact_WithSuccess()
        {

            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite(SqliteDBName)
                .Options;

            using (var RepositoryContext = new RepositoryContext(options))
            {
                RepositoryContext.Database.EnsureCreated();

                IRepositoryWrapper repository = new RepositoryWrapper(RepositoryContext);

                var controller = new ContactController(repository);

                Contact newContact = new Contact
                {                   
                    FirstName = "AddUser",
                    LastName = "TestAdmin",
                    Email = "TestUser@gmail.com",
                    PhoneNumber = "9988776655",
                    Status = true
                };

                controller.Post(newContact);

                var addedContact = repository.Contact.GetContactByFirstAndLastName("AddUser", "TestAdmin");           

                Assert.IsNotNull(addedContact);               
            }
        }


        [Test]
        public void UpdateContact_WithSuccess()
        {

            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite(SqliteDBName)
                .Options;

            // Create the schema in the database
            using (var RepositoryContext = new RepositoryContext(options))
            {
                RepositoryContext.Database.EnsureCreated();

                IRepositoryWrapper repository = new RepositoryWrapper(RepositoryContext);

                var controller = new ContactController(repository);                
              
                var objContact = repository.Contact.GetContactByFirstAndLastName("Update", "Admin");

                Contact contactToUpdate = repository.Contact.GetContactById(objContact.ID);

                contactToUpdate.FirstName = "EditUser";
                contactToUpdate.LastName = "EditAdmin";

                controller.Put(contactToUpdate.ID, contactToUpdate);

                Contact updatedContact = repository.Contact.GetContactById(contactToUpdate.ID);

                Assert.AreEqual("EditUser", updatedContact.FirstName);
                Assert.AreEqual("EditAdmin", updatedContact.LastName);                
            }
        }


        [Test]
        public void DeleteContact_WithSuccess()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite(SqliteDBName)
                .Options;
          
            // Create the schema in the database
            using (var RepositoryContext = new RepositoryContext(options))
            {
                RepositoryContext.Database.EnsureCreated();

                IRepositoryWrapper repository = new RepositoryWrapper(RepositoryContext);

                var controller = new ContactController(repository);

                var addedContact = repository.Contact.GetContactByFirstAndLastName("Delete", "Admin");

                int deleteContactId = addedContact.ID;

                controller.Delete(deleteContactId);

                Contact deletedContact = repository.Contact.GetContactById(deleteContactId);

                Assert.Null(deletedContact);
                              
            }
        }        
    }
}