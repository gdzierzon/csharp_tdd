﻿using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Library.Tests
{
    [TestFixture()]
    [Category("Book - CheckIn Tests")]
    public class BookCheckInTests
    {

        [Test()]
        public void CheckIn_WhenBook_IsCheckedIn()
        {
            //Arrange
            var book = new Book();

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
                                                     {
                                                         book.CheckIn();
                                                     },
                                                     "a book that is checked in cannot be checked in");

        }

        [Test()]
        public void CheckIn_WhenBook_IsCheckedOut()
        {
            //Arrange
            var book = new Book(BookState.CheckedOut);
            var expectedState = BookState.CheckedIn;

            //Act
            var newState = book.CheckIn();

            //Assert
            newState.Should().Be(expectedState, "a checked out book can be checked in");
        }

        [Test()]
        public void CheckIn_WhenBook_IsCheckOutAndOnHold()
        {
            //Arrange
            var book = new Book(BookState.CheckedOutHold);
            var expectedState = BookState.Hold;

            //Act
            var newState = book.CheckIn();

            //Assert
            newState.Should().Be(expectedState, "a check out book that is also on hold can be checked in");

        }

        [Test()]
        public void CheckIn_WhenBook_IsOnHold()
        {
            //Arrange
            var book = new Book(BookState.Hold);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
                                                     {
                                                         book.CheckIn();
                                                     },
                                                     "a book that is on hold cannot be checked in");
        }
    }
}