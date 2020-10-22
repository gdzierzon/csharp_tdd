using System;

namespace LibraryState.States
{
    public class CheckedInState: BookState
    {
        public override BookState CheckIn()
        {
            throw new InvalidOperationException("A checked in book cannot be checked in.");
        }

        public override BookState CheckOut()
        {
            return CheckedOutBookState;
        }

        public override BookState PlaceHold()
        {
            throw new InvalidOperationException("A book on hold cannot be checked in.");
        }
    }
}