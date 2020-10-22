using System;
using FluentAssertions;
using LibraryState.States;
using NUnit.Framework;

namespace LibraryState.Tests
{
    [TestFixture()]
    [Category("Book - CheckOut Tests")]
    public class BookCheckOutTests
    {
        [Test()]
        public void CheckOut_WhenBook_IsCheckedIn()
        {
            //Arrange
            var book = new Book();
            var expectedState = BookState.CheckedOutBookState;

            //Act
            var newState = book.CheckOut();

            //Assert
            newState.Should().Be(expectedState, "a checked in book can be checked out");
        }

        [Test()]
        public void CheckOut_WhenBook_IsCheckedOut()
        {
            //Arrange
            var book = new Book(BookState.CheckedOutBookState);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.CheckOut();
            },
                                                     "a book that is checked out cannot be checked out");

        }

        [Test()]
        public void CheckOut_WhenBook_IsCheckOutAndOnHold()
        {
            //Arrange
            var book = new Book(BookState.CheckedOutHoldBookState);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.CheckOut();
            },
                                                     "a book that is checked out cannot be checked out");

        }

        [Test()]
        public void CheckOut_WhenBook_IsOnHold()
        {
            //Arrange
            var book = new Book(BookState.OnHoldBookState);
            var expectedState = BookState.CheckedOutBookState;

            //Act
            var newState = book.CheckOut();

            //Assert
            newState.Should().Be(expectedState, "a book on hold can be checked out");
        }
    }
}