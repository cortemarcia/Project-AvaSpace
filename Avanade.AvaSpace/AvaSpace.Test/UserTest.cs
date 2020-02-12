﻿using AvaSpace.Domain.Entities;
using AvaSpace.Domain.Interfaces.Services;
using AvaSpace.Domain.Services;
using AvaSpace.Repository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AvaSpace.Test
{
    [TestClass]
    public class UserTest
    {
        private readonly IUserService _service;

        public UserTest()
        {
            var repository = new UserRepository();

            _service = new UserService(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameNull()
        {
            var user = new User("", "teste", DateTime.Now, "female");

            _service.Insert(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailNull()
        {
            var user = new User("teste", "", DateTime.Now, "female");

            _service.Insert(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmailInvalid()
        {
            var user = new User("teste", "teste", DateTime.Now, "female");

            _service.Insert(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PasswordNull()
        {
            var user = new User("teste", "teste", DateTime.Now, "female");
            _service.Insert(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PasswordInvalid()
        {
            var user = new User("teste", "teste", DateTime.Now, "female");
            user.Password = "1234567";

            _service.Insert(user);
        }

        // Perguntar pro filipe
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void BirthdaydNull()
        //{
        //    var user = new User("teste", "teste", DateTime.Now, "female");
        //    user.Password = "1234567";

        //    _service.Insert(user);
        //}

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GenderNull()
        {
            var user = new User("teste", "teste", DateTime.Now, "female");
            user.Password = "1234567";

            _service.Insert(user);
        }
    }
}