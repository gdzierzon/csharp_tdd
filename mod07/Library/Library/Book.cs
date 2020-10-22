using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public BookState State { get; private set; }

        public Book()
        {
            State = BookState.CheckedIn;
        }

        public Book(BookState state)
        {
            this.State = state;
        }

        public BookState CheckOut()
        {
            switch (State)
            {
                case BookState.CheckedIn:
                case BookState.Hold:
                    State = BookState.CheckedOut;
                    break;
                default:
                    throw new InvalidOperationException($"A book cannot be checked out when it is: {State}");
            }

            return State;
        }

        public BookState CheckIn()
        {
            switch (State)
            {
                case BookState.CheckedOut:
                    State = BookState.CheckedIn;
                    break;
                case BookState.CheckedOutHold:
                    State = BookState.Hold;
                    break;
                default:
                    throw new InvalidOperationException($"A book cannot be checked in when it is: {State}");
            }

            return State;
        }

        public BookState PlaceHold()
        {
            switch (State)
            {
                case BookState.CheckedIn:
                    State = BookState.Hold;
                    break;
                case BookState.CheckedOutHold:
                    State = BookState.CheckedOutHold;
                    break;
                default:
                    throw new InvalidOperationException($"A book cannot be placed on hold when it is: {State}");
            }

            return State;
        }
    }
}
