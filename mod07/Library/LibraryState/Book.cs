using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryState.States;

namespace LibraryState
{
    public class Book
    {
        public BookState State { get; private set; }

        public Book()
        {
            State = BookState.CheckedInBookState;
        }

        public Book(BookState state)
        {
            this.State = state;
        }

        public BookState CheckOut()
        {
            State = State.CheckOut();
            return State;
        }

        public BookState CheckIn()
        {
            State = State.CheckIn();
            return State;
        }

        public BookState PlaceHold()
        {
            State = State.PlaceHold();
            return State;
        }
    }
}
