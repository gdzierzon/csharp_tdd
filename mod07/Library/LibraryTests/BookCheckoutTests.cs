using NUnit.Framework;
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
    [Category("Book - CheckOut Tests")]
    public class BookCheckOutTests
    {
        [Test()]
        public void CheckOut_WhenBook_IsCheckedIn()
        {
            //Arrange
            var book = new Book();
            var expectedState = BookState.CheckedOut;

            //Act
            var newState = book.CheckOut();

            //Assert
            newState.Should().Be(expectedState, "a checked in book can be checked out");
        }

        [Test()]
        public void CheckOut_WhenBook_IsCheckedOut()
        {
            //Arrange
            var book = new Book(BookState.CheckedOut);

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
            var book = new Book(BookState.CheckedOutHold);

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
            var book = new Book(BookState.Hold);
            var expectedState = BookState.CheckedOut;

            //Act
            var newState = book.CheckOut();

            //Assert
            newState.Should().Be(expectedState, "a book on hold can be checked out");
        }
    }
}